namespace LIM
{
    partial class RadForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadForm1));
            windows11Theme1 = new Telerik.WinControls.Themes.Windows11Theme();
            metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            tbPageApp = new System.Windows.Forms.TabPage();
            guna2ProgressIndicator1 = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            tbPageDirectory = new System.Windows.Forms.TabPage();
            tabPage1 = new System.Windows.Forms.TabPage();
            tabPage2 = new System.Windows.Forms.TabPage();
            tabPage3 = new System.Windows.Forms.TabPage();
            metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(components);
            label1 = new System.Windows.Forms.Label();
            metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(components);
            metroTabControl1.SuspendLayout();
            tbPageApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)metroStyleManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // metroTabControl1
            // 
            metroTabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            metroTabControl1.Controls.Add(tbPageApp);
            metroTabControl1.Controls.Add(tbPageDirectory);
            metroTabControl1.Controls.Add(tabPage1);
            metroTabControl1.Controls.Add(tabPage2);
            metroTabControl1.Controls.Add(tabPage3);
            metroTabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            metroTabControl1.FontSize = MetroFramework.MetroTabControlSize.Tall;
            metroTabControl1.Location = new System.Drawing.Point(30, 91);
            metroTabControl1.Name = "metroTabControl1";
            metroTabControl1.Padding = new System.Drawing.Point(6, 8);
            metroTabControl1.SelectedIndex = 0;
            metroTabControl1.Size = new System.Drawing.Size(979, 561);
            metroTabControl1.Style = MetroFramework.MetroColorStyle.Magenta;
            metroTabControl1.TabIndex = 0;
            metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroTabControl1.UseSelectable = true;
            // 
            // tbPageApp
            // 
            tbPageApp.Controls.Add(guna2ProgressIndicator1);
            tbPageApp.Location = new System.Drawing.Point(4, 44);
            tbPageApp.Name = "tbPageApp";
            tbPageApp.Size = new System.Drawing.Size(971, 513);
            tbPageApp.TabIndex = 0;
            tbPageApp.Text = "Select App      ";
            // 
            // guna2ProgressIndicator1
            // 
            guna2ProgressIndicator1.Anchor = System.Windows.Forms.AnchorStyles.None;
            guna2ProgressIndicator1.AutoStart = true;
            guna2ProgressIndicator1.Location = new System.Drawing.Point(194, 117);
            guna2ProgressIndicator1.Name = "guna2ProgressIndicator1";
            guna2ProgressIndicator1.ProgressColor = System.Drawing.Color.Red;
            guna2ProgressIndicator1.Size = new System.Drawing.Size(69, 62);
            guna2ProgressIndicator1.TabIndex = 0;
            // 
            // tbPageDirectory
            // 
            tbPageDirectory.Location = new System.Drawing.Point(4, 39);
            tbPageDirectory.Name = "tbPageDirectory";
            tbPageDirectory.Size = new System.Drawing.Size(192, 57);
            tbPageDirectory.TabIndex = 1;
            tbPageDirectory.Text = "Directory      ";
            // 
            // tabPage1
            // 
            tabPage1.Location = new System.Drawing.Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new System.Drawing.Size(192, 57);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Account      ";
            // 
            // tabPage2
            // 
            tabPage2.Location = new System.Drawing.Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new System.Drawing.Size(192, 57);
            tabPage2.TabIndex = 3;
            tabPage2.Text = "Install      ";
            // 
            // tabPage3
            // 
            tabPage3.Location = new System.Drawing.Point(4, 39);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(192, 57);
            tabPage3.TabIndex = 4;
            tabPage3.Text = "Finish      ";
            // 
            // label1
            // 
            metroStyleExtender1.SetApplyMetroTheme(label1, true);
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(34, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(362, 45);
            label1.TabIndex = 1;
            label1.Text = "Welcome, to the Family!";
            // 
            // metroStyleManager1
            // 
            metroStyleManager1.Owner = this;
            metroStyleManager1.Style = MetroFramework.MetroColorStyle.Magenta;
            // 
            // RadForm1
            // 
            AutoScaleBaseSize = new System.Drawing.Size(10, 25);
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1034, 692);
            Controls.Add(label1);
            Controls.Add(metroTabControl1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "RadForm1";
            Text = "LIM - LILO Install Manager";
            ThemeName = "Windows11";
            Load += RadForm1_Load;
            metroTabControl1.ResumeLayout(false);
            tbPageApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)metroStyleManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Telerik.WinControls.Themes.Windows11Theme windows11Theme1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tbPageApp;
        private System.Windows.Forms.TabPage tbPageDirectory;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Guna.UI2.WinForms.Guna2ProgressIndicator guna2ProgressIndicator1;
    }
}