using srvlocal_gui.LAB;
using srvlocal_gui.LAB.TOOLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srvlocal_gui.AppMananger
{
    public partial class StartWindow : Form
    {
        private static StartWindow _instance;
        private static object _instanceLock = new object();

        public static StartWindow Instance()
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new StartWindow();
                }

                return _instance;
            }
        }

        private StartWindow()
        {
            InitializeComponent();

            this.FormClosing += (sender, e) =>
            {
                _instance = null;
            };
        }

        private void StartWindow_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var instanceUser = new Program.SettingsTemplate();
            var setup = Setup.Instance(instanceUser.admin);

            setup.Show();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = "Project Datei|*lab*",
                AddExtension = true,
                AutoUpgradeEnabled = true,
                OkRequiresInteraction = true,
                Title = "Open Project File"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var builder = builder_gui.Instance(dlg.FileName, builder_gui.StartMode.StartWindow);
                    builder.Show();

                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
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
                foreach (var file in Directory.GetFiles(fbd.SelectedPath))
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Extension == ".lab")
                    {
                        try
                        {
                            var builder = builder_gui.Instance(fi.FullName, builder_gui.StartMode.StartWindow);
                            builder.Show();

                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void supportClick(object sender, EventArgs e)
        {
            var chat = new SupportChat();
            chat.Show();
        }
    }
}
