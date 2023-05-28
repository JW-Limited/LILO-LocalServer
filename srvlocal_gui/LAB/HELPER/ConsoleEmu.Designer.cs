namespace srvlocal_gui
{
    partial class ConsoleEmu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleEmu));
            guna2WinProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            txtConsole = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripSplitButton1 = new ToolStripSplitButton();
            consoleColorToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2WinProgressIndicator1
            // 
            guna2WinProgressIndicator1.Anchor = AnchorStyles.None;
            guna2WinProgressIndicator1.AutoStart = true;
            guna2WinProgressIndicator1.Location = new Point(336, 196);
            guna2WinProgressIndicator1.Margin = new Padding(2);
            guna2WinProgressIndicator1.Name = "guna2WinProgressIndicator1";
            guna2WinProgressIndicator1.Size = new Size(135, 135);
            guna2WinProgressIndicator1.TabIndex = 0;
            // 
            // txtConsole
            // 
            txtConsole.Dock = DockStyle.Fill;
            txtConsole.Location = new Point(0, 0);
            txtConsole.Margin = new Padding(4);
            txtConsole.Multiline = true;
            txtConsole.Name = "txtConsole";
            txtConsole.ScrollBars = ScrollBars.Vertical;
            txtConsole.Size = new Size(837, 535);
            txtConsole.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripSplitButton1 });
            statusStrip1.Location = new Point(0, 508);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(837, 27);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { consoleColorToolStripMenuItem });
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(41, 24);
            toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // consoleColorToolStripMenuItem
            // 
            consoleColorToolStripMenuItem.Name = "consoleColorToolStripMenuItem";
            consoleColorToolStripMenuItem.Size = new Size(226, 34);
            consoleColorToolStripMenuItem.Text = "Console Color";
            // 
            // ConsoleEmu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 535);
            Controls.Add(statusStrip1);
            Controls.Add(txtConsole);
            Controls.Add(guna2WinProgressIndicator1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "ConsoleEmu";
            Text = "Console Output";
            Load += ConsoleEmu_Load;
            Shown += ConsoleEmu_Shown;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2WinProgressIndicator guna2WinProgressIndicator1;
        private TextBox textBox1;
        private StatusStrip statusStrip1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem consoleColorToolStripMenuItem;
        public TextBox txtConsole;
    }
}