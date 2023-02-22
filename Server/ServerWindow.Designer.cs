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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerWindow));
            this.ipAddressPubLabel = new System.Windows.Forms.Label();
            this.ipAddressPubTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ipAddressPrivLabel = new System.Windows.Forms.Label();
            this.ipAddressPrivTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopButton.Font = new System.Drawing.Font("Myanmar Text", 10.2F);
            this.stopButton.Location = new System.Drawing.Point(0, 0);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(227, 34);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
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
            this.splitContainer1.Panel2.Controls.Add(this.stopButton);
            this.splitContainer1.Size = new System.Drawing.Size(453, 34);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBox1.Location = new System.Drawing.Point(494, 542);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(442, 30);
            this.textBox1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(494, 10);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(442, 540);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // ServerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 584);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.logRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ServerWindow";
            this.Text = "Chat - Server";
            this.Load += new System.EventHandler(this.ServerWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipAddressPubLabel;
        private System.Windows.Forms.TextBox ipAddressPubTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.Label ipAddressPrivLabel;
        private System.Windows.Forms.TextBox ipAddressPrivTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

