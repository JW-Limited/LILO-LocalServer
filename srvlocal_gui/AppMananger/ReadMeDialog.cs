using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srvlocal_gui.AppManager
{
    public partial class ReadMeDialog : Form
    {
        private static ReadMeDialog _instance;
        public static readonly object _lock = new object();
        public string htmlCode { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public string owner = "JW-Limited";
        public string repo = "LILO-LocalServer";
        public bool updating = false;
        public bool downloaded = false;

        public static ReadMeDialog Instance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ReadMeDialog();
                }
            }

            return _instance;
        }

        private ReadMeDialog()
        {
            InitializeComponent();
            this.CancelButton = bntCancel;
        }

        private void ReadMeDialog_Load(object sender, EventArgs e)
        {
            mdText.Text = htmlCode;
            Text = name;
            lblVersion.Text = version;
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            var updater = Updater.Instance();

            try
            {
                if (downloaded)
                {
                    Process.Start("explorer.exe", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
                    System.Windows.Forms.Application.ExitThread();
                }
                else
                {
                    this.ControlBox = false;
                    progessbar.Visible = true;
                    progress.ShowDialog();
                    bntCancel.Enabled = false;
                    updating = true;

                    Task.Run(() =>
                    {
                        
                        updater.DownloadLatestRelease(owner, repo, UpdateProgress);
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.ControlBox = false;
                        });

                    });
                }
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"Update Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                progessbar.Visible = false;
                bntCancel.Enabled = true;
                updating = false;
                downloaded = true;
                this.ControlBox = true;
            }
            
        }

        private void UpdateProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                progessbar.Value = e.ProgressPercentage;
                this.Text = $"Downloading newest release {e.ProgressPercentage}%";

                if (e.ProgressPercentage == 100)
                {
                    bntUpdate.Text = "Install Now!";
                    progessbar.Visible = false;
                    bntCancel.Enabled = true;
                    updating = false;
                    downloaded = true;
                    this.ControlBox = true;
                }
            });
        }

        private void ReadMeDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updating) e.Cancel = true;
            else
            {
                _instance = null;
            }
        }

        private void progress_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
