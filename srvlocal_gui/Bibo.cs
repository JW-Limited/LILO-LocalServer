using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srvlocal_gui
{
    public partial class Bibo : Form
    {
        public Bibo()
        {
            InitializeComponent();
        }

        private void Bibo_Load(object sender, EventArgs e)
        {
            webView.CreateControl();
            webView.CreateGraphics();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("http://localhost:8080/player/");
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bntPP_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("http://localhost:8080/lilo/apps/pingpong/");
        }

        private void bntPX_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("http://localhost:8080/lilo/apps/pixeler/");
        }

        private void bntHA_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("http://localhost:8080/lilo/apps/hackAny/");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("http://localhost:8080/lilo/apps/drum/");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("http://localhost:8080/mail/");
        }
    }
}
