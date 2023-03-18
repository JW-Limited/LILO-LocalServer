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

namespace srvlocal_gui.LAB
{
    public partial class builder_gui : DarkForm
    {
        private int childFormNumber = 0;
        public string projectFile = string.Empty;
        public static Form bagHandle;
        public static Form prjExpHandle;

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
                    menuStrip.Renderer = new LABLibary.Form.MenuStrip.MyRenderer(true, Color.FromArgb(21, 21, 21));
                    dateiDrop.Renderer = new LABLibary.Form.MenuStrip.MyRenderer(true, Color.FromArgb(21, 21, 21));
                    toolStrip.Renderer = new LABLibary.Form.MenuStrip.MyRenderer(false, Color.FromArgb(24, 24, 24));
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

        private async void builder_gui_Load(object sender, EventArgs e)
        {
            var api = new Thread(StartPipe);
            api.Start();
        }

        public async void StartPipe()
        {
            var pipe = new LABLibary.Network.DataPipe("MyNamedPipe", "mysecretkey");

            // POST request
            while (true)
            {
                Application.DoEvents();
                var response = await pipe.GetDataAsync();

                LABLibary.Forms.ErrorDialog.message[2] = response;
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
            proc.StartInfo.FileName = ".\\srvlocal_gui.exe";
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "LAP Project (*.lab)|*.lab|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var bag = new LAB.TOOLS.Bag();
            bag.MdiParent = this;
            bagHandle = bag;
            bag.Dock = DockStyle.Left;

            var explorer = new LAB.TOOLS.ProjectExplorer(projectFile);
            explorer.MdiParent = this;
            prjExpHandle = explorer;
            explorer.Dock = DockStyle.Left;
            explorer.Show();
            //bag.Show();
            updater.Start();
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
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
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

            var filePath = "C:\\LILO\\srvlocal.exe";
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
    }
}
