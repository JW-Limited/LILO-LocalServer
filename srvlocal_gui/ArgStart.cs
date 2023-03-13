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
    public partial class ArgStart : Form
    {
        public bool visible;

        public ArgStart(bool visible)
        {
            InitializeComponent();

            this.visible = visible;

            var noti = new Form1();
            noti.NotyFi(true);

            this.Visible = visible;
            this.ShowInTaskbar = visible;
            this.ShowIcon = visible;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaveExit(true);
        }

        public static void SaveExit(bool inTray)
        {
            if(inTray)
            {
                DialogResult msg = MessageBox.Show("Do you really want to close the JW Limited DCC. Some applications going to work no more.", "JW Limited DDC", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if(msg == DialogResult.OK)
                {
                    if (Process.GetProcessesByName("srvlocal").Length > 0)
                    {
                        foreach (var prockill in Process.GetProcessesByName("srvlocal"))
                        {

                            prockill.Kill();

                        }
                    }

                    Application.ExitThread();
                }
            }
        }

        private void Cred(object sender, EventArgs e)
        {
            credentialDialog1.ShowDialog();
            if(credentialDialog1.Password == "password" && credentialDialog1.UserName == "admin")
            {
                var coon = new ConsoleEmu();
                coon.Show();
            }
        }

        private void ArgStart_Load(object sender, EventArgs e)
        {
            this.Visible = visible;
            this.ShowInTaskbar = visible;
            this.ShowIcon = visible;

            if(!visible)
            {
                this.WindowState = FormWindowState.Minimized;
                
            }
        }
    }
}
