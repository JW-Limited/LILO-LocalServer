using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;

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

        public static bool RestartTrue = false;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            

            if (args.Length > 0) 
            {

                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].StartsWith("--start"))
                    {
                        var filePath = ".\\srvlocal.exe";
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

                        process.Start();

                        ApplicationConfiguration.Initialize();
                        Application.Run(new ArgStart());
                    }
                    else if (args[i] == "--help")
                    {
                        var info = new Form()
                        {
                            Text = args[i],
                            StartPosition = FormStartPosition.CenterScreen,
                            TopMost = true,
                            ShowIcon = false,
                            Size = new Size(500,500)
                        };

                        var txtBox = new TextBox()
                        {
                            Text = ShowHelp(),
                            Location = new Point(12, 12),
                            Multiline = true,
                            Dock = DockStyle.Fill,
                            Enabled = false,
                        };

                        info.Controls.Add(txtBox);
                        info.ShowDialog();

                        ShowHelp();
                        return;
                    }
                    else if (args[i] == "--version")
                    {
                        ShowVersion();
                        return;
                    }
                    else
                    {
                        ApplicationConfiguration.Initialize();
                        Application.Run(new LAB.builder_gui(args[i]));
                    }
                }
            }
            else
            {
                if (!CheckIfDirIsValid())
                {
                    var BrwThread = new Thread(Browser_);
                }

                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
        }

        private static string  ShowVersion()
        {
            return String.Format("JW Lmt. LILO™ SrvLocal - [Local Server Application Host] version {0}", AssemblyVersion);
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

        public static void Browser_()
        {
            var URL = "https://github.com/JW-Limited/LILO-LocalServer";

            try
            {
                Process proc = Process.Start(URL);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    URL = URL.Replace("&", "^&");

                    Process proc = Process.Start(new ProcessStartInfo("cmd", $"/c start {URL}") { CreateNoWindow = false });

                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", URL);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", URL);
                }
                else
                {
                    throw;
                }
            }
        }
    

        public static bool CheckIfDirIsValid()
        {
            string[] files = { "srvlocal.exe", "srvlocal.dll", "srvlocal.runtimeconfig.json" };

            foreach (var file in files)
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + file))
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }

            return true;
        }
    }
}

    