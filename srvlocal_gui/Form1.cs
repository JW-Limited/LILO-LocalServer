using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace srvlocal_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


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
                    foreach (var prockill in Process.GetProcessesByName("lghcon"))
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
                var login = new Login();
                login.ShowDialog();
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

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ConsolePanel.Visible = false;
        }

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
                    foreach (var prockill in Process.GetProcessesByName("lghcon"))
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
                var login = new Login();
                login.ShowDialog();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var login = new Login()
            {

            };
            login.ShowDialog();
        }
    }
}


