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
using IWshRuntimeLibrary;

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
        public string zipPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "latest_release.zip");
        public Action<bool> isEnabling;

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

        public async void del(string latestVersion)
        {
            var targetFile = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "//JW Limited//LAB//srvlocal_gui.exe";
            CreateShortcut("LAB", targetFile);
            Updater.RegisterProduct("LAB", latestVersion, targetFile);
            Process.Start(targetFile);
        }

        public static void CreateShortcut(string shortcutName, string targetFile)
        {
            string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + shortcutName + ".lnk";

            IWshShell wshShell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)wshShell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = targetFile;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetFile);
            shortcut.WindowStyle = 1; // Normal window
            shortcut.Description = "Shortcut created using LAB Libary by JW Limited."; // Optional
            shortcut.IconLocation = targetFile + ",0"; // Optional

            shortcut.Save();
        }

        private async void bntUpdate_Click(object sender, EventArgs e)
        {
            var updater = Updater.Instance();

            try
            {
                if (downloaded)
                {
                    isEnabling?.Invoke(false);
                    this.ControlBox = false;
                    progessbar.Visible = true;
                    progress.ShowDialog();
                    bntCancel.Enabled = false;
                    updating = true;
                    Text = "Installing Update...";

                    await Task.Run(() =>
                    {
                        try
                        {
                            // Call the API to verify and extract the ZIP file
                            updater.VerifyAndExtractZip(zipPath, "8a3a0cecf50f9e4a7387b23d4a4c4e4b3d2bbd8e91edc5729c15f9f1f10c8aaf", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "JW Limited"), 
                            progress =>
                            {
                                progessbar.Value = progress;
                                taskDialog1.ProgressBarValue = progress;
                                if (progress == 100)
                                {
                                    Task.Run(() => { del(latestVersion: version);
                                        Application.ExitThread();
                                    });

                                    Application.ExitThread();
                                }
                            },
                            error =>
                            {
                                MessageBox.Show($"Error: {error}", "Install Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Install Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });

                    MessageBox.Show("Installed Updates", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    isEnabling?.Invoke(false);

                    this.ControlBox = false;
                    progessbar.Visible = true;
                    bntCancel.Enabled = false;
                    updating = true;

                    await Task.Run(() =>
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
                MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    isEnabling?.Invoke(true);
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
