namespace srvlocal_gui
{
    partial class Feed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Feed));
            this.webview = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webview)).BeginInit();
            this.SuspendLayout();
            // 
            // webview
            // 
            this.webview.AllowExternalDrop = true;
            this.webview.CreationProperties = null;
            this.webview.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webview.Location = new System.Drawing.Point(0, 0);
            this.webview.Margin = new System.Windows.Forms.Padding(4);
            this.webview.Name = "webview";
            this.webview.Size = new System.Drawing.Size(1222, 812);
            this.webview.Source = new System.Uri("http://localhost:8080/feed/", System.UriKind.Absolute);
            this.webview.TabIndex = 0;
            this.webview.ZoomFactor = 1D;
            // 
            // Feed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 812);
            this.Controls.Add(this.webview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Feed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feed";
            ((System.ComponentModel.ISupportInitialize)(this.webview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webview;
    }
}