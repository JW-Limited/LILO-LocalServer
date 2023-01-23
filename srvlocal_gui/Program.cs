using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading;

namespace srvlocal_gui
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!CheckIfDirIsValid())
            {
                var BrwThread = new Thread(Browser_);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
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

    