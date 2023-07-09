using srvlocal_gui.LAB;
using srvlocal_gui.Properties;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using LABLibary.Connect;
using DarkUI;
using Zeroit.Framework.Metro;
using LABLibary.Network;
using System.ComponentModel;
using srvlocal_gui.AppMananger;
using LABLibary.Forms;
using System.Net;
using srvlocal_gui.LAB.SETTINGS;

namespace srvlocal_gui
{
    internal static class Program
    {

        /// <summary>
        ///  The main debug ErrorManager.
        /// </summary>
        #region ErrorManager

        public static List<string> ErrorList = new List<string>();
        public static bool RestartTrue = false;

        private const string SettingsFileName = "settings.json";

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            var errorMessage = GetDetailedErrorMessage(exception);

            AddErrorMessageToList(errorMessage);
            LogErrorMessage(errorMessage);
            AddErrorToErrorManager(errorMessage);
            ShowErrorDialog();
        }

        private static string GetDetailedErrorMessage(Exception exception)
        {
            var errorMessage = new StringBuilder();

            errorMessage.AppendLine("An unhandled exception occurred:");
            errorMessage.AppendLine($"Exception Type: {exception.GetType().Name}");
            errorMessage.AppendLine($"Message: {exception.Message}");
            errorMessage.AppendLine("Stack Trace:");
            errorMessage.AppendLine(exception.StackTrace);

            // Additional exception details
            errorMessage.AppendLine("Additional Details:");

            if (exception.Data.Count > 0)
            {
                errorMessage.AppendLine("Data:");

                foreach (var key in exception.Data.Keys)
                {
                    errorMessage.AppendLine($"{key}: {exception.Data[key]}");
                }
            }

            if (exception.TargetSite != null)
            {
                errorMessage.AppendLine($"Target Site: {exception.TargetSite.Name} ({exception.TargetSite.Module})");
            }

            if (exception.HelpLink != null)
            {
                errorMessage.AppendLine($"Help Link: {exception.HelpLink}");
            }

            if (exception.Source != null)
            {
                errorMessage.AppendLine($"Source: {exception.Source}");
            }

            if (exception.StackTrace != null)
            {
                // Additional stack trace information, such as line numbers
                var stackTrace = new StackTrace(exception, true);

                errorMessage.AppendLine("Stack Trace Details:");

                foreach (var frame in stackTrace.GetFrames())
                {
                    var method = frame.GetMethod();
                    var line = frame.GetFileLineNumber();

                    errorMessage.AppendLine($"Method: {method.Name} ({method.Module})");
                    errorMessage.AppendLine($"Line: {line}");
                }
            }

            if (exception.InnerException != null)
            {
                errorMessage.AppendLine("Inner Exception:");
                errorMessage.AppendLine($"Exception Type: {exception.InnerException.GetType().Name}");
                errorMessage.AppendLine($"Message: {exception.InnerException.Message}");
                errorMessage.AppendLine("Stack Trace:");
                errorMessage.AppendLine(exception.InnerException.StackTrace);

                // Additional inner exception details
                errorMessage.AppendLine("Inner Exception Details:");

                if (exception.InnerException.Data.Count > 0)
                {
                    errorMessage.AppendLine("Inner Exception Data:");

                    foreach (var key in exception.InnerException.Data.Keys)
                    {
                        errorMessage.AppendLine($"{key}: {exception.InnerException.Data[key]}");
                    }
                }

                if (exception.InnerException.TargetSite != null)
                {
                    errorMessage.AppendLine($"Inner Exception Target Site: {exception.InnerException.TargetSite.Name} ({exception.InnerException.TargetSite.Module})");
                }

                if (exception.InnerException.HelpLink != null)
                {
                    errorMessage.AppendLine($"Inner Exception Help Link: {exception.InnerException.HelpLink}");
                }

                if (exception.InnerException.Source != null)
                {
                    errorMessage.AppendLine($"Inner Exception Source: {exception.InnerException.Source}");
                }

                if (exception.InnerException.StackTrace != null)
                {
                    // Additional inner exception stack trace information, such as line numbers
                    var innerStackTrace = new StackTrace(exception.InnerException, true);

                    errorMessage.AppendLine("Inner Exception Stack Trace Details:");

                    foreach (var frame in innerStackTrace.GetFrames())
                    {
                        var method = frame.GetMethod();
                        var line = frame.GetFileLineNumber();

                        errorMessage.AppendLine($"Method: {method.Name} ({method.Module})");
                        errorMessage.AppendLine($"Line: {line}");
                    }
                }
            }

            return errorMessage.ToString();
        }




        private static void AddErrorMessageToList(string errorMessage)
        {
            ErrorList.Add(errorMessage);
        }

        private static void LogErrorMessage(string errorMessage)
        {
            Logger.Instance.Log(errorMessage, logLevel: Logger.LogLevel.Warning);
        }

        private static void AddErrorToErrorManager(string errorMessage)
        {
            LABLibary.Forms.ErrorDialog.ErrorManager.AddError(errorMessage, true, "this.Program");
        }

        [MTAThread]
        private static void ShowErrorDialog()
        {
            LABLibary.Forms.ErrorDialog.Show();
        }

        #endregion

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Logger.Instance.LogConsoleOutput();
            Logger.Instance.Log("Started GUI...");

            Prerequisite();

            if (Enum.TryParse(Helper.User.CheckUserPermissions(), out Helper.User._UserRights userRights))
            {
                Console.WriteLine(SettingsManager.Instance.GetSetting(settings => settings.WindowTitle, "default value"));
                ApplicationConfiguration.Initialize();
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                
                AutoGenerators.ShowReadMeDialog();
                bool startWithNoWindow = false;

                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "--start":
                            startWithNoWindow = true;
                            break;
                        case "--nowin":
                            startWithNoWindow = false;
                            break;
                        case "--help":
                            InfoDialog.Show(AutoGenerators.ShowHelp(), "Help - Or visit US");
                            return;
                        case "--version":
                            InfoDialog.Show(AutoGenerators.ShowVersion(), "Version");
                            return;
                        default:
                            OpenBuilderGui(arg);
                            break;
                    }
                }

                if (startWithNoWindow)
                {
                    StartSrvLocalProcess(true);
                    var arg = new ArgStart(true);
                    arg.Show();
                    Application.Run();
                }
                else
                {
                    OpenBuilderGui("");
                }
            }
        }

        internal static void Prerequisite()
        {
            GenerateDirectoryContents("C:\\LILO\\dist");
            GenerateDirectoryContents("C:\\LILO\\req");
            GenerateDirectoryContents("C:\\LILO\\host");

            if (!File.Exists(Path.Combine("C:\\LILO\\host",SettingsFileName)))
            {
                Logger.Instance.Log("Settings file was not found. Initializing SettingsManager and generating it.");

                var admin = new User(Environment.UserName, "admin")
                {
                    CanChangeConfig = true,
                    Email = "ceo@jwlmt.com",
                    FavouriteColor = Color.AliceBlue,
                    ButtonColor = Color.FromArgb(94, 148, 255)
                };

                var guest = new User("guest", "none")
                {
                    CanChangeConfig = false,
                    Email = "guest@jwlmt.com",
                    FavouriteColor = Color.Azure,
                    ButtonColor = Color.FromArgb(94, 148, 255)
                };

                List<User> listUser = new List<User>
                {
                    admin,
                    guest
                };

                SettingsManager.Instance.UpdateSettings(new Settings
                {
                    WindowTitle = "LILO-LocalServer",
                    ProductVersion = 1,
                    InstalledCorrectly = true,
                    CustomPortConfig = false,
                    CustomCDNConfig = false,
                    Port = 8080,
                    CDNPath = "C:\\LILO\\dist",
                    Users = listUser
                });
            }
        }

        private static void OpenBuilderGui(string arg)
        {
            if (!CheckIfDirIsValid())
            {
                StringBuilder sb = new StringBuilder();
                foreach (var files in GetMissingFiles())
                {
                    sb.AppendLine("+-> " + files);
                }
                CreateDirectoryIfNotExists();
                MessageBox.Show("The Program detected that some Resources maybe Missing or arent in the specified installation directory:\n\n" + sb + "\nPlease contact the support if you run in errors while using the program.", "Missing Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Task.Run(() =>
                {
                    StringBuilder sb3 = new StringBuilder();
                    foreach (var files in GetMissingFiles())
                    {
                        sb3.Append(" " + files + ",");
                    }

                    Logger.Instance.Log("Missing resources :" + sb3.ToString(), Logger.LogLevel.Warning);
                    //Browser_();
                });
            }

            var startedForm = new Form();
            if (DebugSettings.Default.debug)
            {
                switch (DebugSettings.Default.debugForm)
                {
                    default:
                        startedForm = Form1.Instance /*(arg)*/;
                        break;
                    case "builder":
                        builder_gui.Instance(arg);
                        break;
                }
            }
            else
            {
                if(File.Exists(arg))
                {
                    startedForm = builder_gui.Instance(arg);
                }
                else
                {
                    startedForm = Form1.Instance /*(arg)*/;
                }
            }

            Application.Run(startedForm);
        }

        private static void StartSrvLocalProcess(bool noWindow)
        {
            var processName = config.Default.srvlocal_path;
            var isProcessRunning = Process.GetProcessesByName(processName).Length > 0;

            if (!isProcessRunning)
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = config.Default.srvlocal_path,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = noWindow,
                    }
                };
                process.Start();
            }
        }

        public static void SaveRestart()
        {
            try
            {
                var settings = SettingsManager.Instance.LoadSettings();

                string url = $"http://localhost:{settings.Port}/api/com?command=close&key=liloDev-420";
                string response = MakeGetRequest(url);

                if (response != null)
                {
                    Logger.Instance.Log(response);

                    var proc = new Process();
                    proc.StartInfo = new ProcessStartInfo()
                    {
                        FileName = ".\\srvlocal_gui.exe"
                    };

                    proc.Start();
                    Application.ExitThread();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, logLevel: Logger.LogLevel.Error);
            }
        }

        public static void GenerateDirectoryContents(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Logger.Instance.Log("Directory allready satisfied.");
                return;
            }

            string[] directories = directoryPath.Split(Path.DirectorySeparatorChar);

            string currentPath = "";
            foreach (string directory in directories)
            {
                currentPath = Path.Combine(currentPath, directory);
                if (!Directory.Exists(currentPath))
                {
                    Logger.Instance.Log("Generated directory: " + currentPath);
                    Directory.CreateDirectory(currentPath);
                }
            }
        }

        private static object _lockRequest = new object();

        public static string MakeGetRequest(string url)
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

        public static bool CheckIfDirIsValid()
        {
            string[] requiredFiles = { "srvlocal.exe", "srvlocal.dll", "srvlocal.runtimeconfig.json"};
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return requiredFiles.All(file => File.Exists(Path.Combine(baseDirectory, file)));
        }

        public static void DeleteFiles()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            foreach (string file in Directory.GetFiles(baseDirectory))
            {
                File.Delete(file);
            }
        }

        public static void CreateDirectoryIfNotExists()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
        }

        public static List<string> GetMissingFiles()
        {
            string[] requiredFiles = { "srvlocal.exe", "srvlocal.dll", "srvlocal.runtimeconfig.json" };
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return requiredFiles.Where(file => !File.Exists(Path.Combine(baseDirectory, file))).ToList();
        }

        

        public static void Browser_(string url = "https://github.com/JW-Limited/LILO-LocalServer", bool startInLocalBrowser = true)
        {
            if(startInLocalBrowser) {
                try
                {
                    Process.Start(url);
                }
                catch (Win32Exception)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        url = url.Replace("&", "^&");
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {url}")
                        {
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            ErrorDialog = false
                        });
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        Process.Start("xdg-open", url);
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        Process.Start("open", url);
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }
                }
            }
            else
            {
                var inapp = FileViewForm.Instance(url);
                inapp.ShowDialog();
            }
        }

    }
}

