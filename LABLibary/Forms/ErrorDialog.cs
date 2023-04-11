/*

        Copyright© 2023 Joe Valentino Lengefeld

        Licensed under the Apache License, Version 2.0 (the "License");
        you may not use this file except in compliance with the License.
        You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
        Unless required by applicable law or agreed to in writing, software
        distributed under the License is distributed on an "AS IS" BASIS,
        WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
        See the License for the specific language governing permissions and
        limitations under the License.

        Last edit : 02.04.2023
*/

using LABLibary.Converter;
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


        public static void Show( string title = "Error" , string where = "codeEndpoint")
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
                FormBorderStyle = FormBorderStyle.FixedDialog,
                
            };

            var txtBox = new TextBox()
            {
                Text = StringC.StrArrayToString(message),
                Location = new Point(12, 12),
                Multiline = true,
                Dock = DockStyle.Fill,
                ForeColor = Color.Red,
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

            info.Controls.AddRange(new Control[]
            {
                txtBox, bntSave, bntClose
            });

            if(where != "codeEndpoint") info.Text = "Error - " + where;

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
                File.WriteAllText(sfd.FileName, StringC.StrArrayToString(content));
                cl.Close();
            }
        }
    }
}

