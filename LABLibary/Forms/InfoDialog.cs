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
using Form = System.Windows.Forms.Form;

namespace LABLibary.Forms
{
    public class InfoDialog
    {
        public static void Show(string message, string title = "Info", ContentType type = default)
        {
            var ownerForm = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;

            var info = new System.Windows.Forms.Form()
            {
                Size = new Size(600, 500),
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                ShowIcon = true,
                ControlBox = false,
                HelpButton = true,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Owner = ownerForm
            };

            var txtBox = new TextBox()
            {
                Text = message,
                Location = new Point(12, 12),
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                Font = SystemFonts.MessageBoxFont,
                ScrollBars = ScrollBars.Vertical,
                TextAlign = HorizontalAlignment.Left,
                WordWrap = true
            };

            var bntClose = new Button()
            {
                Text = "OK",
                Dock = DockStyle.Bottom,
                Size = new Size(100, 30),
                DialogResult = DialogResult.OK
            };

            info.Controls.Add(bntClose);
            info.Controls.Add(txtBox);

            info.AcceptButton = bntClose;

            info.ShowDialog(ownerForm);
        }
    }
}
