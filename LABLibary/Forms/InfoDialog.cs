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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABLibary.Forms
{
    [Localizable(true)]
    public class InfoDialog
    {

        public static void Show(string message, string title = "Info", ContentType type = default)
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
                AllowDrop = false,
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
