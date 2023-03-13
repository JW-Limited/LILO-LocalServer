namespace Server {
    partial class ServerWindow {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerWindow));
            this.ipAddressPubLabel = new System.Windows.Forms.Label();
            this.ipAddressPubTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton_Click = new System.Windows.Forms.Button();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ipAddressPrivLabel = new System.Windows.Forms.Label();
            this.ipAddressPrivTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bntCopyPort = new System.Windows.Forms.Button();
            this.bntCopyPriv = new System.Windows.Forms.Button();
            this.bntCopy = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.onlineUserRichTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.conMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stopServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyPrivateIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPublicIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noty = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.conMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipAddressPubLabel
            // 
            this.ipAddressPubLabel.AutoSize = true;
            this.ipAddressPubLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ipAddressPubLabel.Location = new System.Drawing.Point(18, 60);
            this.ipAddressPubLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipAddressPubLabel.Name = "ipAddressPubLabel";
            this.ipAddressPubLabel.Size = new System.Drawing.Size(193, 30);
            this.ipAddressPubLabel.TabIndex = 0;
            this.ipAddressPubLabel.Text = "IP address (Public): ";
            // 
            // ipAddressPubTextBox
            // 
            this.ipAddressPubTextBox.Enabled = false;
            this.ipAddressPubTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ipAddressPubTextBox.Location = new System.Drawing.Point(292, 60);
            this.ipAddressPubTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ipAddressPubTextBox.Name = "ipAddressPubTextBox";
            this.ipAddressPubTextBox.Size = new System.Drawing.Size(194, 35);
            this.ipAddressPubTextBox.TabIndex = 1;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.portLabel.Location = new System.Drawing.Point(18, 172);
            this.portLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(61, 30);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port: ";
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.portTextBox.Location = new System.Drawing.Point(292, 166);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.portTextBox.MaxLength = 5;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(194, 35);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.Text = "3000";
            // 
            // startButton
            // 
            this.startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startButton.Font = new System.Drawing.Font("Myanmar Text", 10.2F);
            this.startButton.Location = new System.Drawing.Point(0, 0);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(247, 42);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // stopButton_Click
            // 
            this.stopButton_Click.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopButton_Click.Font = new System.Drawing.Font("Myanmar Text", 10.2F);
            this.stopButton_Click.Location = new System.Drawing.Point(0, 0);
            this.stopButton_Click.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton_Click.Name = "stopButton_Click";
            this.stopButton_Click.Size = new System.Drawing.Size(259, 42);
            this.stopButton_Click.TabIndex = 1;
            this.stopButton_Click.Text = "Stop";
            this.stopButton_Click.UseVisualStyleBackColor = true;
            this.stopButton_Click.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.logRichTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logRichTextBox.Location = new System.Drawing.Point(19, 12);
            this.logRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(509, 320);
            this.logRichTextBox.TabIndex = 6;
            this.logRichTextBox.TabStop = false;
            this.logRichTextBox.Text = "";
            // 
            // ipAddressPrivLabel
            // 
            this.ipAddressPrivLabel.AutoSize = true;
            this.ipAddressPrivLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ipAddressPrivLabel.Location = new System.Drawing.Point(18, 114);
            this.ipAddressPrivLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipAddressPrivLabel.Name = "ipAddressPrivLabel";
            this.ipAddressPrivLabel.Size = new System.Drawing.Size(200, 30);
            this.ipAddressPrivLabel.TabIndex = 7;
            this.ipAddressPrivLabel.Text = "IP address (Private): ";
            // 
            // ipAddressPrivTextBox
            // 
            this.ipAddressPrivTextBox.Enabled = false;
            this.ipAddressPrivTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ipAddressPrivTextBox.Location = new System.Drawing.Point(292, 112);
            this.ipAddressPrivTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ipAddressPrivTextBox.Name = "ipAddressPrivTextBox";
            this.ipAddressPrivTextBox.Size = new System.Drawing.Size(194, 35);
            this.ipAddressPrivTextBox.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bntCopyPort);
            this.groupBox1.Controls.Add(this.bntCopyPriv);
            this.groupBox1.Controls.Add(this.bntCopy);
            this.groupBox1.Controls.Add(this.ipAddressPubLabel);
            this.groupBox1.Controls.Add(this.ipAddressPrivTextBox);
            this.groupBox1.Controls.Add(this.ipAddressPubTextBox);
            this.groupBox1.Controls.Add(this.ipAddressPrivLabel);
            this.groupBox1.Controls.Add(this.portLabel);
            this.groupBox1.Controls.Add(this.portTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 479);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(515, 236);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurations";
            // 
            // bntCopyPort
            // 
            this.bntCopyPort.Location = new System.Drawing.Point(250, 167);
            this.bntCopyPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntCopyPort.Name = "bntCopyPort";
            this.bntCopyPort.Size = new System.Drawing.Size(37, 38);
            this.bntCopyPort.TabIndex = 9;
            this.bntCopyPort.Text = "C";
            this.bntCopyPort.UseVisualStyleBackColor = true;
            this.bntCopyPort.Click += new System.EventHandler(this.BntCopyPort_Click);
            // 
            // bntCopyPriv
            // 
            this.bntCopyPriv.Location = new System.Drawing.Point(250, 114);
            this.bntCopyPriv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntCopyPriv.Name = "bntCopyPriv";
            this.bntCopyPriv.Size = new System.Drawing.Size(37, 38);
            this.bntCopyPriv.TabIndex = 9;
            this.bntCopyPriv.Text = "C";
            this.bntCopyPriv.UseVisualStyleBackColor = true;
            this.bntCopyPriv.Click += new System.EventHandler(this.BntCopyPriv_Click);
            // 
            // bntCopy
            // 
            this.bntCopy.Location = new System.Drawing.Point(250, 60);
            this.bntCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntCopy.Name = "bntCopy";
            this.bntCopy.Size = new System.Drawing.Size(37, 38);
            this.bntCopy.TabIndex = 9;
            this.bntCopy.Text = "C";
            this.bntCopy.UseVisualStyleBackColor = true;
            this.bntCopy.Click += new System.EventHandler(this.BntCopy_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.splitContainer1.Location = new System.Drawing.Point(19, 355);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.startButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.stopButton_Click);
            this.splitContainer1.Size = new System.Drawing.Size(510, 42);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlStats);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.iconPictureBox);
            this.panel1.Location = new System.Drawing.Point(546, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 700);
            this.panel1.TabIndex = 10;
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.groupBox3);
            this.pnlStats.Controls.Add(this.groupBox2);
            this.pnlStats.Controls.Add(this.pictureBox1);
            this.pnlStats.Controls.Add(this.label1);
            this.pnlStats.Location = new System.Drawing.Point(3, 3);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(614, 694);
            this.pnlStats.TabIndex = 3;
            this.pnlStats.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic);
            this.groupBox3.Location = new System.Drawing.Point(333, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 538);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Traffic";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox1.Location = new System.Drawing.Point(3, 31);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(243, 504);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.onlineUserRichTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.onlineUserRichTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic);
            this.groupBox2.Location = new System.Drawing.Point(34, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 538);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Online Users";
            // 
            // onlineUserRichTextBox
            // 
            this.onlineUserRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.onlineUserRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.onlineUserRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onlineUserRichTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            this.onlineUserRichTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.onlineUserRichTextBox.Location = new System.Drawing.Point(3, 31);
            this.onlineUserRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.onlineUserRichTextBox.Name = "onlineUserRichTextBox";
            this.onlineUserRichTextBox.ReadOnly = true;
            this.onlineUserRichTextBox.Size = new System.Drawing.Size(266, 504);
            this.onlineUserRichTextBox.TabIndex = 2;
            this.onlineUserRichTextBox.TabStop = false;
            this.onlineUserRichTextBox.Text = "";
            this.onlineUserRichTextBox.TextChanged += new System.EventHandler(this.onlineUserRichTextBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 64);
            this.label1.TabIndex = 2;
            this.label1.Text = "LILO Chat Server";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(99, 414);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(430, 84);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblError
            // 
            this.lblError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblError.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(99, 350);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(430, 64);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "LILO Chat Server";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("iconPictureBox.Image")));
            this.iconPictureBox.Location = new System.Drawing.Point(201, 96);
            this.iconPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(225, 240);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox.TabIndex = 1;
            this.iconPictureBox.TabStop = false;
            // 
            // conMenu
            // 
            this.conMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopServerToolStripMenuItem,
            this.toolStripSeparator2,
            this.copyPrivateIPToolStripMenuItem,
            this.copyPublicIPToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.conMenu.Name = "conMenu";
            this.conMenu.Size = new System.Drawing.Size(205, 136);
            // 
            // stopServerToolStripMenuItem
            // 
            this.stopServerToolStripMenuItem.Name = "stopServerToolStripMenuItem";
            this.stopServerToolStripMenuItem.Size = new System.Drawing.Size(204, 30);
            this.stopServerToolStripMenuItem.Text = "&Stop Server";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // copyPrivateIPToolStripMenuItem
            // 
            this.copyPrivateIPToolStripMenuItem.Name = "copyPrivateIPToolStripMenuItem";
            this.copyPrivateIPToolStripMenuItem.Size = new System.Drawing.Size(204, 30);
            this.copyPrivateIPToolStripMenuItem.Text = "&Copy Private IP";
            // 
            // copyPublicIPToolStripMenuItem
            // 
            this.copyPublicIPToolStripMenuItem.Name = "copyPublicIPToolStripMenuItem";
            this.copyPublicIPToolStripMenuItem.Size = new System.Drawing.Size(204, 30);
            this.copyPublicIPToolStripMenuItem.Text = "&Copy Public IP";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(204, 30);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // noty
            // 
            this.noty.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.noty.BalloonTipText = "Server is running...";
            this.noty.BalloonTipTitle = "LILO Chat Server";
            this.noty.ContextMenuStrip = this.conMenu;
            this.noty.Icon = ((System.Drawing.Icon)(resources.GetObject("noty.Icon")));
            this.noty.Text = "Server";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // ServerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 730);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ServerWindow";
            this.Text = "Chat - Server";
            this.Load += new System.EventHandler(this.ServerWindow_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.conMenu.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label lblError;
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

