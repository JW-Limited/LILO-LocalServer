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
        public AppSelector()
        {
            InitializeComponent();
        }

        public string mainAppName = "LILO App";
        public string mainDescription = "LILO UI - App (C#, Windows, Desktop)";

        private void AppSelector_Load(object sender, EventArgs e)
        {
            var rm = new Random();

            var timer = new System.Windows.Forms.Timer()
            {
                Interval = rm.Next(500,2000),
                Enabled = true
            };
            timer.Tick += (sender, e) => saaPreloader1.Visible = false;
            timer.Start();
        }

        public void StringSetter(ZeroitMetroPanelSelection selection )
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

        private void zeroitMetroPanelSelection5_Click(object sender, EventArgs e)
        {
            StringSetter(zeroitMetroPanelSelection5);
        }
    }
}
