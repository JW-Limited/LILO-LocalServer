namespace srvlocal_gui.AppMananger
{
    partial class ChangePassword
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
            txtOldPassword = new Sipaa.Framework.STextBox();
            txtNewPassword = new Sipaa.Framework.STextBox();
            txtNewPasswordRepeat = new Sipaa.Framework.STextBox();
            saaLabel1 = new SaaUI.SaaLabel();
            bntChangePassword = new Guna.UI2.WinForms.Guna2Button();
            pnlOld = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            saaLabel2 = new SaaUI.SaaLabel();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            saaLabel3 = new SaaUI.SaaLabel();
            lblDontMatch = new Label();
            pnlOld.SuspendLayout();
            guna2Panel2.SuspendLayout();
            guna2Panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtOldPassword
            // 
            txtOldPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtOldPassword.BackColor = SystemColors.Window;
            txtOldPassword.BorderColor = Color.Black;
            txtOldPassword.BorderFocusColor = Color.MediumBlue;
            txtOldPassword.BorderRadius = 10;
            txtOldPassword.BorderSize = 2;
            txtOldPassword.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtOldPassword.ForeColor = Color.FromArgb(64, 64, 64);
            txtOldPassword.Location = new Point(168, 42);
            txtOldPassword.Margin = new Padding(4);
            txtOldPassword.Multiline = false;
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Padding = new Padding(10, 7, 10, 7);
            txtOldPassword.PasswordChar = false;
            txtOldPassword.PlaceholderColor = Color.DarkGray;
            txtOldPassword.PlaceholderText = "";
            txtOldPassword.Size = new Size(417, 39);
            txtOldPassword.TabIndex = 0;
            txtOldPassword.Texts = "";
            txtOldPassword.UnderlinedStyle = false;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNewPassword.BackColor = SystemColors.Window;
            txtNewPassword.BorderColor = Color.Black;
            txtNewPassword.BorderFocusColor = Color.MediumBlue;
            txtNewPassword.BorderRadius = 10;
            txtNewPassword.BorderSize = 2;
            txtNewPassword.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtNewPassword.ForeColor = Color.FromArgb(64, 64, 64);
            txtNewPassword.Location = new Point(168, 101);
            txtNewPassword.Margin = new Padding(4);
            txtNewPassword.Multiline = false;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Padding = new Padding(10, 7, 10, 7);
            txtNewPassword.PasswordChar = false;
            txtNewPassword.PlaceholderColor = Color.DarkGray;
            txtNewPassword.PlaceholderText = "";
            txtNewPassword.Size = new Size(417, 39);
            txtNewPassword.TabIndex = 0;
            txtNewPassword.Texts = "";
            txtNewPassword.UnderlinedStyle = false;
            txtNewPassword._TextChanged += txtNewPassword__TextChanged;
            // 
            // txtNewPasswordRepeat
            // 
            txtNewPasswordRepeat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNewPasswordRepeat.BackColor = SystemColors.Window;
            txtNewPasswordRepeat.BorderColor = Color.Black;
            txtNewPasswordRepeat.BorderFocusColor = Color.MediumBlue;
            txtNewPasswordRepeat.BorderRadius = 10;
            txtNewPasswordRepeat.BorderSize = 2;
            txtNewPasswordRepeat.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtNewPasswordRepeat.ForeColor = Color.FromArgb(64, 64, 64);
            txtNewPasswordRepeat.Location = new Point(168, 161);
            txtNewPasswordRepeat.Margin = new Padding(4);
            txtNewPasswordRepeat.Multiline = false;
            txtNewPasswordRepeat.Name = "txtNewPasswordRepeat";
            txtNewPasswordRepeat.Padding = new Padding(10, 7, 10, 7);
            txtNewPasswordRepeat.PasswordChar = false;
            txtNewPasswordRepeat.PlaceholderColor = Color.DarkGray;
            txtNewPasswordRepeat.PlaceholderText = "";
            txtNewPasswordRepeat.Size = new Size(417, 39);
            txtNewPasswordRepeat.TabIndex = 0;
            txtNewPasswordRepeat.Texts = "";
            txtNewPasswordRepeat.UnderlinedStyle = false;
            txtNewPasswordRepeat._TextChanged += txtNewPassword__TextChanged;
            // 
            // saaLabel1
            // 
            saaLabel1.BackColor = Color.Transparent;
            saaLabel1.Location = new Point(9, 0);
            saaLabel1.Name = "saaLabel1";
            saaLabel1.Size = new Size(80, 39);
            saaLabel1.TabIndex = 1;
            saaLabel1.Text = "Old";
            saaLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bntChangePassword
            // 
            bntChangePassword.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bntChangePassword.Animated = true;
            bntChangePassword.BorderRadius = 10;
            bntChangePassword.DisabledState.BorderColor = Color.DarkGray;
            bntChangePassword.DisabledState.CustomBorderColor = Color.DarkGray;
            bntChangePassword.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            bntChangePassword.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            bntChangePassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bntChangePassword.ForeColor = Color.White;
            bntChangePassword.Location = new Point(57, 285);
            bntChangePassword.Name = "bntChangePassword";
            bntChangePassword.Size = new Size(528, 42);
            bntChangePassword.TabIndex = 2;
            bntChangePassword.Text = "Change Password";
            bntChangePassword.Click += bntChangePassword_Click;
            // 
            // pnlOld
            // 
            pnlOld.BorderRadius = 10;
            pnlOld.Controls.Add(saaLabel1);
            pnlOld.FillColor = Color.Azure;
            pnlOld.Location = new Point(45, 42);
            pnlOld.Name = "pnlOld";
            pnlOld.Size = new Size(100, 39);
            pnlOld.TabIndex = 3;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BorderRadius = 10;
            guna2Panel2.Controls.Add(saaLabel2);
            guna2Panel2.FillColor = Color.Azure;
            guna2Panel2.Location = new Point(45, 101);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.Size = new Size(100, 39);
            guna2Panel2.TabIndex = 3;
            // 
            // saaLabel2
            // 
            saaLabel2.BackColor = Color.Transparent;
            saaLabel2.Location = new Point(9, 0);
            saaLabel2.Name = "saaLabel2";
            saaLabel2.Size = new Size(88, 39);
            saaLabel2.TabIndex = 1;
            saaLabel2.Text = "New";
            saaLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // guna2Panel3
            // 
            guna2Panel3.BorderRadius = 10;
            guna2Panel3.Controls.Add(saaLabel3);
            guna2Panel3.FillColor = Color.Azure;
            guna2Panel3.Location = new Point(45, 161);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.Size = new Size(100, 39);
            guna2Panel3.TabIndex = 3;
            // 
            // saaLabel3
            // 
            saaLabel3.BackColor = Color.Transparent;
            saaLabel3.Location = new Point(9, 0);
            saaLabel3.Name = "saaLabel3";
            saaLabel3.Size = new Size(88, 39);
            saaLabel3.TabIndex = 1;
            saaLabel3.Text = "Repeat";
            saaLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDontMatch
            // 
            lblDontMatch.AutoSize = true;
            lblDontMatch.ForeColor = Color.Red;
            lblDontMatch.Location = new Point(168, 217);
            lblDontMatch.Name = "lblDontMatch";
            lblDontMatch.Size = new Size(222, 25);
            lblDontMatch.TabIndex = 4;
            lblDontMatch.Text = "The Password don´t match";
            lblDontMatch.Visible = false;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(636, 356);
            Controls.Add(lblDontMatch);
            Controls.Add(bntChangePassword);
            Controls.Add(txtNewPasswordRepeat);
            Controls.Add(txtNewPassword);
            Controls.Add(txtOldPassword);
            Controls.Add(guna2Panel3);
            Controls.Add(guna2Panel2);
            Controls.Add(pnlOld);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(658, 361);
            Name = "ChangePassword";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangePassword";
            TopMost = true;
            FormClosing += ChangePassword_FormClosing;
            Load += ChangePassword_Load;
            pnlOld.ResumeLayout(false);
            guna2Panel2.ResumeLayout(false);
            guna2Panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sipaa.Framework.STextBox txtOldPassword;
        private Sipaa.Framework.STextBox txtNewPassword;
        private Sipaa.Framework.STextBox txtNewPasswordRepeat;
        private SaaUI.SaaLabel saaLabel1;
        private Guna.UI2.WinForms.Guna2Button bntChangePassword;
        private Guna.UI2.WinForms.Guna2Panel pnlOld;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private SaaUI.SaaLabel saaLabel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private SaaUI.SaaLabel saaLabel3;
        private Label lblDontMatch;
    }
}