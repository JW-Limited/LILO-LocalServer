using srvlocal_gui.AppManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit.Sdk;
using AForge.Video;
using AForge.Video.DirectShow;

namespace srvlocal_gui.AppMananger
{
    public partial class srvlocal_gui_settings : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private static srvlocal_gui_settings _instance;
        public static readonly object _lock = new object();
        public Settings _settings;
        public User _loggedInUser;

        public static srvlocal_gui_settings Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new srvlocal_gui_settings();
                    }

                    return _instance;
                }

            }

        }

        private void PopulateVideoDevices()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            /*
            foreach (FilterInfo device in videoDevices)
            {
                cmbDevices.Items.Add(device.Name);
            }*/
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            videoPanel.Invoke((MethodInvoker)(() =>
            {
                videoPanel.FillColor = TransparencyKey;
                videoPanel.BackgroundImage = frame;
            }));
        }

        private srvlocal_gui_settings()
        {
            InitializeComponent();
        }

        private async void srvlocal_gui_settings_Load(object sender, EventArgs e)
        {
            if (_settings == null)
            {
                throw new Exception("The Settings-Object cant be null.");
            }
            if (_loggedInUser == null)
            {
                throw new Exception("The User-Object cant be null.");
            }

            var loaded = await LoadDataInMask();

            if (!loaded)
            {
                throw new Exception("Could not load the availabel data in the mask.");
            }

        }

        public async Task<bool> LoadDataInMask()
        {
            try
            {
                lblUsername.Text = _loggedInUser.UserName;
                lblEmail.Text = _loggedInUser.Email;
                PopulateVideoDevices();

                if (!_loggedInUser.CanChangeConfig)
                {
                    tbGUI.Hide();
                    tbServer.Hide();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void srvlocal_gui_settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _instance = null;
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }

            /*if (cmbDevices.SelectedIndex >= 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[cmbDevices.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
            }*/

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = $"http://localhost:{_settings.Port}/api/com?command=close&key=liloDev-420";
                string response = Form1.Instance.MakeGetRequest(url);

                if (response != null)
                {
                    Logger.Instance.Log(response, logLevel: Logger.LogLevel.Info);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);

            }

            Application.Restart();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = ChangePassword.Instance(_loggedInUser);
            changePassword.Show();
            changePassword.BringToFront();
        }

        private void bntChangeFavouriteColor(object sender, EventArgs e)
        {
            colorChooser.AllowFullOpen = true;
            colorChooser.Color = _loggedInUser.FavouriteColor;
            colorChooser.SolidColorOnly = true;

            if (colorChooser.ShowDialog() == DialogResult.OK)
            {
                var settings = SettingsManager.Instance.LoadSettings();

                foreach (var user in settings.Users)
                {
                    if (user.UserName == _loggedInUser.UserName)
                    {
                        user.FavouriteColor = colorChooser.Color;
                    }
                }

                SettingsManager.Instance.SetSetting((s, v) => s.Users = v, settings.Users);

            }
        }

        private void bntChangeEmail_Click(object sender, EventArgs e)
        {
            Program.Browser_("www.jw-lmt.com/account");
        }
    }
}
