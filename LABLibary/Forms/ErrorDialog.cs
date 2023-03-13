using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABLibary.Forms
{
    [Localizable(true)]
    public class ErrorDialog
    {
        public static string[] message = new string[99];


        public static void Show( string title = "Error" )
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
                Text = LABLibary.StringC.StrArrayToString(message),
                Location = new Point(12, 12),
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical | ScrollBars.Horizontal
            };

            var bntSave = new Button()
            {
                Text = "Save",
                Dock = DockStyle.Bottom,
                Enabled = true,
                Size = new Size(100, 50)
            };

            var bntClose = new Button()
            {
                Text = "Report",
                Dock = DockStyle.Bottom,
                Enabled = true,
                Size = new Size(100, 50)
            };

            info.Controls.Add(bntSave);
            info.Controls.Add(txtBox);
            info.Controls.Add(bntClose);

            bntSave.Click += (sender, e) => WriteToFile(message, info);
            bntClose.Click += (sender, e) => info.Close();

            info.ShowDialog();
        }

        public static void WriteToFile(string[] content, System.Windows.Forms.Form cl)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "LAB Report (*.labrep)|*.labrep";
            
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, LABLibary.StringC.StrArrayToString(content));
                cl.Close();
            }
        }
    }
}

