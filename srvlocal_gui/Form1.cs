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
using ToastNotifications;
using ToastNotifications.Core;

namespace srvlocal_gui
{
    public partial class Form1 : Form
    {
        private static Form1 _instance;
        public static object _lock = new object();
        public static Form1 Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Form1();
                    }

                    return _instance;
                }
            }
        }

        private Form1(string args = null)
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

        // Information from LicenseFile

        public string BuildChannel = null;
        public string LicenseScheme = null;
        public bool DeveloperMode = false;
        public string UserRight = null;

        public static void GreetUser(System.Windows.Forms.Label lbl, User user)
        {
            var username = user.UserName;
            DateTime currentTime = DateTime.Now;
            int currentHour = currentTime.Hour;
            //Form1.Instance.headerLeft.FillColor = user.FavouriteColor;
            //Form1.Instance.headerRight.FillColor = user.FavouriteColor;

            Guna2Button[] allbuttons = new Guna2Button[]
            {
                Instance.bntCheck,
                Instance.bntOpen,
                Instance.bntServerStatus,
            };

            //ColorAllButtons(allbuttons, user);

            if (currentHour >= 5 && currentHour < 12)
            {
                lbl.Text = ($"Guten morgen, {username}!");
            }
            else if (currentHour >= 12 && currentHour < 18)
            {
                lbl.Text = ($"Guten Tag, {username}!");
            }
            else if (currentHour >= 18 && currentHour < 22)
            {
                lbl.Text = ($"Guten Abend, {username}!");
            }
            else
            {
                lbl.Text = ($"Gute Nacht, {username}!");
            }
        }

        public static void ColorAllButtons(Guna2Button[] allbuttons, User user)
        {
            foreach(var button in allbuttons)
            {
                button.BackColor = user.ButtonColor;
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
            GreetUser(lblGreeting, users.FirstOrDefault());

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

            /*
            Settings setting()
            {
                return SettingsManager.Instance.LoadSettingsAsync().Result;
            }
            */

            Worker.AppDomainWorker.Instance.PerformWorkInAppDomain(out string domain);

            lblDomain_2.Text = domain;
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
                Program.Browser_(startInLocalBrowser:true);
                this.Close();
            }


            try
            {
                await CheckForUpdates(UpdateMode.Automatic);
                LicenseEvaluation();

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

        }

        public void RefreshUserList()
        {
            List<User> users = SettingsManager.Instance.GetSetting(settings => settings.Users);
            GreetUser(lblGreeting, users.FirstOrDefault());

            try
            {
                guna2ComboBox1.Items.Clear();

                foreach (var item in users)
                {
                    guna2ComboBox1.Items.Add(item.UserName);
                }

                guna2ComboBox1.Text = logedInUser.UserName;
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, Logger.LogLevel.Error);
            }
        }

        private void LicenseEvaluation()
        {
            try
            {
                Logger.Instance.Log("Starting license evaluation.");

                var license = LABLibary.Assistant.ReadLicense.Read(".\\license.labl");
                lblCode.Text = LicenseValues.Default.licCode;
                var decoderesult = LicenseGenerator.DecodeLicense(license.Code, out string productName, out string productVersion, out DateTime expirationDate);


                if (decoderesult.SuccessFull)
                {
                    lblExpires.Text = expirationDate.ToString();

                    if (expirationDate < DateTime.Now)
                    {
                        lblExpires.ForeColor = Color.Red;


                        if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("DebuggerMode") != "enabled")
                        {
                            this.Enabled = false;
                            MessageBox.Show("Your license has expired.", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        lblProduct.Text = license.Assembly.Name;
                        lblProductVersion.Text = license.Assembly.Version.ToString();
                        lbliv.Text = LicenseValues.Default.iv;
                        lblkey.Text = LicenseValues.Default.key;

                        return;
                    }
                }
                else
                {
                    lblExpires.Text = "Invalid license code.";
                    lblExpires.ForeColor = Color.Red;
                    if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("DebuggerMode") != "enabled")
                    {
                        MessageBox.Show(decoderesult.Info +  decoderesult.Message + decoderesult.ErrorMessage, "License Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public Task CheckForUpdates(UpdateMode mode = UpdateMode.Manual)
        {
            try
            {
                var updater = Updater.Instance();

                var latestVersion = updater.GetLatestVersion(owner, repo);
                var latestChanges = updater.GetLatestChanges(owner, repo);
                var currentVersion = System.Windows.Forms.Application.ProductVersion;

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

                        Logger.Instance.Log($"Started Updater (mode: {mode.ToString()})", Logger.LogLevel.Info);

                        Task.Run(() =>
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                if (updater.HasNewRelease(owner, repo))
                                {
                                    Logger.Instance.Log($"Updater found a new Version. Latest Version: {latestVersion}, Current Version: {currentVersion}.", Logger.LogLevel.Info);


                                    Console.WriteLine("A new release is available.");

                                    NotyFi(false, $"A new release is available. \nYour Version : {currentVersion}\nLatest Version : {latestVersion}", "Updater");

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
                                    richTxtStatus.Text = "";

                                    NotyFi(false, $"No new release available.\nYou are perfect.", "Updater");
                                }
                            });

                        });
                        break;
                }

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, Logger.LogLevel.Error);
                return Task.CompletedTask;
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
            Program.Browser_(startInLocalBrowser: true);
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
            var webClient = new WebClient();
            int attempts = 0;
            bool reachable = false;

            try
            {
                process.StartInfo.FileName = filePath;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.EnableRaisingEvents = true;
                process.OutputDataReceived += (sender, args) =>
                {
                    _outputTextBox.Invoke(new Action(() => _outputTextBox.AppendText(args.Data + Environment.NewLine)));
                };
                process.Exited += (sender, args) => NotyFi();
                process.Start();
                process.BeginOutputReadLine();
                NotyFi();

                while (!process.HasExited)
                {
                    try
                    {
                        var response = webClient.DownloadString("http://localhost:8080");
                        reachable = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (++attempts > 10)
                        {
                            _outputTextBox.Text += "Error : " + ex.Message;

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

                process.OutputDataReceived += (sender, args) => _outputTextbox.Invoke(new Action(() => _outputTextbox.AppendText(args.Data + Environment.NewLine)));
                process.Start();
                process.BeginOutputReadLine();

                NotyFi(icon: ToolTipIcon.Info, onClose: (sender, e) => { Console.WriteLine("Notification closed!"); });

                Program.Browser_("http://localhost:8080/api/login", false);

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

                try
                {
                    string url = $"http://localhost:{txtPort.Text}/api/com?command=status&key=liloDev-420";
                    string response = MakeGetRequest(url);

                    if (response != null)
                    {
                        lblquote.Text = ("API Endpoint : " + response);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);

                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);
                MessageBox.Show(ex.Message);
            }
        }

        

        private static object _lockRequest = new object();

        public string MakeGetRequest(string url)
        {
            lock(_lockRequest)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        string response = client.DownloadString(url);
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    return $"Error occurred while making the GET request: {ex.Message}";
                }
            }
        }

        public async void guna2Button6_Click(object sender, EventArgs e)
        {
            ConsolePanel.Visible = false;

            try
            {
                string url = $"http://localhost:{txtPort.Text}/api/com?command=close&key=liloDev-420";
                string response = MakeGetRequest(url);

                if (response != null)
                {
                    lblquote.Text = ("API Endpoint : " + response);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);

            }


            ConsolePanel.Visible = false;
        }

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

                process.OutputDataReceived += (sender, args) => _outputTextbox.Invoke(new Action(() => _outputTextbox.AppendText(args.Data + Environment.NewLine)));
                process.Start();
                process.BeginOutputReadLine();
                while (process.HasExited == false)
                {
                    System.Windows.Forms.Application.DoEvents();
                    process.WaitForExitAsync();
                }
                Program.Browser_("http://localhost:" + txtPort.Text + "/api/login",false);
                ConsolePanel.Visible = true;

                try
                {
                    string url = $"http://localhost:{txtPort.Text}/api/com?command=status&key=liloDev-420";
                    string response = MakeGetRequest(url);

                    if (response != null)
                    {
                        lblquote.Text = ("API Endpoint : " + response);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);

                }
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
            var conEmu = ConsoleEmu.Instance();
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
            var setup = Setup.Instance(logedInUser);
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
                if (!selectedUser.IsActivated) throw new Exception("The user isnt activated right now.");

                if (selectedUser.HashedPassword == User.ComputeHash("none"))
                {
                    pnlControls.Enabled = selectedUser.CanChangeConfig;
                    loggedIn = selectedUser;
                }

                else
                {
                    passwordDialog.WindowTitle = $"Login: {selectedUser.UserName}";

                    if (passwordDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (Helper.ComputeHash(passwordDialog.Input) == selectedUser.HashedPassword)
                        {

                            pnlControls.Enabled = selectedUser.CanChangeConfig;
                            loggedIn = selectedUser;

                            RefreshUserGreeting(loggedIn);
                        }
                        else
                        {
                            try
                            {
                                guna2ComboBox1.Text = loggedIn.UserName;
                            }
                            catch { }
                            throw new Exception($"Password for {selectedUser.UserName} is false. Please provide another password.");
                        }
                    }
                    else
                    {
                        try
                        {
                            guna2ComboBox1.Text = loggedIn.UserName + "none";
                        }
                        catch
                        {
                            Application.ExitThread();
                        }
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

        private void bntAddUSer(object sender, EventArgs e)
        {
            try
            {
                var addUserHost = AddUser.Instance(logedInUser);
                addUserHost.Show();
                addUserHost.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshUserGreeting(User newUser)
        {
            GreetUser(lblGreeting, newUser);
        }

        private void bntServerStatusClick(object sender, EventArgs e)
        {
            string url = $"http://localhost:{txtPort.Text}/api/com?command=info&key=liloDev-420";
            string response = MakeGetRequest(url);

            if (response != null)
            {
                LABLibary.Forms.AsyncMessageBox.Show("API Endpoint: \n\n" + response, "ServerResponse");
            }
        }

        private void _outputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool loggedInApi = false;

        public void APILoginHandler(bool LoggedInSuccessfully)
        {
            if(LoggedInSuccessfully)
            {
                var appin = FileViewForm.Instance(null);
                appin.Close();
                loggedInApi = !loggedInApi;
            }
            else
            {
                MessageBox.Show("Wrong API Credentials.");
            }
        }

        public void APILoginHandler_Closing(bool LoggedInSuccessfully)
        {
            if (LoggedInSuccessfully)
            {
                var appin = FileViewForm.Instance(null);
                appin.Close();
                loggedInApi = !loggedInApi;
                lblquote.Text = "API Endpoint: Unlocked Enviroment.";
            }
            else
            {
                MessageBox.Show("Wrong API Credentials.");

                ConsolePanel.Visible = false;

                try
                {
                    string url = $"http://localhost:{txtPort.Text}/api/com?command=close&key=liloDev-420";
                    string response = MakeGetRequest(url);

                    if (response != null)
                    {
                        lblquote.Text = ("API Endpoint : " + response);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);

                }


                ConsolePanel.Visible = false;
            }
        }

    }
}


