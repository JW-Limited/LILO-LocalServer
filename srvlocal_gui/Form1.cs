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

        public static string VersionApp()
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(filePath);
            return versionInfo.ProductVersion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDomain.Text = AppDomain.CurrentDomain.BaseDirectory;
            lblReach.Text = Program.CheckIfDirIsValid().ToString() as string;
            ToolTip.UseAnimation = true;
            try
            {
                lblVersion.Text = VersionApp();
            }
            catch
            {
                MessageBox.Show("Some Ressources are missing. Please Re-Install the Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.Browser_();
                this.Close();
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

        private async void bntUpdate(object sender, EventArgs e)
        {
            var realeaseCheckler = new GitHubReleaseChecker("JW-Limited", "LILO-LocalServer", "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");
            lblError.Text = null;
            try
            {
                await realeaseCheckler.CheckForNewRelease();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
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

            process.OutputDataReceived += (sender, args) => _outputTextBox.Invoke(new Action(() => _outputTextBox.AppendText(args.Data + Environment.NewLine)));
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }

        private void bntStartCon(object sender, EventArgs e)
        {
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
                    Application.DoEvents();
                    process.WaitForExitAsync();
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
            //var url = $"http://localhost:{txtPort.Text}/api/com?command=close";
            foreach (var srv in Process.GetProcessesByName("srvlocal"))
            {
                var time = srv.StartTime;
                var overall = srv.TotalProcessorTime;
                srv.Kill();
                ConsolePanel.Visible = false;
                //lblError.Text = String.Format("[LocalServer] Closed (TotalOn:{1},Start:{2})");
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

            if(chbChangePort.Checked)
            {
                sb.Append(" --port=" + txtPort.Text);
            }
            if(chbDistFolder.Checked)
            {
                sb.Append(" --folder=" + txtDistFolder.Text);
            }
            if(chbChangeMediaFolder.Checked)
            {
                sb.Append(" --media-folder=" + txtMediaFolder.Text);
            }
            if(chbDisable.Checked)
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
                    Application.DoEvents();
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


        public void NotyFi()
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

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var status = new LILO.JBO.StatusSender();
                if( await status.SendStatus(this) != "Error" )
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
            catch (Exception ex) {
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
    }
}


