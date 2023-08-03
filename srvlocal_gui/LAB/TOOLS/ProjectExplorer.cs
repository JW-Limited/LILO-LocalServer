using DarkUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DarkUI;
using MetroFramework.Properties;
using srvlocal_gui.Properties;
using System.Windows.Media.TextFormatting;

namespace srvlocal_gui.LAB.TOOLS
{
    public partial class ProjectExplorer : Form
    {

        private static ProjectExplorer _instance;
        private static object _instanceLock = new object();

        public static ProjectExplorer Instance(string Projectfile)
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new ProjectExplorer(Projectfile);
                }

                return _instance;
            }
        }


        private ProjectExplorer(string Projectfile)
        {
            InitializeComponent();

            this.FormClosing += (sender, e) =>
            {
                _instance = null;
            };

            this.prjFile = Projectfile;
        }


        private string prjFile;
        public static string chnFile = string.Empty;

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        public void Reload(string newProject)
        {
            var loadedProject = ProjectFile.Project.LoadFromFile(newProject);

            var node = new DarkTreeNode($"Root Files");
            node.ExpandedIcon = Properties.Resources.icons8_open_file_folder_16;
            node.Icon = Properties.Resources.icons8_file_folder_16;

            var node2 = new DarkTreeNode($"References");
            node2.ExpandedIcon = Properties.Resources.icons8_open_file_folder_16;
            node2.Icon = Properties.Resources.icons8_file_folder_16;

            foreach (var file in loadedProject.Files)
            {
                var childNode = new DarkTreeNode($"{file}");
                childNode.Icon = Properties.Resources.new_16;
                node.Nodes.Add(childNode);
            }

            foreach (var file in loadedProject.References)
            {
                var childNode = new DarkTreeNode($"{file}");
                childNode.Icon = Properties.Resources.new_16;
                node2.Nodes.Add(childNode);
            }

            var proj = new DarkTreeNode($"Projekt ({loadedProject.Name})");
            proj.ParentNode = node;
            proj.ParentNode = node2;

            treeTest.Nodes.Add(proj);
            treeTest.Nodes.Add(node);
            treeTest.Nodes.Add(node2);
        }

        private void ProjectExplorer_Load(object sender, EventArgs e)
        {

            try
            {
                var loadedProject = ProjectFile.Project.LoadFromFile(prjFile);

                var node = new DarkTreeNode($"Root Files");
                node.ExpandedIcon = Properties.Resources.icons8_open_file_folder_16;
                node.Icon = Properties.Resources.icons8_file_folder_16;

                var node2 = new DarkTreeNode($"References");
                node2.ExpandedIcon = Properties.Resources.icons8_open_file_folder_16;
                node2.Icon = Properties.Resources.icons8_file_folder_16;

                foreach (var file in loadedProject.Files)
                {
                    var childNode = new DarkTreeNode($"{file}");
                    childNode.Icon = Properties.Resources.new_16;
                    node.Nodes.Add(childNode);
                }

                foreach (var file in loadedProject.References)
                {
                    var childNode = new DarkTreeNode($"{file}");
                    childNode.Icon = Properties.Resources.new_16;
                    node2.Nodes.Add(childNode);
                }

                var proj = new DarkTreeNode($"Projekt ({loadedProject.Name})");
                proj.ParentNode = node;
                proj.ParentNode = node2;

                treeTest.Nodes.Add(proj);
                treeTest.Nodes.Add(node);
                treeTest.Nodes.Add(node2);
            }
            catch (Exception ey)
            {
                if (!DebugSettings.Default.debug)
                {
                    MessageBox.Show(ey.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (builder_gui.prjExpHandle.Dock == DockStyle.Right)
            {
                builder_gui.prjExpHandle.Dock = DockStyle.None;
                builder_gui.prjExpHandle.Location = new Point(e.Location.X, e.Location.Y);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chnFile != string.Empty)
            {
                Reload(chnFile);
                chnFile = string.Empty;
            }
        }
    }
}
