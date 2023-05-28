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
using Telerik.WinControls.UI.Map.Bing;
using Google.Apis.Gmail.v1.Data;
using srvlocal_gui.AppMananger;
using LABLibary.Forms;

namespace srvlocal_gui
{
    internal static class Program
    {
        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
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

        private static void ShowErrorDialog()
        {
            LABLibary.Forms.ErrorDialog.Show();
        }
 


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Logger.Instance.LogConsoleOutput();
            Logger.Instance.Log("Started GUI...");

            if (!File.Exists(SettingsFileName))
            {
                Logger.Instance.Log("Settings file was not found. Initializing SettingsManager and generating it.");

                var admin = new User("Joey West", "admin")
                {
                    CanChangeConfig = true,
                    Email = "ceo@jwlmt.com"
                };

                var guest = new User("guest", "none")
                {
                    CanChangeConfig = false,
                    Email = "guest@jwlmt.com"
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

            if (Enum.TryParse(Helper.User.CheckUserPermissions(), out Helper.User._UserRights userRights))
            {
                Console.WriteLine(SettingsManager.Instance.GetSetting(settings => settings.WindowTitle, "default value"));

                ApplicationConfiguration.Initialize();
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                if (!File.Exists(".\\license.labl") && !LAB.SETTINGS.config.Default.acceptedLicenseAgrement)
                {
                    string message = @" Dear User,

                                        Before you can use this software, you must read and agree to the terms and conditions of the license agreement below.

                                        License Agreement

                                        This software is licensed to you by JW Limited under the terms and conditions of the following license agreement. By using this software, you are agreeing to be bound by the terms and conditions of this agreement.

                                        1. Ownership and Copyright

                                        The developer is the owner of all intellectual property rights in the software. The software is protected by copyright laws and international treaties. You acknowledge that no title to the intellectual property in the software is transferred to you. You further acknowledge that title and full ownership rights to the software will remain the exclusive property of the developer and/or its suppliers.

                                        2. License Grant

                                        The developer grants you a non-exclusive, non-transferable, limited license to use the software, subject to the terms and conditions of this agreement. You may install and use the software on one computer only. You may not distribute, sublicense, or make available copies of the software to third parties.

                                        3. Restrictions

                                        You may not decompile, reverse engineer, disassemble, or otherwise attempt to derive the source code for the software. You may not modify, adapt, translate, or create derivative works based on the software. You may not remove or alter any copyright, trademark, or other proprietary notices from the software.

                                        4. Disclaimer of Warranties

                                        THE SOFTWARE IS PROVIDED 'AS IS' WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. THE DEVELOPER DOES NOT WARRANT THAT THE SOFTWARE WILL MEET YOUR REQUIREMENTS OR THAT THE OPERATION OF THE SOFTWARE WILL BE UNINTERRUPTED OR ERROR-FREE.

                                        5. Limitation of Liability

                                        IN NO EVENT SHALL THE DEVELOPER BE LIABLE FOR ANY INDIRECT, INCIDENTAL, SPECIAL, OR CONSEQUENTIAL DAMAGES ARISING OUT OF OR IN CONNECTION WITH THE USE OR INABILITY TO USE THE SOFTWARE (INCLUDING, BUT NOT LIMITED TO, LOSS OF PROFITS, BUSINESS INTERRUPTION, OR LOSS OF INFORMATION), EVEN IF THE DEVELOPER HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. IN ANY EVENT, THE DEVELOPER'S TOTAL LIABILITY TO YOU FOR ALL DAMAGES, LOSSES, AND CAUSES OF ACTION (WHETHER IN CONTRACT, TORT (INCLUDING NEGLIGENCE), OR OTHERWISE) SHALL NOT EXCEED THE AMOUNT PAID BY YOU FOR THE SOFTWARE.

                                        Please click 'Agree' to indicate that you have read and accepted the terms and conditions of this license agreement. If you do not agree to these terms, please click 'Disagree' and do not use the software.

                                        Thank you for using our software.

                                        Best regards,
                                        JW Limited.";

                    var result = MessageBox.Show(message, "License Agreement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        LAB.SETTINGS.config.Default.acceptedLicenseAgrement = true;
                        LAB.SETTINGS.config.Default.Save();
                        LABLibary.Assistant.WriteLicense.Write(AppDomain.CurrentDomain.BaseDirectory);
                    }
                    else
                    {
                        Application.ExitThread();
                    }
                }
                else
                {
                    LABLibary.Assistant.WriteLicense.Write(AppDomain.CurrentDomain.BaseDirectory);
                }

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
                            InfoDialog.Show(ShowHelp(), "Help - Or visit US");
                            return;
                        case "--version":
                            InfoDialog.Show(ShowVersion(), "Version");
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
                        sb3.Append(" " + files+ ",");
                    }

                    Logger.Instance.Log("Missing resources :" + sb3.ToString(),Logger.LogLevel.Warning);
                    //Browser_();
                });
            }

            var startedForm = new Form();
            if (DebugSettings.Default.debug)
            {
                switch (DebugSettings.Default.debugForm)
                {
                    default:
                        startedForm = new Form1(arg);
                        break;
                    case "builder":
                        new builder_gui(@"C:\LILO\dist\LILOApp1\LILOApp1.lab");
                        break;
                }
            }
            else
            {
                startedForm = new Form1(arg);
            }

            Application.Run(startedForm);
        }

        private static void StartSrvLocalProcess(bool noWindow)
        {
            var processName = "srvlocal.exe";
            var isProcessRunning = Process.GetProcessesByName(processName).Length > 0;

            if (!isProcessRunning)
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = $".\\{processName}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = noWindow,
                    }
                };
                process.Start();
            }
        }

        public static bool CheckIfDirIsValid()
        {
            string[] requiredFiles = { "srvlocal.exe", "srvlocal.dll", "srvlocal.runtimeconfig.json", "config.xml", "log.txt" };
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
            string[] requiredFiles = { "srvlocal.exe", "srvlocal.dll", "srvlocal.runtimeconfig.json", "config.xml", "log.txt" };
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return requiredFiles.Where(file => !File.Exists(Path.Combine(baseDirectory, file))).ToList();
        }


        private static string ShowVersion()
        {
            return String.Format("JW Lmt. LILO� SrvLocal - [Local Server Application Host] version {0}", AssemblyVersion);
        }

        private static string ShowHelp()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Usage: srvlocal.exe [OPTIONS]");
            sb.AppendLine();
            sb.AppendLine("Options:");
            sb.AppendLine("  --port=<port>");
            sb.AppendLine("      Specify the port to listen on (default is 8080)");
            sb.AppendLine();
            sb.AppendLine("  --media-folder=<folder>");
            sb.AppendLine("      Specify the folder to serve media data from (default is req/media)");
            sb.AppendLine();
            sb.AppendLine("  --folder=<folder>");
            sb.AppendLine("      Specify the folder to serve data from (default is dist/)");
            sb.AppendLine();
            sb.AppendLine("  --disable-logging");
            sb.AppendLine("      Disable request logging (default is enabled)");
            sb.AppendLine();
            sb.AppendLine("  --logfile=<file>");
            sb.AppendLine("      Specify the file to log requests to (default is access.log)");
            sb.AppendLine();
            sb.AppendLine("  --auth");
            sb.AppendLine("      Enable authentication for accessing the server");
            sb.AppendLine();
            sb.AppendLine("  --username=<username>");
            sb.AppendLine("      Specify the username for authentication");
            sb.AppendLine();
            sb.AppendLine("  --password=<password>");
            sb.AppendLine("      Specify the password for authentication");
            sb.AppendLine();
            sb.AppendLine("  --version");
            sb.AppendLine("      Show the current version");
            sb.AppendLine();
            sb.AppendLine("  --help");
            sb.AppendLine("      Show this help message");
            sb.AppendLine();
            sb.AppendLine("Examples:");
            sb.AppendLine("  srvlocal.exe --port=8000 --folder=public");
            sb.AppendLine("      Start the server on port 8000 and serve data from the 'public' folder");
            sb.AppendLine();
            sb.AppendLine("  srvlocal.exe --media-folder=data --disable-logging");
            sb.AppendLine("      Start the server and serve media data from the 'data' folder without logging");
            sb.AppendLine();
            sb.AppendLine("  srvlocal.exe --auth --username=admin --password=123456");
            sb.AppendLine("      Enable authentication with the username 'admin' and password '123456'");

            return sb.ToString();
        }





        public static void Browser_(string url = "https://github.com/JW-Limited/LILO-LocalServer")
        {
            try
            {
                Process.Start(url);
            }
            catch (Win32Exception)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = false });
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
                    throw;
                }
            }
        }
    
    }
}

    