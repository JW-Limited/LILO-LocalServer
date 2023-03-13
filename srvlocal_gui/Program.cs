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
            
            // "--start-nowin"
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
                        var arg = new ArgStart(true);
                        arg.Show();
                        Application.Run();
                    }
                    else if (args[i].StartsWith("--nowin"))
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
                        var arg = new ArgStart(false);
                        Application.Run();
                    }
                    else if (args[i] == "--help")
                    {
                        var info = new Form()
                        {
                            Size = new Size(500, 500),
                            Text = "Command : " + args[i],
                            StartPosition = FormStartPosition.CenterScreen,
                            TopMost = true,
                            ShowIcon = true,
                            ShowInTaskbar = false,
                            Name = args[i],
                            ControlBox = false,
                            HelpButton = true,
                            FormBorderStyle = FormBorderStyle.FixedDialog
                        };

                        var txtBox = new TextBox()
                        {
                            Text = ShowHelp(),
                            Location = new Point(12, 12),
                            Multiline = true,
                            Dock = DockStyle.Fill,
                            Enabled = false,
                        };

                        var bntClose = new Button()
                        {
                            Text = "OK",
                            Dock = DockStyle.Bottom,
                            Enabled = true,
                            Size = new Size(100, 30)
                        };

                        info.Controls.Add(bntClose);
                        info.Controls.Add(txtBox);

                        bntClose.Click += (sender, e) => info.Close();

                        info.ShowDialog();
                        return;
                    }
                    else if (args[i] == "--version")
                    {
                        Console.WriteLine(ShowVersion());
                        var ab = new AboutBox();
                        ab.ShowDialog();
                        return;
                    }
                    else 
                    {
                        try
                        {
                            var desk = new DesktopApi("liloDEV420");
                            desk.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\nSome Features may dont work.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        ApplicationConfiguration.Initialize();
                        var mdi = new LAB.builder_gui(args[i]);
                        mdi.Show();
                        Application.Run();
                    }
                }
            }
            else
            {
                try
                {
                    var desk = new DesktopApi("liloDEV420");
                    desk.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nSome Features may dont work.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!CheckIfDirIsValid())
                {
                    var BrwThread = new Thread(Browser_);
                }

                if (DebugSettings.Default.debug)
                {
                    ApplicationConfiguration.Initialize();
                    Application.Run(new builder_gui(""));
                }
                else
                {
                    ApplicationConfiguration.Initialize();
                    Application.Run(new Form1());
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

        private static string ShowVersion()
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
    
    }
}

    