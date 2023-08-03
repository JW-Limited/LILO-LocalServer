using srvlocal_gui.LAB.TOOLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using static srvlocal_gui.ProjectFile;
using LABLibary;
using RuFramework;
using srvlocal_gui.LAB.SETTINGS;
using srvlocal_gui.LAB.HELPER;
using srvlocal_gui.AppMananger;
using System.IO;

namespace srvlocal_gui.LAB
{
    public partial class builder_gui : Form
    {
        public static builder_gui Instance(string project, StartMode mode)
        {
            lock (_instanceLock)
            {
                if (_instance is null)
                {
                    _instance = new builder_gui(project, mode);
                }

                return _instance;
            }
        }

        public enum StartMode
        {
            ProjectFile,
            StartWindow,
            Setup,
            Debug
        }

        public StartMode _mode;
        public string projectFile = string.Empty;
        public static Form bagHandle;
        public static Form prjExpHandle;
        private static builder_gui _instance;
        private ICSharpCode.TextEditor.TextEditorControlEx textEditorControl1;
        private static object _instanceLock = new object();
        private Project _loadedProject = new Project();

        private builder_gui(string projectName, StartMode mode)
        {
            try
            {
                InitializeComponent();
                this.projectFile = projectName;

                this.FormClosing += (sender, e) =>
                {
                    Application.ExitThread();
                    Application.Exit();
                };

                _mode = mode;

                try
                {
                    menuStrip.Renderer = new LABLibary.Form.MenuStrip.MyRenderer(true, Color.FromArgb(21, 21, 21));
                    dateiDrop.Renderer = new LABLibary.Form.MenuStrip.MyRenderer(true, Color.FromArgb(21, 21, 21));
                }
                catch (Exception ex)
                {
                    status.Text = ex.Message;
                }
            }
            catch (Exception ey)
            {
                MessageBox.Show(ey.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<string> HandleStartMode(builder_gui.StartMode mode)
        {
            try
            {
                switch (mode)
                {
                    case StartMode.ProjectFile or StartMode.Debug:
                        return "splash";
                }
            }
            catch (Exception ey)
            {
                MessageBox.Show(ey.Message);

                return "error";
            }

            return "error";
        }

        public async void StartWithSplashScreen()
        {
            try
            {
                var splash = SplashScreen.Instance();
                FileInfo file = new FileInfo(projectFile);

                this.WindowState = FormWindowState.Minimized;
                this.ShowIcon = false;

                splash.ProvideProcessInformation($"Loading Project \"{file.Name}\"...", 700);
                var loadedProject = await LoadProject(projectFile);

                if (loadedProject)
                {
                    status.Text = "Projekt Bereit";
                    splash.ProvideProcessInformation("Projekt Bereit", 500);
                }
                else
                {
                    status.Text = "Error while Loading.";
                    splash.ProvideProcessInformation("Error while Loading.", 500);
                }

                splash.ProvideProcessInformation($"Starting DesingToolServer...", 1000);
                await StartDesingToolServer();

                this.WindowState = FormWindowState.Maximized;
                this.ShowIcon = false;

                splash.Close();
            }
            catch (Exception ey)
            {
                status.Text = ey.Message;
            }
        }

        private async void builder_gui_Load(object sender, EventArgs e)
        {

            if (_mode is StartMode.ProjectFile)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowIcon = false;
                var explorer = LAB.TOOLS.ProjectExplorer.Instance(projectFile);

                prjExpHandle = explorer;

                this.codeEditor.TextChanged += (sender, e) =>
                {
                    Task CodeCorrectionTask = new Task(() =>
                    {
                        codeEditor.Document.FoldingManager.UpdateFoldings(null, null);
                    });

                    CodeCorrectionTask.Start();
                };

                explorer.Show();
                explorer.MdiParent = this;
                mainView.Panel1.Controls.Add(explorer);
                explorer.Dock = DockStyle.Fill;

                cmbLanguage.Text = "C#";
            }
            else
            {
                var explorer = LAB.TOOLS.ProjectExplorer.Instance(projectFile);
                prjExpHandle = explorer;
                var loadedProject = await LoadProject(projectFile);
                Thread.Sleep(300);

                await StartDesingToolServer();

                if (loadedProject)
                {
                    status.Text = "Projekt Bereit";
                }
                else
                {
                    status.Text = "Error while Loading.";
                }



                this.codeEditor.TextChanged += (sender, e) =>
                {
                    Task CodeCorrectionTask = new Task(() =>
                    {
                        codeEditor.Document.FoldingManager.UpdateFoldings(null, null);
                    });

                    CodeCorrectionTask.Start();
                };
                explorer.Show();



                explorer.MdiParent = this;
                mainView.Panel1.Controls.Add(explorer);
                explorer.Dock = DockStyle.Fill;

                cmbLanguage.Text = "C#";
            }


        }

        public void OpenProject(object sender, EventArgs e)
        {

        }

        public void NewProject(object sender, EventArgs e)
        {
            User user = new User(_loadedProject.Author, "none")
            {
                CanChangeConfig = true,
                Email = "no@email.com",
                IsActivated = true,
            };


            var setup = Setup.Instance(user);
            setup.Show();
        }

        private Task StartDesingToolServer()
        {
            try
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = config.Default.srvlocal_path,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };
                process.Start();

                while (!process.Responding)
                {
                    status.Text = "Waiting for the DesingServer...";
                }

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Internal Error");

                return Task.CompletedTask;
            }
        }

        public async Task<bool> LoadProject(string FILE = null)
        {
            if (FILE != null)
            {
                var loadedProject = Project.LoadFromFile(FILE);

                if (loadedProject is not null)
                {

                    this.Text = loadedProject.Name + $" - LAB";
                    projectFile = FILE;
                    _loadedProject = loadedProject;


                    if (loadedProject.Target != RuntimeInformation.RuntimeIdentifier)
                    {
                        status.Text = "You are Developing a Programm for another OperatingSystem. You cant Test or Debug youre Applicatíon without third party Emulators.";
                    }

                    return true;
                }

                return false;
            }

            throw new System.NullReferenceException();

        }

        private void ShowNewForm(object sender, EventArgs e)
        {

        }

        private async void OpenFile(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "LAP Project (*.lab)|*.lab|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                ProjectExplorer.Instance(FileName).Reload(FileName);
                var loaded = await LoadProject(FileName);

                if (loaded)
                {
                    status.Text = "Projekt Bereit";
                }
                else
                {
                    status.Text = "Error while Loading.";
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "LAP Project (*.lab)|*.lab|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        public void Run_RuProgressBar(string filename)
        {
            try
            {
                RuProgressBar ruProgressBar = new RuProgressBar(Text = $"Loading Solution \"{filename}\"");
                object MyObject = null;
                MyFunctionality myFunctionality = new MyFunctionality(MyObject, 1000000, 10);
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(myFunctionality.LoadingProject), ruProgressBar);
                ruProgressBar.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("An error occurred: \n\n'{0}'", e.Message), "Projektmanager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void builder_gui_Shown(object sender, EventArgs e)
        {
            if (_mode is StartMode.ProjectFile)
            {
                var splash = SplashScreen.Instance();
                splash.Show();
                splash.BringToFront();

                var timer = new System.Timers.Timer();
                timer.Interval = 900;

                timer.Elapsed += (sender, e) =>
                {
                    timer.Stop();

                    StartWithSplashScreen();
                };

                timer.Start();

            }

        }

        private void UpdateText(string selectedItem)
        {
            try
            {
                codeEditor.SetHighlighting(selectedItem);
                codeEditor.SetFoldingStrategy(selectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wrong FoldingStrategy");
            }
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void projectAusVorhandenemCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void dropDown1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void updater_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private async void projektProjektmappeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addFile.ShowDialog() == DialogResult.OK)
            {
                prjExpHandle.Close();

                try
                {
                    Run_RuProgressBar(LABLibary.Converter.FileC.GetFileName(addFile.FileName));
                    var loaded = await LoadProject(addFile.FileName);

                    prjExpHandle = ProjectExplorer.Instance(addFile.FileName) as ProjectExplorer;
                    prjExpHandle.Show();
                    prjExpHandle.BringToFront();
                    prjExpHandle.MdiParent = this;
                    mainView.Panel1.Controls.Add(prjExpHandle);
                    prjExpHandle.Dock = DockStyle.Fill;

                    if (loaded)
                    {
                        status.Text = "Projekt Bereit";
                    }
                    else
                    {
                        status.Text = "Error while Loading.";
                    }

                }
                catch (Exception ex)
                {
                    LABLibary.Forms.ErrorDialog.ErrorManager.AddError(ex.Message, true, "ProjectManager");
                    LABLibary.Forms.ErrorDialog.Show();
                }
            }
        }

        private async void ordnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                OkRequiresInteraction = true,
                AutoUpgradeEnabled = true,
                UseDescriptionForTitle = true,
                ShowHiddenFiles = true,
                RootFolder = Environment.SpecialFolder.MyDocuments
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var loaded = false;

                foreach (var file in Directory.GetFiles(fbd.SelectedPath))
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Extension == ".lab")
                    {
                        try
                        {
                            prjExpHandle.Close();

                            Run_RuProgressBar(file);
                            loaded = await LoadProject(file);

                            prjExpHandle = ProjectExplorer.Instance(file) as ProjectExplorer;
                            prjExpHandle.Show();
                            prjExpHandle.BringToFront();
                            prjExpHandle.MdiParent = this;
                            mainView.Panel1.Controls.Add(prjExpHandle);
                            prjExpHandle.Dock = DockStyle.Fill;

                            if (loaded)
                            {
                                break;
                            }
                        }
                        catch { }

                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateText(cmbLanguage.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can´t change Language.");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var abp = AboutProject.Instance(_loadedProject);
            abp.ShowDialog();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (prjExpHandle.IsAccessible || !prjExpHandle.IsDisposed)
            {
                if (!prjExpHandle.IsMdiChild)
                {
                    prjExpHandle.BringToFront();
                }
                else
                {
                    prjExpHandle.MdiParent = this;
                    mainView.Panel1.Controls.Add(prjExpHandle);
                    prjExpHandle.Dock = DockStyle.Fill;
                }
            }
            else
            {
                prjExpHandle = ProjectExplorer.Instance(projectFile) as ProjectExplorer;
                prjExpHandle.Show();
                prjExpHandle.BringToFront();
                prjExpHandle.MdiParent = this;
                mainView.Panel1.Controls.Add(prjExpHandle);
                prjExpHandle.Dock = DockStyle.Fill;
            }
        }

        private void dateiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var info = new FileInfo(projectFile);

            var ofd = new System.Windows.Forms.OpenFileDialog()
            {
                CheckPathExists = true,
                CheckFileExists = true,
                AddExtension = true,
                InitialDirectory = info.DirectoryName,
                OkRequiresInteraction = true,
                Multiselect = false
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (codeEditor.Text is not null or "")
                {
                    try
                    {
                        var code = new StringBuilder();

                        code.Append(string.Join("\n", File.ReadAllLines(ofd.FileName)));

                        var fileInfo = new FileInfo(ofd.FileName);

                        txtFileName.Text = fileInfo.Name;

                        codeEditor.SetTextAndRefresh(code.ToString(), true);

                        status.Text = "Project Bereit";
                    }
                    catch (Exception ex)
                    {
                        LABLibary.Forms.ErrorDialog.ErrorManager.AddError(ex.Message, true, "CodeEditorFileOperation");
                        LABLibary.Forms.ErrorDialog.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Save First?");
                }
            }


        }

        private void startfensterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newInstance = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Application.ExecutablePath,
                    Arguments = "--startWindow"

                }
            };

            newInstance.Start();
        }

        private void radBrowseEditor1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chat = new SupportChat();
            chat.Show();
        }
    }

    public class MyFunctionality
    {
        private int max = 0;
        private int divisor = 1111;
        public MyFunctionality(object MyObject = null, int Max = 0, int Divisor = 10)
        {
            object myObject = MyObject;
            max = Max;
            divisor = Divisor;
        }
        public void LoadingProject(object status)
        {
            divisor = 1910;

            try
            {
                IProgressCallback callback = status as IProgressCallback;
                callback.Begin(0, max / divisor);
                for (int i = 0; i < max; i++)
                {
                    if (i % divisor == 0 & i > 0)
                    {
                        callback.StepTo(i / divisor);
                    }
                }
                callback.End();
            }
            catch (System.FormatException)
            {
            }
        }
    }
}
