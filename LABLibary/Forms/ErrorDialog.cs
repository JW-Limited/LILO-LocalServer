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

using LABLibary.Assistant;
using LABLibary.Converter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LABLibary.Interface.ApiCollection.WinRegistry;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LABLibary.Forms
{
    [Localizable(true)]
    public static class ErrorDialog
    {

        public static class ErrorManager
        {
            private static readonly List<Error> errors = new List<Error>();

            public static void AddError(string errorMessage, bool isRuntimeError = false, string sourcePoint = "this.Program")
            {
                var key = Guid.NewGuid().ToString();
                var error = new Error(key, errorMessage, isRuntimeError, sourcePoint);
                errors.Add(error);
            }

            public static List<string> GetErrors()
            {
                return errors.Select(error => $"({error.id.Remove(7)}) " + error.ErrorMessage + $"\nSource : {error.SourcePoint}\n\n").ToList();
            }

            public static void ClearErrors()
            {
                errors.Clear();
            }

            public static bool IsRuntimeError(string ID)
            {
                return errors.Any(e => e.id == ID && e.IsRuntimeError);
            }

            public static bool HasSourcePoint(string ID)
            {
                return errors.Any(e => e.id == ID && !string.IsNullOrEmpty(e.SourcePoint));
            }

            public static string GetSourcePoint(string ID)
            {
                var error = errors.FirstOrDefault(e => e.id == ID && !string.IsNullOrEmpty(e.SourcePoint));
                return error?.SourcePoint;
            }

            private class Error
            {
                public string id { get; }
                public string ErrorMessage { get; }
                public bool IsRuntimeError { get; }
                public string SourcePoint { get; }

                public Error(string ID,string errorMessage, bool isRuntimeError, string sourcePoint)
                {
                    id = ID;
                    ErrorMessage = errorMessage;
                    IsRuntimeError = isRuntimeError;
                    SourcePoint = sourcePoint;
                }
            }
        }

        public static void Show(string title = "Error", string where = "codeEndpoint")
        {
            var info = new System.Windows.Forms.Form()
            {
                Size = new Size(800, 500),
                Text = title,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true,
                ShowIcon = false,
                ShowInTaskbar = false,
                Name = title,
                ControlBox = false,
                HelpButton = true,
                FormBorderStyle = FormBorderStyle.Sizable
            };

            var panel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 30, 30)
            };

            var txtBox = new RichTextBox()
            {
                Text = string.Join(Environment.NewLine, ErrorManager.GetErrors()),
                Location = new Point(20, 20),
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                ScrollBars = RichTextBoxScrollBars.ForcedBoth,
                Font = new Font(FontFamily.GenericMonospace, 10),
                BackColor = Color.FromArgb(40, 40, 40),
                ForeColor = Color.White,
                WordWrap = false,
                DetectUrls = true,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                Padding = new Padding(10),
                ContextMenuStrip = new ContextMenuStrip(),
            };
            txtBox.ContextMenuStrip.Items.Add("Copy").Click += (sender, e) => Clipboard.SetText(txtBox.Text);

            var btnSave = new Button()
            {
                Text = "Save",
                Dock = DockStyle.Bottom,
                Enabled = true,
                Size = new Size(120, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(70, 160, 70),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 120, 50);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 200, 100);
            btnSave.Click += (sender, e) => WriteToFile(ErrorManager.GetErrors(), info);

            var btnClose = new Button()
            {
                Text = "Close",
                Dock = DockStyle.Bottom,
                Enabled = true,
                Size = new Size(120, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(200, 70, 70),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 50, 50);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 100, 100);
            btnClose.Click += (sender, e) => info.Close();

            var btnClear = new Button()
            {
                Text = "Clear",
                Dock = DockStyle.Bottom,
                Enabled = true,
                Size = new Size(120, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(230, 160, 40),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                Margin =
                new Padding(10),
                Cursor = Cursors.Hand,
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 100, 30);
            btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 200, 60);
            btnClear.Click += (sender, e) =>
            {
                ErrorManager.ClearErrors();
                txtBox.Clear();
            };

            var lblWhere = new Label()
            {
                Text = $"Source: {where}",
                Padding = new Padding(10),
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
            };

            var lblTitle = new Label()
            {
                Text = title,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(50, 50, 50),
                Padding = new Padding(0),
                Height = 50,
            };

            panel.Controls.Add(txtBox);
            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnClear);
            panel.Controls.Add(btnClose);
            panel.Controls.Add(lblWhere);
            info.Controls.Add(panel);
            info.Controls.Add(lblTitle);

            if (where != "codeEndpoint")
            {
                info.Text = $"Error - {where}";
            }

            info.ShowDialog();
        }


        public static void WriteToFile(List<string> errors, System.Windows.Forms.Form cl)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "LAB Report (*.labrep)|*.labrep";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(sfd.FileName, errors);
                cl.Close();
            }
        }
    }
}

