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
            this.SuspendLayout();
            // 
            // ipAddressPubLabel
            // 
            this.ipAddressPubLabel.AutoSize = true;
            this.ipAddressPubLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressPubLabel.Location = new System.Drawing.Point(13, 10);
            this.ipAddressPubLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipAddressPubLabel.Name = "ipAddressPubLabel";
            this.ipAddressPubLabel.Size = new System.Drawing.Size(188, 25);
            this.ipAddressPubLabel.TabIndex = 0;
            this.ipAddressPubLabel.Text = "IP address (Public): ";
            // 
            // ipAddressPubTextBox
            // 
            this.ipAddressPubTextBox.Enabled = false;
            this.ipAddressPubTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressPubTextBox.Location = new System.Drawing.Point(219, 10);
            this.ipAddressPubTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipAddressPubTextBox.Name = "ipAddressPubTextBox";
            this.ipAddressPubTextBox.Size = new System.Drawing.Size(173, 30);
            this.ipAddressPubTextBox.TabIndex = 1;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLabel.Location = new System.Drawing.Point(13, 100);
            this.portLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(58, 25);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port: ";
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextBox.Location = new System.Drawing.Point(219, 95);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.portTextBox.MaxLength = 5;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(173, 30);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.Text = "3000";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(417, 9);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(94, 54);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Location = new System.Drawing.Point(417, 74);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(94, 54);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.logRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logRichTextBox.Location = new System.Drawing.Point(17, 132);
            this.logRichTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(501, 264);
            this.logRichTextBox.TabIndex = 6;
            this.logRichTextBox.TabStop = false;
            this.logRichTextBox.Text = "";
            // 
            // ipAddressPrivLabel
            // 
            this.ipAddressPrivLabel.AutoSize = true;
            this.ipAddressPrivLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressPrivLabel.Location = new System.Drawing.Point(13, 54);
            this.ipAddressPrivLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipAddressPrivLabel.Name = "ipAddressPrivLabel";
            this.ipAddressPrivLabel.Size = new System.Drawing.Size(195, 25);
            this.ipAddressPrivLabel.TabIndex = 7;
            this.ipAddressPrivLabel.Text = "IP address (Private): ";
            // 
            // ipAddressPrivTextBox
            // 
            this.ipAddressPrivTextBox.Enabled = false;
            this.ipAddressPrivTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressPrivTextBox.Location = new System.Drawing.Point(219, 52);
            this.ipAddressPrivTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipAddressPrivTextBox.Name = "ipAddressPrivTextBox";
            this.ipAddressPrivTextBox.Size = new System.Drawing.Size(173, 30);
            this.ipAddressPrivTextBox.TabIndex = 8;
            // 
            // ServerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 410);
            this.Controls.Add(this.ipAddressPrivTextBox);
            this.Controls.Add(this.ipAddressPrivLabel);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.ipAddressPubTextBox);
            this.Controls.Add(this.ipAddressPubLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ServerWindow";
            this.Text = "Chat - Server";
            this.Load += new System.EventHandler(this.ServerWindow_Load);
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
    }
}

