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

namespace srvlocal_gui.LAB.TOOLS
{
    public partial class ProjectExplorer : Form
    {
        private string prjFile;

        public ProjectExplorer(string Projectfile)
        {
            InitializeComponent();

            this.prjFile = Projectfile;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void ProjectExplorer_Load(object sender, EventArgs e)
        {
            var loadedProject = ProjectFile.Project.LoadFromFile(prjFile);


            foreach(var file in loadedProject.Files)
            {
                treeView1.Nodes.Add("Files \\ " + file);
            }

            foreach (var file in loadedProject.References)
            {
                treeView1.Nodes.Add("References \\ " + file);
            }
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            builder_gui.prjExpHandle.Dock = DockStyle.None;
        }
    }
}
