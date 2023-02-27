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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.conMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipAddressPubLabel
            // 
            this.ipAddressPubLabel.AutoSize = true;
            this.ipAddressPubLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ipAddressPubLabel.Location = new System.Drawing.Point(16, 54);
            this.ipAddressPubLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipAddressPubLabel.Name = "ipAddressPubLabel";
            this.ipAddressPubLabel.Size = new System.Drawing.Size(158, 23);
            this.ipAddressPubLabel.TabIndex = 0;
            this.ipAddressPubLabel.Text = "IP address (Public): ";
            // 
            // ipAddressPubTextBox
            // 
            this.ipAddressPubTextBox.Enabled = false;
            this.ipAddressPubTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ipAddressPubTextBox.Location = new System.Drawing.Point(260, 54);
            this.ipAddressPubTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ipAddressPubTextBox.Name = "ipAddressPubTextBox";
            this.ipAddressPubTextBox.Size = new System.Drawing.Size(173, 30);
            this.ipAddressPubTextBox.TabIndex = 1;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.portLabel.Location = new System.Drawing.Point(16, 144);
            this.portLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(50, 23);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port: ";
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.portTextBox.Location = new System.Drawing.Point(260, 139);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.portTextBox.MaxLength = 5;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(173, 30);
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
            this.startButton.Size = new System.Drawing.Size(222, 34);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // stopButton_Click
            // 
            this.stopButton_Click.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopButton_Click.Font = new System.Drawing.Font("Myanmar Text", 10.2F);
            this.stopButton_Click.Location = new System.Drawing.Point(0, 0);
            this.stopButton_Click.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton_Click.Name = "stopButton_Click";
            this.stopButton_Click.Size = new System.Drawing.Size(227, 34);
            this.stopButton_Click.TabIndex = 1;
            this.stopButton_Click.Text = "Stop";
            this.stopButton_Click.UseVisualStyleBackColor = true;
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.logRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logRichTextBox.Location = new System.Drawing.Point(17, 10);
            this.logRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(453, 257);
            this.logRichTextBox.TabIndex = 6;
            this.logRichTextBox.TabStop = false;
            this.logRichTextBox.Text = "";
            // 
            // ipAddressPrivLabel
            // 
            this.ipAddressPrivLabel.AutoSize = true;
            this.ipAddressPrivLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ipAddressPrivLabel.Location = new System.Drawing.Point(16, 98);
            this.ipAddressPrivLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipAddressPrivLabel.Name = "ipAddressPrivLabel";
            this.ipAddressPrivLabel.Size = new System.Drawing.Size(164, 23);
            this.ipAddressPrivLabel.TabIndex = 7;
            this.ipAddressPrivLabel.Text = "IP address (Private): ";
            // 
            // ipAddressPrivTextBox
            // 
            this.ipAddressPrivTextBox.Enabled = false;
            this.ipAddressPrivTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ipAddressPrivTextBox.Location = new System.Drawing.Point(260, 96);
            this.ipAddressPrivTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ipAddressPrivTextBox.Name = "ipAddressPrivTextBox";
            this.ipAddressPrivTextBox.Size = new System.Drawing.Size(173, 30);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 383);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 189);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurations";
            // 
            // bntCopyPort
            // 
            this.bntCopyPort.Location = new System.Drawing.Point(222, 140);
            this.bntCopyPort.Name = "bntCopyPort";
            this.bntCopyPort.Size = new System.Drawing.Size(33, 30);
            this.bntCopyPort.TabIndex = 9;
            this.bntCopyPort.Text = "C";
            this.bntCopyPort.UseVisualStyleBackColor = true;
            // 
            // bntCopyPriv
            // 
            this.bntCopyPriv.Location = new System.Drawing.Point(222, 98);
            this.bntCopyPriv.Name = "bntCopyPriv";
            this.bntCopyPriv.Size = new System.Drawing.Size(33, 30);
            this.bntCopyPriv.TabIndex = 9;
            this.bntCopyPriv.Text = "C";
            this.bntCopyPriv.UseVisualStyleBackColor = true;
            // 
            // bntCopy
            // 
            this.bntCopy.Location = new System.Drawing.Point(222, 54);
            this.bntCopy.Name = "bntCopy";
            this.bntCopy.Size = new System.Drawing.Size(33, 30);
            this.bntCopy.TabIndex = 9;
            this.bntCopy.Text = "C";
            this.bntCopy.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.splitContainer1.Location = new System.Drawing.Point(17, 284);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.startButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.stopButton_Click);
            this.splitContainer1.Size = new System.Drawing.Size(453, 34);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.iconPictureBox);
            this.panel1.Location = new System.Drawing.Point(485, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 560);
            this.panel1.TabIndex = 10;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(88, 331);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(382, 67);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblError
            // 
            this.lblError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblError.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(88, 280);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(382, 51);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "LILO Chat Server";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("iconPictureBox.Image")));
            this.iconPictureBox.Location = new System.Drawing.Point(179, 77);
            this.iconPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(200, 192);
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
            this.conMenu.Size = new System.Drawing.Size(178, 112);
            // 
            // stopServerToolStripMenuItem
            // 
            this.stopServerToolStripMenuItem.Name = "stopServerToolStripMenuItem";
            this.stopServerToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.stopServerToolStripMenuItem.Text = "&Stop Server";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // copyPrivateIPToolStripMenuItem
            // 
            this.copyPrivateIPToolStripMenuItem.Name = "copyPrivateIPToolStripMenuItem";
            this.copyPrivateIPToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.copyPrivateIPToolStripMenuItem.Text = "&Copy Private IP";
            // 
            // copyPublicIPToolStripMenuItem
            // 
            this.copyPublicIPToolStripMenuItem.Name = "copyPublicIPToolStripMenuItem";
            this.copyPublicIPToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.copyPublicIPToolStripMenuItem.Text = "&Copy Public IP";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
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
            // ServerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 584);
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
    }
}

