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
            foreach (FilterInfo device in videoDevices)
            {
                cmbDevices.Items.Add(device.Name);
            }
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

        }

        public async Task<bool> LoadDataInMask()
        {
            try
            {
                lblUsername.Text = _loggedInUser.UserName;
                lblEmail.Text = _loggedInUser.Email;
                PopulateVideoDevices();

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

            if (cmbDevices.SelectedIndex >= 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[cmbDevices.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
            }

        }
    }
}
