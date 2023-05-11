using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Net.Sockets;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.IO;
using LABLibary.Assistant;
using System.ComponentModel;
using LABLibary.Forms;
using System.Net.Http.Headers;
using Octokit;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.Logging;
using Markdig;
using srvlocal_gui.AppManager;
using srvlocal_gui.AppMananger;
using Telerik.Pivot.Core;
using Guna.UI2.WinForms;

namespace srvlocal_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NotifyIcon noty;

        public static string filePath = ".\\srvlocal.exe";
        public static Process? consoleHandle;
        public string owner = "JW-Limited";
        public string repo = "LILO-LocalServer";
        public bool UpdateDetected = false;


        public static string VersionApp()
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(filePath);
            return versionInfo.ProductVersion;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            /*Ü
            Settings setting()
            {
                return SettingsManager.Instance.LoadSettingsAsync().Result;
            }
            ^*/
            lblDomain_2.Text = AppDomain.CurrentDomain.BaseDirectory;
            lblReach.Text = Program.CheckIfDirIsValid().ToString() as string;
            ToolTip.UseAnimation = true;


            Text = SettingsManager.Instance.GetSetting(settings => settings.WindowTitle, "LILO Localserver");

            var LoadedSettings = SettingsManager.Instance.LoadSettings();
            chbChangePort.Checked = LoadedSettings.CustomPortConfig;
            chbDistFolder.Checked = LoadedSettings.CustomCDNConfig;
            txtPort.Text = $"{LoadedSettings.Port}";
            txtDistFolder.Text = LoadedSettings.CDNPath;

            try
            {
                lblVersion.Text = VersionApp();
                if (!File.Exists("C:\\LILO" + filePath))
                {
                    File.Copy(filePath, "C:\\LILO" + filePath);
                    File.Copy(filePath.Replace(".exe", ".dll"), "C:\\LILO" + filePath.Replace(".exe", ".dll"));
                }

            }
            catch
            {
                MessageBox.Show("Some Ressources are missing. Please Re-Install the Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.Browser_();
                this.Close();
            }


            LicenseEvaluation();
        }

        delegate void PrintDelegate(string text);
        /*
        PrintDelegate PrintToConsole = (string text) =>
        {
            var log = new Log();
            log.WriteEntry(text);
            Console.WriteLine(text);
        };

        PrintDelegate WriteToFile = (string text) =>
        {
            var log = new Log();
            log.WriteEntry(text);
            File.AppendAllText("./logs.txt", text);
        };*/

        void LogEvents(PrintDelegate log, string logContent)
        {
            log(logContent);
        }

        private void LicenseEvaluation()
        {
            try
            {
                DateTime expireDate;

                var lic = LABLibary.Assistant.ReadLicense.Read(".\\license.labl");
                lblCode.Text = LicenseValues.Default.licCode;
                if (LicenseGenerator.DecodeLicense(lic.Code, out string productName, out string productVersion, out DateTime expirationDate))
                {
                    lblExpires.Text = expirationDate.ToString();
                }
                else { lblExpires.Text = ("Invalid license code."); /*LogEvents(WriteToFile, "Invalid license code.");*/ }

                if (lic.UserRightStatus.Length >= 10)
                {
                    string[] splitRights = lic.UserRightStatus.Split('_');
                    if (splitRights[0] == "admin-rights")
                    {
                        if (splitRights[1].EndsWith("lilodev420")) DebugSettings.Default.debug = true;
                        else DebugSettings.Default.debug = false;

                        //LogEvents(WriteToFile, "Set RightsPerUserTo : " + DebugSettings.Default.debug);
                        DebugSettings.Default.Save();
                    }
                }
                lblProduct.Text = lic.Assembly.Name;
                lblProductVersion.Text = lic.Assembly.Version.ToString();
                lbliv.Text = LicenseValues.Default.iv;
                lblkey.Text = LicenseValues.Default.key;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "License Activation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bntOpen_Click(object sender, EventArgs e)
        {
            Program.Browser_();
        }

        private void lblDomain_Click(object sender, EventArgs e)
        {
            var Proc = Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory);
        }

        private void bntUpdate(object sender, EventArgs e)
        {
            var updater = Updater.Instance();

            var latestVersion = updater.GetLatestVersion(owner, repo);
            var latestChanges = updater.GetLatestChanges(owner, repo);

            if (bntCheck.Text == "Install")
            {
                Process.Start("explorer.exe", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
                System.Windows.Forms.Application.ExitThread();
            }
            else
            {
                switch (UpdateDetected)
                {
                    case true:
                        string html = Markdig.Markdown.ToHtml(latestChanges);
                        var _read = ReadMeDialog.Instance();
                        _read.htmlCode = html;
                        _read.name = "Latest Release";
                        _read.version = latestVersion;
                        _read.Show();
                        _read.BringToFront();
                        break;
                    default:

                        Task.Run(() =>
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                if (updater.HasNewRelease(owner, repo))
                                {
                                    Console.WriteLine("A new release is available.");
                                    richTxtStatus.Text = $"A new release is available. \nYour Version : {updater.GetCurrentVersion()}\nLatest Version : {latestVersion}";
                                    UpdateDetected = true;
                                    bntCheck.Text = "Download";

                                    string html = Markdig.Markdown.ToHtml(latestChanges);
                                    var _read = ReadMeDialog.Instance();
                                    _read.htmlCode = html;
                                    _read.name = "Latest Release";
                                    _read.version = latestVersion;
                                    _read.Show();


                                }
                                else
                                {
                                    Console.WriteLine("No new release available.");
                                    richTxtStatus.Text = "No new release available.\nYou are perfect.";
                                }
                            });

                        });
                        break;

                }
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var Proc = Process.Start("explorer.exe", "C:\\LILO\\dist");
        }

        public void RunConsoleApplication(string filePath)
        {
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

            consoleHandle = process;

            process.OutputDataReceived += (sender, args) => _outputTextBox.Invoke(new Action(() => _outputTextBox.AppendText(args.Data + Environment.NewLine)));
            process.Start();
            process.BeginOutputReadLine();

            NotyFi();

            bool reachable = false;
            Ping ping = new Ping();

            while (process.HasExited == false)
            {
                System.Windows.Forms.Application.DoEvents();
                //process.WaitForExitAsync();
                PingReply reply = ping.Send("localhost", 8080);
                reachable = reply.Status == IPStatus.Success;
                lblReach.Text = reachable.ToString() as string;
            }
            //process.WaitForExit();
        }

        private void bntStartCon(object sender, EventArgs e)
        {
            string filePath = ".\\srvlocal.exe";
            ConsolePanel.Visible = true;

            try
            {
                if (Process.GetProcessesByName("srvlocal").Length > 0)
                {
                    foreach (var prockill in Process.GetProcessesByName("srvlocal"))
                    {

                        prockill.Kill();

                    }
                }

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

                process.OutputDataReceived += (sender, args) => _outputTextBox.Invoke(new Action(() => _outputTextBox.AppendText(args.Data + Environment.NewLine)));
                process.Start();

                NotyFi();

                bool reachable = false;
                Ping ping = new Ping();

                process.BeginOutputReadLine();
                while (process.HasExited == false)
                {
                    System.Windows.Forms.Application.DoEvents();
                    //process.WaitForExitAsync();
                    PingReply reply = ping.Send("localhost", 8080);
                    reachable = reply.Status == IPStatus.Success;
                    lblReach.Text = reachable.ToString() as string;
                }

                ConsolePanel.Visible = true;
            }
            catch (Exception ey)
            {
                MessageBox.Show(ey.Message);
            }
        }

        private async void guna2Button6_Click(object sender, EventArgs e)
        {
            ConsolePanel.Visible = false;

            try
            {
                var url = $"http://localhost:{txtPort.Text}/api/com?command=close";
                foreach (var srv in Process.GetProcessesByName("srvlocal"))
                {
                    var time = srv.StartTime;
                    var overall = srv.TotalProcessorTime;
                    srv.Kill();
                    //ConsolePanel.Visible = false;
                    lblError.Text = String.Format("[LocalServer] Closed (TotalOn:{1},Start:{2})", time, overall);
                }
            }
            catch
            {


            }


            ConsolePanel.Visible = false;

            //var status = await GetFromHost(url);
            //ConsolePanel.Visible = false;
            //lblError.Text = status.ToString();
        }
        /*

        public static async Task<string> GetFromHost(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    var responseContent = await response.Content.ReadAsStringAsync();
                    client.CancelPendingRequests();
                    return responseContent;
                }
                catch { return "Error while closing the Stream"; };
            }
        }
        */

        private void bntStartWithArguments(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.Append("srvlocal.exe ");

            if (chbChangePort.Checked)
            {
                sb.Append(" --port=" + txtPort.Text);
            }
            if (chbDistFolder.Checked)
            {
                sb.Append(" --folder=" + txtDistFolder.Text);
            }
            if (chbChangeMediaFolder.Checked)
            {
                sb.Append(" --media-folder=" + txtMediaFolder.Text);
            }
            if (chbDisable.Checked)
            {
                sb.Append(" --disable-logging");
            }

            string filePath = "srvlocal.exe";
            ConsolePanel.Visible = true;

            try
            {
                if (Process.GetProcessesByName("srvlocal").Length > 0)
                {
                    foreach (var prockill in Process.GetProcessesByName("srvlocal"))
                    {

                        prockill.Kill();

                    }
                }

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = filePath,
                        Arguments = sb.ToString(),
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.OutputDataReceived += (sender, args) => _outputTextBox.Invoke(new Action(() => _outputTextBox.AppendText(args.Data + Environment.NewLine)));
                process.Start();
                process.BeginOutputReadLine();
                while (process.HasExited == false)
                {
                    System.Windows.Forms.Application.DoEvents();
                    process.WaitForExitAsync();
                }

                ConsolePanel.Visible = true;
            }
            catch (Exception ey)
            {
                MessageBox.Show(ey.Message);
            }
        }

        private void bntUFeed(object sender, EventArgs e)
        {
            var feed = new Feed();
            feed.Show();
        }

        public static long PingServer(string host)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(host);

                if (reply.Status == IPStatus.Success)
                {
                    return reply.RoundtripTime;
                }
                else
                {
                    return -1;
                }
            }
            catch { return -1; }


        }


        public void NotyFi(bool inTray = false)
        {
            if (inTray)
            {


                var ping = new Ping()
                {

                };
                var pingResu = ping.SendPingAsync("http://localhost:8080").Status;

                noty = new NotifyIcon()
                {
                    BalloonTipText = $"LocalHost is Running...\nVersion : {VersionApp()}\nPing : {PingServer("http://localhost:8080")}ms"
                        as string,
                    BalloonTipTitle = $"Started Succesfully"
                        as string,
                    BalloonTipIcon = ToolTipIcon.Info,

                    Text = "Manages the DesktopClient.",

                    Icon = this.Icon,
                    ContextMenuStrip = inTrayCon
                };

                noty.Tag = "STATUS";
                noty.Events();
                noty.Visible = true;
                noty.ShowBalloonTip(1000);
            }
            else
            {
                var ping = new Ping()
                {

                };
                var pingResu = ping.SendPingAsync("http://localhost:8080").Status;

                noty = new NotifyIcon()
                {
                    BalloonTipText = $"LocalHost is Running...\nVersion : {VersionApp()}\nPing : {PingServer("http://localhost:8080")}ms"
                        as string,
                    BalloonTipTitle = $"Started Succesfully"
                        as string,
                    BalloonTipIcon = ToolTipIcon.Info,

                    Text = "Manages the DesktopClient.",

                    Icon = this.Icon,
                    ContextMenuStrip = conMenu
                };

                noty.Tag = "STATUS";
                noty.BalloonTipClicked += (sender, e) => bntUFeed(sender, e);
                noty.Events();
                noty.Visible = true;
                noty.ShowBalloonTip(1000);
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var status = new LILO.JBO.StatusSender();
                if (await status.SendStatus(this) != "Error")
                {
                    var login = new Login()
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    login.ShowDialog();
                }
                else
                {
                    bntStartCon(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bntStartCon(sender, e);
            }


        }

        private void conMenuShowConsole_Click(object sender, EventArgs e)
        {
            var conEmu = new ConsoleEmu();
            conEmu.Show();
        }

        private async void conMenuCloseStream_Click(object sender, EventArgs e)
        {
            foreach (var srv in Process.GetProcessesByName("srvlocal"))
            {
                if (srv.Id == 0) continue;
                var time = srv.StartTime;
                var overall = srv.TotalProcessorTime;
                srv.Kill();

                lblError.Text = String.Format("[LocalServer] Closed (TotalOn:{1},Start:{2})", overall, time);
            }
            ConsolePanel.Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutBox()
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            about.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bibo bibo = new Bibo();
            bibo.Show();
        }

        private void bntMEtro(object sender, EventArgs e)
        {
            var setup = new Setup();
            setup.Show();

            this.WindowState = FormWindowState.Minimized;
        }

        private void txtDistFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChbChangeMediaFolder_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void SetDistInTextbox(TextBox txt, Guna2CheckBox chb)
        {
            FolderBrowser_Host.RootFolder = Environment.SpecialFolder.MyDocuments;
            if (FolderBrowser_Host.ShowDialog() == DialogResult.OK)
            {
                chb.Checked = true;
                txt.Text = FolderBrowser_Host.SelectedPath;
            }
            else
            {
                chb.Checked = false;
            }
        }

        private void chbDistFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDistFolder.Checked)
            {
                SettingsManager.Instance.SetSetting((s, v) => s.CustomCDNConfig = v, chbDistFolder.Checked);
                SettingsManager.Instance.SetSetting((s, v) => s.CDNPath = v, txtDistFolder.Text);
            }
            else
            {
                SettingsManager.Instance.SetSetting((s, v) => s.CustomCDNConfig = v, chbDistFolder.Checked);
                SettingsManager.Instance.SetSetting((s, v) => s.CDNPath = v, "C:\\LILO\\dist");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ArgStart.SaveExit(true);
        }

        public int errorCount = 0;

        private void bntAddError_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void collapsibleGroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void ChangeRec(object sender, EventArgs e)
        {
            SetDistInTextbox(txtMediaFolder, chbChangeMediaFolder);
        }

        private void ChangeDist(object sender, EventArgs e)
        {
            SetDistInTextbox(txtDistFolder, chbDistFolder);
            SettingsManager.Instance.SetSetting((s, v) => s.CustomCDNConfig = v, chbDistFolder.Checked);
            SettingsManager.Instance.SetSetting((s, v) => s.CDNPath = v, txtDistFolder.Text);
        }

        private void chbChangePort_CheckedChanged(object sender, EventArgs e)
        {
            if (chbChangePort.Checked)
            {
                SettingsManager.Instance.SetSetting((s, v) => s.CustomPortConfig = v, chbChangePort.Checked);
                SettingsManager.Instance.SetSetting((s, v) => s.Port = v, Convert.ToInt32(txtPort.Text));
            }
            else
            {
                SettingsManager.Instance.SetSetting((s, v) => s.CustomPortConfig = v, chbChangePort.Checked);
                SettingsManager.Instance.SetSetting((s, v) => s.Port = v, 8080);
            }
        }
    }
}


