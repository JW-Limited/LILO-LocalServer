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
    public partial class SupportChat : Form
    {
        public SupportChat()
        {
            InitializeComponent();
        }

        private void SupportChat_Load(object sender, EventArgs e)
        {
            radChat1.Author = new Telerik.WinControls.UI.Author(null, "User");
        }
    }
}
