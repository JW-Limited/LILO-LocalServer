using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srvlocal_gui.LAB.HELPER
{
    public partial class AboutProject : Form
    {
        private static AboutProject instance;
        private static object _lock = new object();
        private ProjectFile.Project _projectFile;

        public static AboutProject Instance(ProjectFile.Project project)
        {
            lock (_lock)
            {
                if (instance is null)
                {
                    instance = new AboutProject(project);
                }

                return instance;
            }


        }

        private AboutProject(ProjectFile.Project project)
        {
            InitializeComponent();

            _projectFile = project;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AboutProject_Load(object sender, EventArgs e)
        {
            txtAuthor.Text = _projectFile.Author;
            txtCompany.Text = _projectFile.Company;
            txtProduct.Text = _projectFile.Name;
            txtAbout.Text = _projectFile.ApplicationDescription;
        }
    }
}
