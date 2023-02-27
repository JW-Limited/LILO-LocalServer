using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0) {

                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i]== "--start") 
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        var gui = new ServerWindow(true);
                        gui.Show();
                        Application.Run();
                    }
                }
            }
            else {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var gui = new ServerWindow(false);
                gui.Show();
                Application.Run();
            }

            
        }
    }
}
