using LABLibary.Assistant;
using Modern.WindowKit.Controls;
using srvlocal_gui.AppMananger;
using srvlocal_gui.LAB.HELPER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static srvlocal_gui.ProjectFile;

namespace srvlocal_gui
{
    public partial class Setup : Form
    {
        private Setup(User user)
        {
            InitializeComponent();

            _loggedInUser = user;

            mainApp = AppTypeSelector.TextHeadline;

            txtOrt.TextChanged += (sender, e) =>
            {
                txtOrtProj.Text = txtOrt.Text;
                saaGlowing1.Visible = false;
            };

            txtAppName.TextChanged += (sender, e) =>
            {
                txtNameMappe.Text = txtAppName.Text;
            };

            this.FormClosing += (sender, e) =>
            {
                _Instance = null;
            };
        }

        public static Setup Instance(User user)
        {
            lock (_instanceLock)
            {
                if (_Instance == null)
                {
                    _Instance = new Setup(user);
                }

                return _Instance;
            }
        }

        private static Setup _Instance;
        private static object _instanceLock = new object();
        private User? _loggedInUser = null;
        public string mainApp;
        public int iTab = 1;
        private bool _dragging;
        private Point _offset;
        private Control _draggedControl;
        private Bitmap _dragImage;
        private string _droppedFileName;
        private Point _dragImagePoint;

        private async void zeroitMetroPanelSelection1_Click(object sender, EventArgs e)
        {
            var slc = AppSelector.Instance;
            slc.StartPosition = FormStartPosition.CenterScreen;

            IsLoadingStateSetter(true, "Configuration in progress...");

            if (!slc.Created)
            {

                slc.Show();
            }

            slc.BringToFront();

            slc.FormClosing += (sender, e) =>
            {
                AppTypeSelector.TextSubline = slc.mainDescription;
                mainApp = slc.mainAppName;

                IsLoadingStateSetter(false, null);
            };
        }

        private void IsLoadingStateSetter(bool isLoading, string loadingActivity)
        {
            if (isLoading)
            {
                loadingPanel.Visible = isLoading;
                if (loadingActivity is not null) lblLoadingText.Text = loadingActivity;
            }
            else
            {
                loadingPanel.Visible = false;
            }

        }

        private void bntOFD_Click(object sender, EventArgs e)
        {
            var ofd = new FolderBrowserDialog()
            {
                Tag = "Search (Project Folder)",
                Description = mainApp,
                ShowHiddenFiles = true,
                ShowPinnedPlaces = true,
                ShowNewFolderButton = true,
            };

            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                if (ofd.SelectedPath == null || ofd.SelectedPath.Length == 0) { return; }
                txtOrt.Text = ofd.SelectedPath;
                txtOrtProj.Text = ofd.SelectedPath;
            }

        }

        private void zeroitMetroNavigationButton1_Click(object sender, EventArgs e)
        {

        }

        private void zeroitMetroNavigationButton2_Click(object sender, EventArgs e)
        {
        }


        private void Setup_Load(object sender, EventArgs e)
        {
            txtOrt.Text = "C:\\LILO\\dist";

            if (!_loggedInUser.CanChangeConfig)
            {
                throw new AccessViolationException("This user isnt able to do such actions.");
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            var rm = new Random();

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                _droppedFileName = files[0];
                preLoad.Visible = true;
                var tmr = new System.Windows.Forms.Timer();
                tmr.Enabled = true;
                tmr.Interval = rm.Next(200, 1500);
                tmr.Tick += (sender, e) => tmr.Stop();
                tmr.Tick += Tmr_Tick;

            }
        }

        private void Tmr_Tick(object? sender, EventArgs e)
        {

            preLoad.Visible = false;
            lblHeader.Text = "Setup - Analyzing File: " + _droppedFileName;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _draggedControl = sender as Control;
            _offset = e.Location;
            _dragImage = new Bitmap(_draggedControl.Width, _draggedControl.Height);
            _draggedControl.DrawToBitmap(_dragImage, new Rectangle(0, 0, _dragImage.Width, _dragImage.Height));
            _dragImagePoint = new Point(_draggedControl.Location.X - e.X, _draggedControl.Location.Y - e.Y);

            _draggedControl.DoDragDrop(_dragImage, DragDropEffects.Move);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging)
                return;

            Point currentScreenPos = Control.MousePosition;
            Point newFormLocation = new Point(currentScreenPos.X - _offset.X, currentScreenPos.Y - _offset.Y);
            _draggedControl.Location = panel1.PointToClient(newFormLocation);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void panel1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor.Current = Cursors.Hand;
            if (e.Effect == DragDropEffects.Move)
            {
                e.DragImage = _dragImage;
                //e.Graphics.DrawImage(_dragImage, new Point(e.X - _dragImagePoint.X, e.Y - _dragImagePoint.Y));
            }
        }



        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private readonly int borderSize = 10;
        private Size formSize;
        /*Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);*/

        private async void zeroitMetroButton1_Click(object sender, EventArgs e)
        {
            IsLoadingStateSetter(true, "Building youre App...");

            var dir = txtOrt.Text + "\\" + txtAppName.Text;
            RedirectProjectCreation(process =>
            {
                guna2Button1.Text = "In Process : " + process;
            });
        }

        public void RedirectProjectCreation(Action<string> processCallback)
        {

            var rnd = new Random();

            var myProject = new Project()
            {
                Name = txtAppName.Text,
                Id = rnd.Next(10000, 99999),
                Target = RuntimeInformation.RuntimeIdentifier,
                ApplicationType = mainApp,
                CloudSave = false,
                Author = _loggedInUser.UserName,
                Company = "My Company",
                Framework = cmbFramework.Text,
                Language = "en",
                CreationDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Description = "This is my project.",
                Version = "1.0.0",
                BuildDate = DateTime.Now,
                MachineName = Environment.MachineName,
                ServerIP = "127.0.0.1",
                ApplicationName = txtAppName.Text.ToLower() + ".exe",
                ApplicationDescription = "A LILO Application build with the LAB App.",
                Files = new List<string>
                {
                    "desktop.ini",
                    "Folder.ico"
                },
                References = new List<string>
                {
                    "Form1.cs",
                    "Form1.Designer.cs",
                    "Form1.Resx.cs",
                    "Programm.cs"
                }
            };

            processCallback?.Invoke("20%");

            try
            {
                var dir = txtOrt.Text + "\\" + txtAppName.Text;

                processCallback?.Invoke("30%");

                CreateProject(myProject);

                processCallback?.Invoke("100%");

                var gui = LAB.builder_gui.Instance(dir + "\\" + txtNameMappe.Text + ".lab",LAB.builder_gui.StartMode.Setup);
                gui.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while creating youre Project:\n\n" + ex.Message, "ProjectManager", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public bool projectCreated { get; private set; }


        public void CreateProject(Project values)
        {
            var dir = txtOrt.Text + "\\" + txtAppName.Text;

            do
            {
                Directory.CreateDirectory(dir);
                Directory.CreateDirectory(dir + "\\lab");
            }
            while (!Directory.Exists(dir + "\\lab"));

            File.Copy(".\\Folder.ico", dir + "\\lab\\Folder.ico", true);
            string iconFilePath = dir + "\\lab\\Folder.ico";
            int iconIndex = 0;
            LABLibary.Assistant.DirectoryIconSetter.SetDirectoryIcon(dir, iconFilePath, iconIndex);

            values.SaveToFile(dir + "\\" + txtNameMappe.Text + ".lab");
            var form = new LAB.HELPER.FormsHandler(dir);
            form.Add(txtAppName.Text);

            projectCreated = true;
        }



        private void saaToggle1_CheckChanged(object sender, EventArgs e)
        {
            var gl = new GoogleLogin();
            gl.ShowDialog();

            if (gl.LoggedIn)
            {
                lblStatus.Text = "all go";
            }
        }

        public Form recentForm = null;
        private void Setup_MouseDown(object sender, MouseEventArgs e)
        {
            /*ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);*/
        }

        private void Setup_ResizeBegin(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            _draggedControl = sender as Control;
            _dragImage = new Bitmap(_draggedControl.Width, _draggedControl.Height);
            _draggedControl.DrawToBitmap(_dragImage, new Rectangle(0, 0, _dragImage.Width, _dragImage.Height));
            _draggedControl.DoDragDrop(_dragImage, DragDropEffects.Move);
        }

        private void zeroitMetroChecker1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void metroSetTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }
    }
}
