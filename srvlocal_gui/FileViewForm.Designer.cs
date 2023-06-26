namespace srvlocal_gui
{
    partial class FileViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileViewForm));
            FileView = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)FileView).BeginInit();
            SuspendLayout();
            // 
            // FileView
            // 
            FileView.AllowExternalDrop = false;
            FileView.BackColor = SystemColors.ActiveCaptionText;
            FileView.CreationProperties = null;
            FileView.DefaultBackgroundColor = Color.Black;
            FileView.Dock = DockStyle.Fill;
            FileView.Location = new Point(0, 0);
            FileView.Name = "FileView";
            FileView.Size = new Size(790, 526);
            FileView.TabIndex = 0;
            FileView.ZoomFactor = 1D;
            // 
            // FileViewForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 526);
            Controls.Add(FileView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FileViewForm";
            Text = "FVF";
            Load += FileViewForm_Load;
            ((System.ComponentModel.ISupportInitialize)FileView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 FileView;
    }
}