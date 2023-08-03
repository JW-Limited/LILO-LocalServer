namespace srvlocal_gui.AppMananger
{
    partial class SupportChat
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
            radChat1 = new Telerik.WinControls.UI.RadChat();
            fluentDarkTheme1 = new Telerik.WinControls.Themes.FluentDarkTheme();
            windows11Theme1 = new Telerik.WinControls.Themes.Windows11Theme();
            ((System.ComponentModel.ISupportInitialize)radChat1).BeginInit();
            SuspendLayout();
            // 
            // radChat1
            // 
            radChat1.AvatarSize = new SizeF(102.539063F, 102.539063F);
            radChat1.Dock = DockStyle.Fill;
            radChat1.Location = new Point(0, 0);
            radChat1.Margin = new Padding(12, 12, 12, 12);
            radChat1.Name = "radChat1";
            radChat1.Size = new Size(732, 805);
            radChat1.TabIndex = 0;
            radChat1.Text = "radChat1";
            radChat1.ThemeName = "Windows11";
            radChat1.TimeSeparatorInterval = TimeSpan.Parse("1.00:00:00");
            // 
            // SupportChat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 805);
            Controls.Add(radChat1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "SupportChat";
            ShowIcon = false;
            Load += SupportChat_Load;
            ((System.ComponentModel.ISupportInitialize)radChat1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadChat radChat1;
        private Telerik.WinControls.Themes.FluentDarkTheme fluentDarkTheme1;
        private Telerik.WinControls.Themes.Windows11Theme windows11Theme1;
    }
}