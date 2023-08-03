using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zeroit.Framework.Metro;

namespace srvlocal_gui
{
    public partial class AppSelector : Form
    {
        private static AppSelector i_appSelector;
        private static object _lock = new object();

        public static AppSelector Instance
        {
            get
            {
                lock (_lock)
                {
                    if (i_appSelector == null)
                    {
                        i_appSelector = new AppSelector();
                    }

                    return i_appSelector;
                }
            }
        }


        private AppSelector()
        {
            InitializeComponent();

            this.FormClosing += (sender, e) =>
            {
                i_appSelector = null;
            };
        }

        public string mainAppName = "LILO App";
        public string mainDescription = "LILO UI - App (C#, Windows, Desktop)";

        private void AppSelector_Load(object sender, EventArgs e)
        {
            var rm = new Random();

            var timer = new System.Windows.Forms.Timer()
            {
                Interval = rm.Next(500, 2000),
                Enabled = true
            };
            timer.Tick += (sender, e) => saaPreloader1.Visible = false;
            timer.Start();
        }

        public void StringSetter(ZeroitMetroPanelSelection selection)
        {
            mainAppName = selection.TextHeadline;
            mainDescription = selection.TextSubline;

            this.Close();
        }

        private void zeroitMetroPanelSelection1_Click(object sender, EventArgs e)
        {
            StringSetter(zeroitMetroPanelSelection1);
        }

        private void zeroitMetroPanelSelection2_Click(object sender, EventArgs e)
        {
            StringSetter(zeroitMetroPanelSelection2);
        }

        private void zeroitMetroPanelSelection3_Click(object sender, EventArgs e)
        {
            StringSetter(zeroitMetroPanelSelection3);
        }

        private void zeroitMetroPanelSelection4_Click(object sender, EventArgs e)
        {
            StringSetter(zeroitMetroPanelSelection4);
        }

    }
}
