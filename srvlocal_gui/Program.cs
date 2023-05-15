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
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ToString();
            ErrorList.Add(ex);
            Logger.Instance.Log(ex, logLevel: Logger.LogLevel.Warning);
            LABLibary.Forms.ErrorDialog.ErrorManager.AddError(ex, true, "this.Program");
            LABLibary.Forms.ErrorDialog.Show();

        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //string mySetting1Value = SettingsManager.Instance.GetSetting(settings => settings.MySetting1, "default value");
            // SettingsManager.Instance.SetSetting((settings, value) => settings.MySetting2 = value, 42);
            Logger.Instance.LogConsoleOutput();
            Logger.Instance.Log($"Started GUI...");

            if (!File.Exists(SettingsFileName))
            {
                Logger.Instance.Log($"Settingsfile was not found. Settingsmanger Init and generate it.");

                var admin = new User("Joey West", "admin" )
                { 
                    CanChangeConfig = true,
                    Email = "ceo@jwlmt.com",
                    
                };
                var guest = new User("guest", "none")
                {
                    CanChangeConfig = false,
                    Email = "guest@jwlmt.com",
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

            Console.WriteLine(SettingsManager.Instance.GetSetting(settings => settings.WindowTitle, "default value"));

            ApplicationConfiguration.Initialize();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (!File.Exists(".\\license.labl") && !LAB.SETTINGS.config.Default.acceptedLicenseAgrement)
            {

                string message = "Dear User,\r\n\r\nBefore you can use this software, you must read and agree to the terms and conditions of the license agreement below.\r\n\r\nLicense Agreement\r\n\r\nThis software is licensed to you by JW Limited under the terms and conditions of the following license agreement. By using this software, you are agreeing to be bound by the terms and conditions of this agreement.\r\n\r\n1. Ownership and Copyright\r\n\r\nThe developer is the owner of all intellectual property rights in the software. The software is protected by copyright laws and international treaties. You acknowledge that no title to the intellectual property in the software is transferred to you. You further acknowledge that title and full ownership rights to the software will remain the exclusive property of the developer and/or its suppliers.\r\n\r\n2. License Grant\r\n\r\nThe developer grants you a non-exclusive, non-transferable, limited license to use the software, subject to the terms and conditions of this agreement. You may install and use the software on one computer only. You may not distribute, sublicense, or make available copies of the software to third parties.\r\n\r\n3. Restrictions\r\n\r\nYou may not decompile, reverse engineer, disassemble, or otherwise attempt to derive the source code for the software. You may not modify, adapt, translate, or create derivative works based on the software. You may not remove or alter any copyright, trademark, or other proprietary notices from the software.\r\n\r\n4. Disclaimer of Warranties\r\n\r\nTHE SOFTWARE IS PROVIDED \"AS IS\" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. THE DEVELOPER DOES NOT WARRANT THAT THE SOFTWARE WILL MEET YOUR REQUIREMENTS OR THAT THE OPERATION OF THE SOFTWARE WILL BE UNINTERRUPTED OR ERROR-FREE.\r\n\r\n5. Limitation of Liability\r\n\r\nIN NO EVENT SHALL THE DEVELOPER BE LIABLE FOR ANY INDIRECT, INCIDENTAL, SPECIAL, OR CONSEQUENTIAL DAMAGES ARISING OUT OF OR IN CONNECTION WITH THE USE OR INABILITY TO USE THE SOFTWARE (INCLUDING, BUT NOT LIMITED TO, LOSS OF PROFITS, BUSINESS INTERRUPTION, OR LOSS OF INFORMATION), EVEN IF THE DEVELOPER HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. IN ANY EVENT, THE DEVELOPER'S TOTAL LIABILITY TO YOU FOR ALL DAMAGES, LOSSES, AND CAUSES OF ACTION (WHETHER IN CONTRACT, TORT (INCLUDING NEGLIGENCE), OR OTHERWISE) SHALL NOT EXCEED THE AMOUNT PAID BY YOU FOR THE SOFTWARE.\r\n\r\nPlease click \"Agree\" to indicate that you have read and accepted the terms and conditions of this license agreement. If you do not agree to these terms, please click \"Disagree\" and do not use the software.\r\n\r\nThank you for using our software.\r\n\r\nBest regards,\r\nJW Limited.";


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
                if (arg.StartsWith("--start"))
                {
                    startWithNoWindow = true;
                }
                else if (arg.StartsWith("--nowin"))
                {
                    startWithNoWindow = false;
                }
                else if (arg == "--help")
                {
                    LABLibary.Forms.InfoDialog.Show(ShowHelp(), "Help - Or visit US");
                    return;
                }
                else if (arg == "--version")
                {
                    LABLibary.Forms.InfoDialog.Show(ShowVersion(), "Version");
                    return;
                }
                else
                {
                    OpenBuilderGui(arg);
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
                //StartSrvLocalProcess(false);
                OpenBuilderGui("");
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
                    //Browser_();
                });
            }

            if (DebugSettings.Default.debug)
            {
                Application.Run(new builder_gui(@"C:\LILO\dist\LILOApp1\LILOApp1.lab"));
            }
            else
            {
                Application.Run(new Form1());
            }
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
            sb.AppendLine("Options:");
            sb.AppendLine("  --port=<port>              Specify the port to listen on (default is 8080)");
            sb.AppendLine("  --media-folder=<folder>    Specify the folder to serve data from (default is req/media)");
            sb.AppendLine("  --folder=<folder>          Specify the folder to serve data from (default is dist/)");
            sb.AppendLine("  --disable-logging          Disable request logging (default is enabled)");
            sb.AppendLine("  --logfile=<file>           Specify the file to log requests to (default is access.log)");
            sb.AppendLine("  --version                  Shows the current version");
            sb.AppendLine("  --help                     Show this help message");

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

    