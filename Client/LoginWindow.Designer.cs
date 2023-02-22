namespace Client {
    partial class LoginWindow {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            iconPictureBox = new System.Windows.Forms.PictureBox();
            usernameLabel = new System.Windows.Forms.Label();
            usernameTextBox = new System.Windows.Forms.TextBox();
            loginButton = new System.Windows.Forms.Button();
            chatLabel = new System.Windows.Forms.Label();
            copyrightLabel = new System.Windows.Forms.Label();
            ipAddressLabel = new System.Windows.Forms.Label();
            portLabel = new System.Windows.Forms.Label();
            ipAddressTextBox = new System.Windows.Forms.TextBox();
            portTextBox = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // iconPictureBox
            // 
            iconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            iconPictureBox.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            iconPictureBox.Image = (System.Drawing.Image)resources.GetObject("iconPictureBox.Image");
            iconPictureBox.Location = new System.Drawing.Point(130, 105);
            iconPictureBox.Margin = new System.Windows.Forms.Padding(2);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new System.Drawing.Size(153, 146);
            iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            iconPictureBox.TabIndex = 0;
            iconPictureBox.TabStop = false;
            // 
            // usernameLabel
            // 
            usernameLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            usernameLabel.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            usernameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            usernameLabel.Location = new System.Drawing.Point(99, 463);
            usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(109, 27);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "Username: ";
            // 
            // usernameTextBox
            // 
            usernameTextBox.AcceptsReturn = true;
            usernameTextBox.AcceptsTab = true;
            usernameTextBox.AllowDrop = true;
            usernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            usernameTextBox.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            usernameTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.8F, System.Drawing.FontStyle.Bold);
            usernameTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            usernameTextBox.Location = new System.Drawing.Point(100, 501);
            usernameTextBox.Margin = new System.Windows.Forms.Padding(2);
            usernameTextBox.MaxLength = 10;
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new System.Drawing.Size(332, 24);
            usernameTextBox.TabIndex = 3;
            // 
            // loginButton
            // 
            loginButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            loginButton.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            loginButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            loginButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            loginButton.Location = new System.Drawing.Point(103, 568);
            loginButton.Margin = new System.Windows.Forms.Padding(2);
            loginButton.Name = "loginButton";
            loginButton.Size = new System.Drawing.Size(205, 36);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += LoginButton_Click;
            // 
            // chatLabel
            // 
            chatLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            chatLabel.AutoSize = true;
            chatLabel.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            chatLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            chatLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            chatLabel.Location = new System.Drawing.Point(153, 38);
            chatLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            chatLabel.Name = "chatLabel";
            chatLabel.Size = new System.Drawing.Size(110, 54);
            chatLabel.TabIndex = 4;
            chatLabel.Text = "Chat";
            // 
            // copyrightLabel
            // 
            copyrightLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            copyrightLabel.AutoSize = true;
            copyrightLabel.ForeColor = System.Drawing.SystemColors.Control;
            copyrightLabel.Location = new System.Drawing.Point(110, 624);
            copyrightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new System.Drawing.Size(191, 17);
            copyrightLabel.TabIndex = 5;
            copyrightLabel.Text = "Copyright © 2023 JW Limited";
            // 
            // ipAddressLabel
            // 
            ipAddressLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ipAddressLabel.AutoSize = true;
            ipAddressLabel.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            ipAddressLabel.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            ipAddressLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            ipAddressLabel.Location = new System.Drawing.Point(99, 288);
            ipAddressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ipAddressLabel.Name = "ipAddressLabel";
            ipAddressLabel.Size = new System.Drawing.Size(109, 27);
            ipAddressLabel.TabIndex = 6;
            ipAddressLabel.Text = "IP Address:";
            // 
            // portLabel
            // 
            portLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            portLabel.AutoSize = true;
            portLabel.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            portLabel.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            portLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            portLabel.Location = new System.Drawing.Point(99, 371);
            portLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            portLabel.Name = "portLabel";
            portLabel.Size = new System.Drawing.Size(52, 27);
            portLabel.TabIndex = 7;
            portLabel.Text = "Port:";
            // 
            // ipAddressTextBox
            // 
            ipAddressTextBox.AcceptsReturn = true;
            ipAddressTextBox.AcceptsTab = true;
            ipAddressTextBox.AllowDrop = true;
            ipAddressTextBox.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            ipAddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ipAddressTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.8F, System.Drawing.FontStyle.Bold);
            ipAddressTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            ipAddressTextBox.Location = new System.Drawing.Point(99, 325);
            ipAddressTextBox.Margin = new System.Windows.Forms.Padding(2);
            ipAddressTextBox.MaxLength = 15;
            ipAddressTextBox.Name = "ipAddressTextBox";
            ipAddressTextBox.Size = new System.Drawing.Size(332, 24);
            ipAddressTextBox.TabIndex = 1;
            // 
            // portTextBox
            // 
            portTextBox.AcceptsReturn = true;
            portTextBox.AcceptsTab = true;
            portTextBox.AllowDrop = true;
            portTextBox.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            portTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            portTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.8F, System.Drawing.FontStyle.Bold);
            portTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            portTextBox.Location = new System.Drawing.Point(100, 410);
            portTextBox.Margin = new System.Windows.Forms.Padding(2);
            portTextBox.MaxLength = 5;
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new System.Drawing.Size(332, 24);
            portTextBox.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            panel1.Controls.Add(copyrightLabel);
            panel1.Controls.Add(loginButton);
            panel1.Controls.Add(chatLabel);
            panel1.Controls.Add(iconPictureBox);
            panel1.Location = new System.Drawing.Point(67, 1);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(398, 653);
            panel1.TabIndex = 8;
            // 
            // LoginWindow
            // 
            AcceptButton = loginButton;
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(531, 651);
            Controls.Add(portTextBox);
            Controls.Add(ipAddressTextBox);
            Controls.Add(portLabel);
            Controls.Add(ipAddressLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2);
            MaximizeBox = false;
            Name = "LoginWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Chat - Login";
            Load += LoginWindow_Load;
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label chatLabel;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Panel panel1;
    }
}

