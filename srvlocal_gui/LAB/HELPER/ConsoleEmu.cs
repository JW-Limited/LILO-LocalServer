using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srvlocal_gui
{
    public partial class ConsoleEmu : Form
    {
        private static object _lock = new object();
        private static ConsoleEmu _instance;
        private static Process ConsoleHandle = new Process();


        public static ConsoleEmu Instance(Process proc = null)
        {
            //lock (_lock)
            {
                if (_instance == null)
                {
                    return new ConsoleEmu(proc);
                }
                return _instance;
            }
        }

        private ConsoleEmu(Process proc)
        {
            ConsoleHandle = proc;
            InitializeComponent();
        }

        private void ConsoleEmu_Load(object sender, EventArgs e)
        {

        }

        private void ConsoleEmu_Shown(object sender, EventArgs e)
        {
           
        }
    }
}
