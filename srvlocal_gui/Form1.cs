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
using System.Runtime.CompilerServices;
using System;
using Octokit;
using System.Globalization;
using srvlocal_gui.LAB.SETTINGS;
using Telerik.Windows.Documents.Spreadsheet.Model.ConditionalFormattings;
using static srvlocal_gui.ProjectFile;

namespace srvlocal_gui
{
    public partial class Form1 : Form
    {
        private static Form1 _instance;
        public static object _lock = new object();

        /// <summary>
        /// Gives back the current Instance
        /// </summary>

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

        #region Variables

        /// <summary>
        /// A private Form builder
        /// </summary>
        /// <param name="args"></param>

        private Form1(string args = null)
        {
            InitializeComponent();
        }

        NotifyIcon noty;
        private static object _lockRequest = new object();
        public static string filePath = ".\\srvlocal.exe";
        public static Process? consoleHandle;
        public string owner = "JW-Limited";
        public string repo = "LILO-LocalServer";
        public bool UpdateDetected = false;
        public User logedInUser;
        public bool loggedInApi = false;

        // Information from LicenseFile

        public string BuildChannel = null;
        public string LicenseScheme = null;
        public bool DeveloperMode = false;
        public string UserRight = null;

        #endregion

        #region API Handler


        public void APILoginHandler(bool LoggedInSuccessfully)
        {
            if (LoggedInSuccessfully)
            {
                var appin = FileViewForm.Instance(null, WebViewFormMode.ProtectedLoginMode);
                appin.Close();
                loggedInApi = true;
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
                loggedInApi = true;
                lblquote.Text = "API Endpoint: Unlocked Enviroment.";
                guna2Button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Wrong Login Credentials.\n\n After you close the dialog the Server will shut down and decline youre requests.", "Authorization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        #endregion

        #region Startup Oprerations

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
            foreach (var button in allbuttons)
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
                Program.Browser_(startInLocalBrowser: true);
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

        #endregion

        #region License Evaluation

        private void LicenseEvaluation()
        {
            try
            {
                Logger.Instance.Log("Starting license evaluation.");

                var license = LABLibary.Assistant.ReadLicense.Read(".\\license.labl");
                lblCode.Text = "Encrypted";
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
                        Logger.Instance.Log(decoderesult.Info + decoderesult.Message + decoderesult.ErrorMessage, Logger.LogLevel.Error);
                        //this.Enabled = false;
                        RetryWithSavedValues();

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
                    try
                    {

                        var license = LABLibary.Assistant.ReadLicense.Read(".\\license.labl");

                        string[] parts = LicenseValues.Default.licCode.Split('|');

                        var productName = parts[0];
                        var productVersion = parts[1];
                        var expirationDate = DateTime.Now;
                        DateTime.TryParseExact(parts[2], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out expirationDate);
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

                        lblExpires.ForeColor = Color.Green;

                        lblProduct.Text = license.Assembly.Name;
                        lblProductVersion.Text = license.Assembly.Version.ToString();
                        lbliv.Text = LicenseValues.Default.iv;
                        lblkey.Text = LicenseValues.Default.key;

                        Logger.Instance.Log("License evaluation successful.");
                    }
                    catch (Exception ewx)
                    {
                        Logger.Instance.Log(ewx.Message, logLevel: Logger.LogLevel.Error);
                        MessageBox.Show(ewx.Message);
                    }
                }

                return;
            }
        }

        private void RetryWithSavedValues()
        {
            try
            {

                if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("DebuggerMode") != "enabled")
                {
                    try
                    {

                        var license = LABLibary.Assistant.ReadLicense.Read(".\\license.labl");

                        string[] parts = LicenseValues.Default.licCode.Split('|');

                        var productName = parts[0];
                        var productVersion = parts[1];
                        var expirationDate = DateTime.Now;
                        DateTime.TryParseExact(parts[2], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out expirationDate);
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

                        lblExpires.ForeColor = Color.Green;

                        lblProduct.Text = license.Assembly.Name;
                        lblProductVersion.Text = license.Assembly.Version.ToString();
                        lbliv.Text = LicenseValues.Default.iv;
                        lblkey.Text = LicenseValues.Default.key;

                        Logger.Instance.Log("License evaluation successful.");
                    }
                    catch (Exception ewx)
                    {
                        Logger.Instance.Log(ewx.Message, logLevel: Logger.LogLevel.Error);
                        MessageBox.Show(ewx.Message);
                    }
                }

                return;
            }
            catch (Exception ewx)
            {
                Logger.Instance.Log(ewx.Message, logLevel: Logger.LogLevel.Error);
                MessageBox.Show(ewx.Message);
            }
        }

        #endregion

        #region Updates

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

        #endregion

        /// <summary>
        /// The Modes for the OpenInApp Method
        /// </summary>

        public enum ChildrenUse
        {
            Auth,
            WebView,
            NormalForm
        }



        private Form currentOpenedApp;

        /// <summary>
        /// This Method accpets a WinForm object and 
        /// displays it over all controls with help of
        /// a Panel
        /// </summary>
        /// <param name="children">
        /// The Form Object
        /// </param>
        /// <param name="FormName">
        /// The displayed Formname
        /// </param>
        /// <param name="usage">
        /// The Mode and Accessability clarifier
        /// </param>

        public void OpenInApp(Form children, string FormName = null, ChildrenUse usage = ChildrenUse.WebView)
        {

            if (children == currentOpenedApp) return;

            if (currentOpenedApp is not null)
            {
                currentOpenedApp.Close();
            }


            this.IsMdiContainer = true;
            this.BackColor = Color.White;

            children.MdiParent = this;
            pnlChild.Controls.Add(children);
            pnlChild.Dock = DockStyle.Fill;
            pnlChild.BringToFront();

            if (usage == ChildrenUse.Auth)
            {
                children.MaximizeBox = false;
                children.MinimizeBox = false;
                children.ControlBox = false; 
                children.FormBorderStyle = FormBorderStyle.None;
            }
            else if(usage == ChildrenUse.WebView)
            {
                children.FormBorderStyle = FormBorderStyle.Sizable;
                children.MaximizeBox = false;
                children.MinimizeBox = false;
            }
            else if (usage == ChildrenUse.NormalForm)
            {
                children.FormBorderStyle = FormBorderStyle.Sizable;
                children.MaximizeBox = false;
                children.MinimizeBox = false;
                this.Size = children.Size;
            }

            children.Dock = DockStyle.Fill;

            if (FormName is not null or "") children.Text = FormName;

            Text = SettingsManager.Instance.GetSetting(settings => settings.WindowTitle, "LILO Localserver") + " - " + children.Text;

            children.Show();

            currentOpenedApp = children;

            currentOpenedApp.FormClosing += (sender, e) =>
            {
                this.IsMdiContainer = false;
                this.BackColor = Color.White;
                pnlChild.Dock = DockStyle.None;
                Text = SettingsManager.Instance.GetSetting(settings => settings.WindowTitle, "LILO Localserver");
                pnlChild.Size = new Size(1, 1);
            };
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (config.Default.useNewUI)
            {
                var project = FileViewForm.Instance($"http://localhost:{txtPort.Text}", WebViewFormMode.AuthorizedProjectManagment);

                try
                {
                    OpenInApp(project, "Explorer");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var project = FileViewForm.Instance($"http://localhost:{txtPort.Text}", WebViewFormMode.AuthorizedProjectManagment);

                try
                {
                    project.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Runs a CLI Application in background and gives back the output
        /// </summary>
        /// <param name="filePath"></param>

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

                var connected = await TestConnectionToLocalServer(process);

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

        private async Task<bool> TestConnectionToLocalServer(Process process)
        {
            bool isReachabel = false;

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
                            isReachabel = true;
                            break;
                        }
                    }
                    catch (HttpRequestException)
                    {
                        lblReach.Text = "False";
                        isReachabel = false;
                    }
                }

                return isReachabel;
            }
        }

        /// <summary>
        /// Makes a get request to a Server
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>

        public string MakeGetRequest(string url)
        {
            lock (_lockRequest)
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

        private async void bntStartWithArguments(object sender, EventArgs e)
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

                Program.Browser_($"http://localhost:{txtPort.Text}/api/login", false);

                var connected = await TestConnectionToLocalServer(process);

                while (process.HasExited == false)
                {
                    System.Windows.Forms.Application.DoEvents();
                    process.WaitForExitAsync();
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

        /// <summary>
        /// Displays a Notify Icon on the Taskbar
        /// </summary>
        /// <param name="inTray"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="onClick"></param>
        /// <param name="onClose"></param>

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


            try
            {
                setup.Show();

                setup.FormClosing += (sender, e) =>
                {
                    if (setup.projectCreated)
                    {
                        this.ShowInTaskbar = false;
                        this.ShowIcon = false;
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                };

                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                SettingsManager.Instance.SetSetting((s, v) => s.CustomCDNConfig = v, true);
                SettingsManager.Instance.SetSetting((s, v) => s.CDNPath = v, txtDistFolder.Text);
            }
            else
            {
                SettingsManager.Instance.SetSetting((s, v) => s.CustomCDNConfig = v, false);
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

        /// <summary>
        /// Handles the User login change
        /// </summary>
        /// <param name="loggedIn"></param>
        /// <exception cref="Exception"></exception>

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
                            System.Windows.Forms.Application.ExitThread();
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



    }
}


