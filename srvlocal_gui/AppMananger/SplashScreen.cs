using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srvlocal_gui.AppMananger
{
    
    public partial class SplashScreen : Form
    {
        private static SplashScreen instance;

        public static SplashScreen Instance()
        {
            if (instance == null)
            {
                instance = new SplashScreen();
            }

            return instance;
        }
        
        private SplashScreen()
        {
            InitializeComponent();
        }


        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        [STAThread]
        public void ProvideProcessInformation(string callback, int threadWait)
        {
            lblStatus.Text = callback;
            Thread.Sleep(threadWait);
        }
    }
}
