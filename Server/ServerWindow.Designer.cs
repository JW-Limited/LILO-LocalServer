namespace Server
{
    partial class ServerWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerWindow));
            ipAddressPubLabel = new System.Windows.Forms.Label();
            ipAddressPubTextBox = new System.Windows.Forms.TextBox();
            portLabel = new System.Windows.Forms.Label();
            portTextBox = new System.Windows.Forms.TextBox();
            startButton = new System.Windows.Forms.Button();
            stopButton_Click = new System.Windows.Forms.Button();
            logRichTextBox = new System.Windows.Forms.RichTextBox();
            ipAddressPrivLabel = new System.Windows.Forms.Label();
            ipAddressPrivTextBox = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            bntCopyPort = new System.Windows.Forms.Button();
            bntCopyPriv = new System.Windows.Forms.Button();
            bntCopy = new System.Windows.Forms.Button();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panel1 = new System.Windows.Forms.Panel();
            pnlStats = new System.Windows.Forms.Panel();
            groupBox3 = new System.Windows.Forms.GroupBox();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            onlineUserRichTextBox = new System.Windows.Forms.RichTextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            lblInfo = new System.Windows.Forms.Label();
            iconPictureBox = new System.Windows.Forms.PictureBox();
            conMenu = new System.Windows.Forms.ContextMenuStrip(components);
            stopServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            copyPrivateIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyPublicIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            noty = new System.Windows.Forms.NotifyIcon(components);
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            pnlStats.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            conMenu.SuspendLayout();
            SuspendLayout();
            // 
            // ipAddressPubLabel
            // 
            ipAddressPubLabel.AutoSize = true;
            ipAddressPubLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            ipAddressPubLabel.Location = new System.Drawing.Point(16, 48);
            ipAddressPubLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ipAddressPubLabel.Name = "ipAddressPubLabel";
            ipAddressPubLabel.Size = new System.Drawing.Size(158, 23);
            ipAddressPubLabel.TabIndex = 0;
            ipAddressPubLabel.Text = "IP address (Public): ";
            // 
            // ipAddressPubTextBox
            // 
            ipAddressPubTextBox.Enabled = false;
            ipAddressPubTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            ipAddressPubTextBox.Location = new System.Drawing.Point(260, 48);
            ipAddressPubTextBox.Margin = new System.Windows.Forms.Padding(2);
            ipAddressPubTextBox.Name = "ipAddressPubTextBox";
            ipAddressPubTextBox.Size = new System.Drawing.Size(173, 30);
            ipAddressPubTextBox.TabIndex = 1;
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            portLabel.Location = new System.Drawing.Point(16, 138);
            portLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            portLabel.Name = "portLabel";
            portLabel.Size = new System.Drawing.Size(50, 23);
            portLabel.TabIndex = 2;
            portLabel.Text = "Port: ";
            // 
            // portTextBox
            // 
            portTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            portTextBox.Location = new System.Drawing.Point(260, 133);
            portTextBox.Margin = new System.Windows.Forms.Padding(2);
            portTextBox.MaxLength = 5;
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new System.Drawing.Size(173, 30);
            portTextBox.TabIndex = 3;
            portTextBox.Text = "3000";
            // 
            // startButton
            // 
            startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            startButton.Font = new System.Drawing.Font("Myanmar Text", 10.2F);
            startButton.Location = new System.Drawing.Point(0, 0);
            startButton.Margin = new System.Windows.Forms.Padding(2);
            startButton.Name = "startButton";
            startButton.Size = new System.Drawing.Size(218, 34);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // stopButton_Click
            // 
            stopButton_Click.Dock = System.Windows.Forms.DockStyle.Fill;
            stopButton_Click.Font = new System.Drawing.Font("Myanmar Text", 10.2F);
            stopButton_Click.Location = new System.Drawing.Point(0, 0);
            stopButton_Click.Margin = new System.Windows.Forms.Padding(2);
            stopButton_Click.Name = "stopButton_Click";
            stopButton_Click.Size = new System.Drawing.Size(231, 34);
            stopButton_Click.TabIndex = 1;
            stopButton_Click.Text = "Stop";
            stopButton_Click.UseVisualStyleBackColor = true;
            stopButton_Click.Click += StopButton_Click;
            // 
            // logRichTextBox
            // 
            logRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            logRichTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            logRichTextBox.Location = new System.Drawing.Point(17, 10);
            logRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            logRichTextBox.Name = "logRichTextBox";
            logRichTextBox.ReadOnly = true;
            logRichTextBox.Size = new System.Drawing.Size(453, 257);
            logRichTextBox.TabIndex = 6;
            logRichTextBox.TabStop = false;
            logRichTextBox.Text = "";
            // 
            // ipAddressPrivLabel
            // 
            ipAddressPrivLabel.AutoSize = true;
            ipAddressPrivLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            ipAddressPrivLabel.Location = new System.Drawing.Point(16, 91);
            ipAddressPrivLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ipAddressPrivLabel.Name = "ipAddressPrivLabel";
            ipAddressPrivLabel.Size = new System.Drawing.Size(164, 23);
            ipAddressPrivLabel.TabIndex = 7;
            ipAddressPrivLabel.Text = "IP address (Private): ";
            // 
            // ipAddressPrivTextBox
            // 
            ipAddressPrivTextBox.Enabled = false;
            ipAddressPrivTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            ipAddressPrivTextBox.Location = new System.Drawing.Point(260, 90);
            ipAddressPrivTextBox.Margin = new System.Windows.Forms.Padding(2);
            ipAddressPrivTextBox.Name = "ipAddressPrivTextBox";
            ipAddressPrivTextBox.Size = new System.Drawing.Size(173, 30);
            ipAddressPrivTextBox.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(bntCopyPort);
            groupBox1.Controls.Add(bntCopyPriv);
            groupBox1.Controls.Add(bntCopy);
            groupBox1.Controls.Add(ipAddressPubLabel);
            groupBox1.Controls.Add(ipAddressPrivTextBox);
            groupBox1.Controls.Add(ipAddressPubTextBox);
            groupBox1.Controls.Add(ipAddressPrivLabel);
            groupBox1.Controls.Add(portLabel);
            groupBox1.Controls.Add(portTextBox);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(12, 383);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(458, 189);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configurations";
            // 
            // bntCopyPort
            // 
            bntCopyPort.Location = new System.Drawing.Point(222, 134);
            bntCopyPort.Name = "bntCopyPort";
            bntCopyPort.Size = new System.Drawing.Size(33, 30);
            bntCopyPort.TabIndex = 9;
            bntCopyPort.Text = "C";
            bntCopyPort.UseVisualStyleBackColor = true;
            bntCopyPort.Click += BntCopyPort_Click;
            // 
            // bntCopyPriv
            // 
            bntCopyPriv.Location = new System.Drawing.Point(222, 91);
            bntCopyPriv.Name = "bntCopyPriv";
            bntCopyPriv.Size = new System.Drawing.Size(33, 30);
            bntCopyPriv.TabIndex = 9;
            bntCopyPriv.Text = "C";
            bntCopyPriv.UseVisualStyleBackColor = true;
            bntCopyPriv.Click += BntCopyPriv_Click;
            // 
            // bntCopy
            // 
            bntCopy.Location = new System.Drawing.Point(222, 48);
            bntCopy.Name = "bntCopy";
            bntCopy.Size = new System.Drawing.Size(33, 30);
            bntCopy.TabIndex = 9;
            bntCopy.Text = "C";
            bntCopy.UseVisualStyleBackColor = true;
            bntCopy.Click += BntCopy_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            splitContainer1.Location = new System.Drawing.Point(17, 284);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(startButton);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(stopButton_Click);
            splitContainer1.Size = new System.Drawing.Size(453, 34);
            splitContainer1.SplitterDistance = 218;
            splitContainer1.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Controls.Add(pnlStats);
            panel1.Controls.Add(lblInfo);
            panel1.Controls.Add(iconPictureBox);
            panel1.Location = new System.Drawing.Point(485, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(551, 560);
            panel1.TabIndex = 10;
            // 
            // pnlStats
            // 
            pnlStats.Controls.Add(groupBox3);
            pnlStats.Controls.Add(groupBox2);
            pnlStats.Controls.Add(pictureBox1);
            pnlStats.Controls.Add(label1);
            pnlStats.Location = new System.Drawing.Point(3, 547);
            pnlStats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new System.Drawing.Size(546, 10);
            pnlStats.TabIndex = 3;
            pnlStats.Visible = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(richTextBox1);
            groupBox3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic);
            groupBox3.Location = new System.Drawing.Point(296, 102);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox3.Size = new System.Drawing.Size(221, 430);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Current Traffic";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox1.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            richTextBox1.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            richTextBox1.Location = new System.Drawing.Point(3, 25);
            richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new System.Drawing.Size(215, 403);
            richTextBox1.TabIndex = 2;
            richTextBox1.TabStop = false;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += onlineUserRichTextBox_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(onlineUserRichTextBox);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic);
            groupBox2.Location = new System.Drawing.Point(30, 102);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox2.Size = new System.Drawing.Size(242, 430);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Online Users";
            // 
            // onlineUserRichTextBox
            // 
            onlineUserRichTextBox.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            onlineUserRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            onlineUserRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            onlineUserRichTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            onlineUserRichTextBox.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            onlineUserRichTextBox.Location = new System.Drawing.Point(3, 25);
            onlineUserRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            onlineUserRichTextBox.Name = "onlineUserRichTextBox";
            onlineUserRichTextBox.ReadOnly = true;
            onlineUserRichTextBox.Size = new System.Drawing.Size(236, 403);
            onlineUserRichTextBox.TabIndex = 2;
            onlineUserRichTextBox.TabStop = false;
            onlineUserRichTextBox.Text = "";
            onlineUserRichTextBox.TextChanged += onlineUserRichTextBox_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(32, 16);
            pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(68, 62);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(20, -250);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(382, 51);
            label1.TabIndex = 2;
            label1.Text = "LILO Chat Server";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblInfo.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfo.Location = new System.Drawing.Point(88, 331);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new System.Drawing.Size(382, 67);
            lblInfo.TabIndex = 2;
            lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconPictureBox
            // 
            iconPictureBox.Image = (System.Drawing.Image)resources.GetObject("iconPictureBox.Image");
            iconPictureBox.Location = new System.Drawing.Point(179, 77);
            iconPictureBox.Margin = new System.Windows.Forms.Padding(2);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new System.Drawing.Size(200, 192);
            iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            iconPictureBox.TabIndex = 1;
            iconPictureBox.TabStop = false;
            // 
            // conMenu
            // 
            conMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { stopServerToolStripMenuItem, toolStripSeparator2, copyPrivateIPToolStripMenuItem, copyPublicIPToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            conMenu.Name = "conMenu";
            conMenu.Size = new System.Drawing.Size(178, 112);
            // 
            // stopServerToolStripMenuItem
            // 
            stopServerToolStripMenuItem.Name = "stopServerToolStripMenuItem";
            stopServerToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            stopServerToolStripMenuItem.Text = "&Stop Server";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // copyPrivateIPToolStripMenuItem
            // 
            copyPrivateIPToolStripMenuItem.Name = "copyPrivateIPToolStripMenuItem";
            copyPrivateIPToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            copyPrivateIPToolStripMenuItem.Text = "&Copy Private IP";
            // 
            // copyPublicIPToolStripMenuItem
            // 
            copyPublicIPToolStripMenuItem.Name = "copyPublicIPToolStripMenuItem";
            copyPublicIPToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            copyPublicIPToolStripMenuItem.Text = "&Copy Public IP";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            exitToolStripMenuItem.Text = "&Exit";
            // 
            // noty
            // 
            noty.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            noty.BalloonTipText = "Server is running...";
            noty.BalloonTipTitle = "LILO Chat Server";
            noty.ContextMenuStrip = conMenu;
            noty.Icon = (System.Drawing.Icon)resources.GetObject("noty.Icon");
            noty.Text = "Server";
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // ServerWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1048, 584);
            Controls.Add(panel1);
            Controls.Add(splitContainer1);
            Controls.Add(groupBox1);
            Controls.Add(logRichTextBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2);
            MaximizeBox = false;
            Name = "ServerWindow";
            Text = "Chat - Server";
            Load += ServerWindow_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnlStats.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            conMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label ipAddressPubLabel;
        private System.Windows.Forms.TextBox ipAddressPubTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton_Click;
        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.Label ipAddressPrivLabel;
        private System.Windows.Forms.TextBox ipAddressPrivTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bntCopyPort;
        private System.Windows.Forms.Button bntCopyPriv;
        private System.Windows.Forms.Button bntCopy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.ContextMenuStrip conMenu;
        private System.Windows.Forms.NotifyIcon noty;
        private System.Windows.Forms.ToolStripMenuItem stopServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyPrivateIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPublicIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox onlineUserRichTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

