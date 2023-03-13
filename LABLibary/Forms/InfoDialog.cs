using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABLibary.Forms
{
    [Localizable(true)]
    public class InfoDialog
    {
        public static void Show(string message, string title = "Info")
        {
            var info = new System.Windows.Forms.Form()
            {
                Size = new Size(600, 500),
                Text = title,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true,
                ShowIcon = true,
                ShowInTaskbar = false,
                Name = title,
                ControlBox = false,
                HelpButton = true,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            var txtBox = new TextBox()
            {
                Text = message,
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
                Size = new Size(100, 50)
            };

            info.Controls.Add(bntClose);
            info.Controls.Add(txtBox);

            bntClose.Click += (sender, e) => info.Close();

            info.ShowDialog();
        }
    }
}
