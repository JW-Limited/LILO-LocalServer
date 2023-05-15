using System.Diagnostics;
using System.Net;
using System.Text;
using System.Net.Http;
using System.IO;
using LABLibary.Assistant;
using System.ComponentModel;
using srvlocal_gui.AppManager;
using srvlocal_gui.AppMananger;
using Guna.UI2.WinForms;
using User = srvlocal_gui.AppMananger.User;
using System.Security.Cryptography;

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
        public User logedInUser;

        public static void GreetUser(System.Windows.Forms.Label lbl)
        {
            DateTime currentTime = DateTime.Now;
            int currentHour = currentTime.Hour;

            if (currentHour >= 5 && currentHour < 12)
            {
                lbl.Text = ($"Guten morgen, {Environment.UserName}!");
            }
            else if (currentHour >= 12 && currentHour < 18)
            {
                lbl.Text = ($"Guten Tag, {Environment.UserName}!");
            }
            else if (currentHour >= 18 && currentHour < 22)
            {
                lbl.Text = ($"Guten Abend, {Environment.UserName}!");
            }
            else
            {
                lbl.Text = ($"Gute Nacht, {Environment.UserName}!");
            }
        }


        public static string VersionApp()
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(filePath);
            return versionInfo.ProductVersion;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            List<User> users = SettingsManager.Instance.GetSetting(settings => settings.Users);
            GreetUser(lblGreeting);
            try
            {
                foreach (var item in users)
                {
                    guna2ComboBox1.Items.Add(item.UserName);
                }

                guna2ComboBox1.Text = users.FirstOrDefault().UserName;
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, Logger.LogLevel.Error);
            }

            try
            {
                var quote = await Helper.GetQuoteOfTheDayAsync();

                try
                {
                    lblquote.Text = await Helper.TranslateTextAsync(quote, "de");
                }
                catch (Exception ex)
                {
                    Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);
                    lblquote.Text = quote;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);
                MessageBox.Show("The Server is not reachable or refused the connection.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);
                MessageBox.Show("Some Ressources are missing. Please Re-Install the Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.Browser_();
                this.Close();
            }


            LicenseEvaluation();
        }
        private void LicenseEvaluation()
        {
            try
            {
                Logger.Instance.Log("Starting license evaluation.");

                var license = LABLibary.Assistant.ReadLicense.Read(".\\license.labl");
                lblCode.Text = LicenseValues.Default.licCode;

                if (LicenseGenerator.DecodeLicense(license.Code, out string productName, out string productVersion, out DateTime expirationDate))
                {
                    lblExpires.Text = expirationDate.ToString();

                    if (expirationDate < DateTime.Now)
                    {
                        lblExpires.ForeColor = Color.Red;
                        MessageBox.Show("Your license has expired.", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblProduct.Text = license.Assembly.Name;
                        lblProductVersion.Text = license.Assembly.Version.ToString();
                        lbliv.Text = LicenseValues.Default.iv;
                        lblkey.Text = LicenseValues.Default.key;

                        if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("DebuggerMode") != "enabled")
                        {
                            this.Enabled = false;
                        }
                        else
                        {
                            lblProduct.Text = license.Assembly.Name;
                            lblProductVersion.Text = license.Assembly.Version.ToString();
                            lbliv.Text = LicenseValues.Default.iv;
                            lblkey.Text = LicenseValues.Default.key;
                        }
                        return;
                    }
                }
                else
                {
                    lblExpires.Text = "Invalid license code.";
                    lblExpires.ForeColor = Color.Red;
                    MessageBox.Show("Your license code is invalid.", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("DebuggerMode") != "enabled")
                    {
                        this.Enabled = false;
                    }
                    else
                    {
                        lblProduct.Text = license.Assembly.Name;
                        lblProductVersion.Text = license.Assembly.Version.ToString();
                        lbliv.Text = LicenseValues.Default.iv;
                        lblkey.Text = LicenseValues.Default.key;
                    }
                    return;
                }

                if (license.UserRightStatus.StartsWith("admin-rights_"))
                {
                    var splitRights = license.UserRightStatus.Split('_');
                    DebugSettings.Default.debug = splitRights.Length > 1 && splitRights[1].EndsWith("lilodev420");
                    DebugSettings.Default.Save();
                }
                else
                {
                    lblProduct.Text = license.Assembly.Name;
                    lblProductVersion.Text = license.Assembly.Version.ToString();
                    lbliv.Text = LicenseValues.Default.iv;
                    lblkey.Text = LicenseValues.Default.key;
                }

                lblProduct.Text = license.Assembly.Name;
                lblProductVersion.Text = license.Assembly.Version.ToString();
                lbliv.Text = LicenseValues.Default.iv;
                lblkey.Text = LicenseValues.Default.key;

                Logger.Instance.Log("License evaluation successful.");
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);
                MessageBox.Show(ex.Message, "License Activation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("DebuggerMode") != "enabled")
                {
                    this.Enabled = false;
                }

                return;
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
            try
            {
                var updater = Updater.Instance();

                var latestVersion = updater.GetLatestVersion(owner, repo);
                var latestChanges = updater.GetLatestChanges(owner, repo);
                var currentVersion = System.Windows.Forms.Application.ProductVersion;


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

                            Logger.Instance.Log("Started Updater (mode: MANUALY)", Logger.LogLevel.Info);

                            Task.Run(() =>
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    if (updater.HasNewRelease(owner, repo))
                                    {
                                        Logger.Instance.Log($"Updater found a new Version. Latest Version: {latestVersion}, Current Version: {currentVersion}.", Logger.LogLevel.Info);


                                        Console.WriteLine("A new release is available.");
                                        richTxtStatus.Text = $"A new release is available. \nYour Version : {currentVersion}\nLatest Version : {latestVersion}";
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
                                        Logger.Instance.Log($"Youre Up to date. Current Version: {currentVersion}.", Logger.LogLevel.Info);
                                        Console.WriteLine("No new release available.");
                                        richTxtStatus.Text = "No new release available.\nYou are perfect.";
                                    }
                                });

                            });
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, Logger.LogLevel.Error);
            }

        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var Proc = Process.Start("explorer.exe", "C:\\LILO\\dist");
        }

        public void RunConsoleApplication(string filePath)
        {
            var process = new Process();
            try
            {
                process.StartInfo.FileName = filePath;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.EnableRaisingEvents = true;
                process.OutputDataReceived += (sender, args) => _outputTextBox.Invoke(new Action(() => _outputTextBox.AppendText(args.Data + Environment.NewLine)));
                process.Exited += (sender, args) => NotyFi();
                process.Start();
                process.BeginOutputReadLine();
                NotyFi();
                var webClient = new WebClient();
                int attempts = 0;
                bool reachable = false;
                while (!process.HasExited)
                {
                    try
                    {
                        var response = webClient.DownloadString("http://localhost:8080");
                        reachable = true;
                        break;
                    }
                    catch (Exception)
                    {
                        if (++attempts > 10)
                        {
                            reachable = false;
                            break;
                        }
                        Thread.Sleep(5000);
                    }
                }
                lblReach.Invoke(new Action(() => lblReach.Text = reachable.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                process.Dispose();
            }
        }


        private async void bntStartCon(object sender, EventArgs e)
        {
            string filePath = ".\\srvlocal.exe";
            ConsolePanel.Visible = true;
            Program.Browser_("http://localhost:8080");

            try
            {
                var processes = Process.GetProcessesByName("srvlocal");
                foreach (var processs in processes)
                {
                    processs.Kill();
                    processs.WaitForExit();
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
                process.BeginOutputReadLine();

                NotyFi(icon: ToolTipIcon.Info, onClose: (sender, e) => { Console.WriteLine("Notification closed!"); });

                using (var httpClient = new HttpClient())
                {
                    while (process.HasExited == false)
                    {
                        await Task.Delay(1000);

                        try
                        {
                            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:8080");
                            if (response.IsSuccessStatusCode)
                            {
                                lblReach.Text = "True";
                                break;
                            }
                        }
                        catch (HttpRequestException)
                        {
                            lblReach.Text = "False";
                        }
                    }
                }

                ConsolePanel.Visible = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);
                MessageBox.Show(ex.Message);
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
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);

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
                Program.Browser_("http://localhost:" + txtPort.Text);
                ConsolePanel.Visible = true;
            }
            catch (Exception ey)
            {
                Logger.Instance.Log(ey.Message, logLevel: Logger.LogLevel.Error);
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
            return 1;
        }


        public void NotyFi(bool inTray = false, string message = null, string title = null, ToolTipIcon icon = ToolTipIcon.None, EventHandler onClick = null, EventHandler onClose = null)
        {
            var balloonTipText = message ?? $"LocalHost is Running...\nVersion : {VersionApp()}\nPing : {PingServer("http://127.0.0.1:8080")}ms";
            var balloonTipTitle = title ?? "Started Succesfully";

            if (inTray)
            {
                noty = new NotifyIcon()
                {
                    BalloonTipText = balloonTipText,
                    BalloonTipTitle = balloonTipTitle,
                    BalloonTipIcon = icon,

                    Text = "Manages the DesktopClient.",

                    Icon = this.Icon,
                    ContextMenuStrip = inTrayCon
                };
            }
            else
            {
                noty = new NotifyIcon()
                {
                    BalloonTipText = balloonTipText,
                    BalloonTipTitle = balloonTipTitle,
                    BalloonTipIcon = icon,

                    Text = "Manages the DesktopClient.",

                    Icon = this.Icon,
                    ContextMenuStrip = conMenu
                };

                if (onClick != null)
                {
                    noty.BalloonTipClicked += onClick;
                }
            }

            noty.Tag = "STATUS";
            noty.Events();
            noty.Visible = true;

            if (onClose != null)
            {
                noty.BalloonTipClosed += onClose;
            }

            noty.ShowBalloonTip(1000);
        }



        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            var statusSender = new LILO.JBO.StatusSender();
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            try
            {
                var responseTask = statusSender.SendStatus(cancellationToken);
                var response = await responseTask;
                if (response != "Error")
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
                Logger.Instance.Log(ex.Message, Logger.LogLevel.Warning);
                //MessageBox.Show(ex.Message);
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
            if (true)
            {
                MessageBox.Show("You downloaded youre Version from Github thats why the LAB is not activated.", "Activation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                var setup = new Setup();
                setup.Show();
            }


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

        private void guna2ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                HandleUserChange(ref logedInUser);

                if (logedInUser is not User)
                {
                    pnlControls.Enabled = false;
                    guna2ComboBox1.Text = "none";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "User Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                guna2ComboBox1_SelectedValueChanged(sender, e);
            }
        }

        private User GetSelectedUser()
        {
            var selectedUsername = guna2ComboBox1.Text;
            var users = SettingsManager.Instance.GetSetting(settings => settings.Users);
            return users.FirstOrDefault(u => u.UserName == selectedUsername);
        }



        public void HandleUserChange(ref User loggedIn)
        {
            var settings = SettingsManager.Instance.LoadSettings();
            User selectedUser = settings.Users.FirstOrDefault(u => u.UserName == guna2ComboBox1.Text);

            if (selectedUser != null)
            {
                if (!selectedUser.IsActivated)
                {
                    throw new Exception("The user isnt activated right now.");
                }
                else
                {
                    //passwordDialog.UsePasswordMasking = false;
                    passwordDialog.WindowTitle = $"Login: {selectedUser.UserName}";

                    if (passwordDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (Helper.ComputeHash(passwordDialog.Input) == selectedUser.HashedPassword)
                        {
                            lblInformationAboutUser.Text = $"Email: {selectedUser.Email}";

                            if (pnlControls.Enabled != selectedUser.CanChangeConfig)
                            {
                                pnlControls.Enabled = selectedUser.CanChangeConfig;
                            }

                            loggedIn = selectedUser;
                        }
                        else
                        {
                            throw new Exception($"Password for {selectedUser.UserName} is false. Please provide another password.");
                        }
                    }
                    else
                    {
                        guna2ComboBox1.Text = "none";
                    }

                }

            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = srvlocal_gui_settings.Instance;
                settings._settings = SettingsManager.Instance.LoadSettings();
                settings._loggedInUser = logedInUser;
                settings.Show();
                settings.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


