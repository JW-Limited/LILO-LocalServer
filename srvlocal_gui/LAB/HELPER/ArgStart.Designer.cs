namespace srvlocal_gui
{
    partial class ArgStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Label();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            credentialDialog1 = new Ookii.Dialogs.WinForms.CredentialDialog(components);
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 15;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(192, 0, 0);
            guna2Button1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(291, 22);
            guna2Button1.Margin = new Padding(2);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.Size = new Size(187, 121);
            guna2Button1.TabIndex = 0;
            guna2Button1.Text = "Close Stream";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderColor = Color.Gray;
            guna2Panel1.BorderRadius = 15;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(guna2Panel2);
            guna2Panel1.Controls.Add(guna2Button2);
            guna2Panel1.Controls.Add(guna2Button3);
            guna2Panel1.Controls.Add(guna2Button1);
            guna2Panel1.Location = new Point(30, 40);
            guna2Panel1.Margin = new Padding(2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Size = new Size(491, 166);
            guna2Panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 0, 0);
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.BlanchedAlmond;
            label1.Location = new Point(34, 101);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 1;
            label1.Text = "Running";
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.FromArgb(192, 0, 0);
            guna2Panel2.BackgroundImage = Properties.Resources.icons8_server_windows_32;
            guna2Panel2.BackgroundImageLayout = ImageLayout.Center;
            guna2Panel2.Location = new Point(34, 40);
            guna2Panel2.Margin = new Padding(2);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.Size = new Size(71, 58);
            guna2Panel2.TabIndex = 0;
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 15;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(192, 0, 0);
            guna2Button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(23, 31);
            guna2Button2.Margin = new Padding(2);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.Size = new Size(90, 103);
            guna2Button2.TabIndex = 0;
            guna2Button2.Click += guna2Button1_Click;
            // 
            // guna2Button3
            // 
            guna2Button3.BorderRadius = 15;
            guna2Button3.DisabledState.BorderColor = Color.DarkGray;
            guna2Button3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button3.FillColor = Color.Blue;
            guna2Button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button3.ForeColor = Color.White;
            guna2Button3.Location = new Point(128, 31);
            guna2Button3.Margin = new Padding(2);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.Size = new Size(84, 103);
            guna2Button3.TabIndex = 0;
            guna2Button3.Text = "Show Logs";
            guna2Button3.Click += Cred;
            // 
            // credentialDialog1
            // 
            credentialDialog1.AdditionalEntropy = null;
            credentialDialog1.MainInstruction = "Put in Youre Credentials";
            credentialDialog1.ShowSaveCheckBox = true;
            credentialDialog1.ShowUIForSavedCredentials = true;
            credentialDialog1.Target = "Put in youre Login Credentials";
            credentialDialog1.UseApplicationInstanceCredentialCache = true;
            credentialDialog1.WindowTitle = "Admin";
            // 
            // ArgStart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(549, 240);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "ArgStart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Stream Controller";
            Load += ArgStart_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Ookii.Dialogs.WinForms.CredentialDialog credentialDialog1;
    }
}