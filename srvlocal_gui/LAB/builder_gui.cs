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
using DarkUI.Forms;
using OpenTK.Graphics.OpenGL;
using static Google.Apis.Requests.BatchRequest;
using Modern.WindowKit.Controls;
using RuFramework;
using Telerik.WinControls.UI.Map.Bing;

namespace srvlocal_gui.LAB
{
    public partial class builder_gui : Form
    {
        private int childFormNumber = 0;
        public string projectFile = string.Empty;
        public static Form bagHandle;
        public static Form prjExpHandle;
        private ICSharpCode.TextEditor.TextEditorControlEx textEditorControl1;


        public builder_gui(string projectName)
        {

            InitializeComponent();
            this.projectFile = projectName;

            try
            {
                LoadProject();
                Thread.Sleep(300);
                status.Text = "Projekt Bereit";

                try
                {
                    //menuStrip.Renderer = new LABLibary.Form.MenuStrip.MyRenderer(true, Color.FromArgb(21, 21, 21));
                    //dateiDrop.Renderer = new LABLibary.Form.MenuStrip.MyRenderer(true, Color.FromArgb(21, 21, 21));
                    //toolStrip.Renderer = new LABLibary.Form.MenuStrip.MyRenderer(false, Color.FromArgb(24, 24, 24));
                }
                catch (Exception ex)
                {
                    status.Text = ex.Message;
                }
            }
            catch (Exception ey)
            {
                if (!DebugSettings.Default.debug)
                {
                    MessageBox.Show(ey.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textEditorControl1_TextChanged(object sender, System.EventArgs e)
        {
            UpdateAndCheckFoldings();
        }

        private void UpdateAndCheckFoldings()
        {
            textEditorControl1.Document.FoldingManager.UpdateFoldings(null, null);
            textBox1.Text = string.Join("\r\n", textEditorControl1.GetFoldingErrors());
        }

        private async void builder_gui_Load(object sender, EventArgs e)
        {
            var api = new Thread(StartPipe);
            api.Start();

            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControlEx();
            this.textEditorControl1.ContextMenuEnabled = true;
            this.textEditorControl1.AutoScaleMode = AutoScaleMode.Dpi;
            this.textEditorControl1.ContextMenuShowDefaultIcons = true;
            this.textEditorControl1.ContextMenuShowShortCutKeys = true;
            this.textEditorControl1.FoldingStrategy = "C#";
            this.textEditorControl1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.textEditorControl1.HideVScrollBarIfPossible = false;
            mainView.Panel2.Controls.Add(this.textEditorControl1);
            textEditorControl1.Dock = DockStyle.Fill;
            this.textEditorControl1.Name = "codeEdit";
            this.textEditorControl1.ShowVRuler = true;
            this.textEditorControl1.Size = new System.Drawing.Size(596, 353);
            this.textEditorControl1.SyntaxHighlighting = "C#";
            textEditorControl1.HideVScrollBarIfPossible = true;
            this.textEditorControl1.TabIndex = 1;
            this.textEditorControl1.VRulerRow = 999;
            this.textEditorControl1.TextChanged += (sender, e) => 
            { 
                Task task = new Task(() => 
                { 
                    UpdateAndCheckFoldings(); 
                });  
                
                Thread t1 = new Thread(task.Start); 
                t1.Start(); 
                t1.Join(); 
            };

            var explorer = new LAB.TOOLS.ProjectExplorer(projectFile);
            explorer.Show();
            prjExpHandle = explorer;
            explorer.MdiParent = this;
            mainView.Panel1.Controls.Add(explorer);
            explorer.Dock = DockStyle.Fill;
        }

        public async void StartPipe()
        {
            var pipe = new LABLibary.Network.DataPipe("service/worker", "liloDev420");

            while (true)
            {
                Application.DoEvents();
                var response = await pipe.GetDataAsync();
                LABLibary.Forms.ErrorDialog.ErrorManager.AddError(response, true, "MessageQueringPipeline");
            }
        }

        public void OpenProject(object sender, EventArgs e)
        {

        }

        public void NewProject(object sender, EventArgs e)
        {
            var setup = new Setup();
            setup.Show();
        }

        public void LoadProject(string FILE = null)
        {
            if(FILE != null)
            {
                ProjectExplorer.chnFile = FILE;

                var loadedProject = Project.LoadFromFile(FILE);
                this.Text = loadedProject.Name + $" - LAB";
                projectFile = FILE;
                if (loadedProject.Target != RuntimeInformation.RuntimeIdentifier)
                {
                    status.Text = "You are Developing a Programm for another OperatingSystem. You cant test or Debug";
                }
            }
            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "\\srvlocal_gui.exe";
            proc.StartInfo.Arguments = "--nowin";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();

            Form childForm = new EDITOR.EditorJS();
            childForm.MdiParent = this;
            childForm.Dock = DockStyle.Fill;
            childForm.FormBorderStyle = FormBorderStyle.None;   
            childForm.Text = "LAB Code";
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "LAP Project (*.lab)|*.lab|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                LoadProject(FileName);
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
                // Init RuProgressBar with message text in RuProgressBar
                RuProgressBar ruProgressBar = new RuProgressBar(Text = $"Loading Solution \"{filename}\"");
                // Just one example of an MyObject handed over (Dummy)
                object MyObject = null;
                // Handed down dummy object, number of passes and step(divisor)
                MyFunctionality myFunctionality = new MyFunctionality(MyObject, 1000000, 10);
                // Run application with RuProgressBar
                // In the example, a whole object containing the function is passed
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(myFunctionality.LoadingProject), ruProgressBar);
                ruProgressBar.ShowDialog();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
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
            this.Enabled = false;

            var filePath = ".\\srvlocal.exe";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filePath,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();

            while (!process.Responding)
            {
                
            }

            this.Enabled = true;  
        }

        private void UpdateText(string selectedItem)
        {
            textEditorControl1.SetHighlighting(selectedItem);
            textEditorControl1.SetFoldingStrategy(selectedItem);

            UpdateAndCheckFoldings();
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

        private void projektProjektmappeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(addFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Run_RuProgressBar(LABLibary.Converter.FileC.GetFileName(addFile.FileName));
                    LoadProject(addFile.FileName);
                }
                catch(Exception ex) 
                {
                    LABLibary.Forms.ErrorDialog.ErrorManager.AddError(ex.Message, true, "ProjectManager");
                    LABLibary.Forms.ErrorDialog.Show();
                }
            }
        }

        private void ordnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFolderDialog ofd = new OpenFolderDialog();
            ofd.Title = "Open Solution directory";
        }
    }

    public class MyFunctionality
    {
        private int max = 0;
        private int divisor = 1;
        public MyFunctionality(object MyObject = null, int Max = 0, int Divisor = 10)
        {
            object myObject = MyObject;
            max = Max;
            divisor = Divisor;
        }
        public void LoadingProject(object status)
        { 
            divisor = 60;

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
