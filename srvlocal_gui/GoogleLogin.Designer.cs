namespace srvlocal_gui
{
    partial class GoogleLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoogleLogin));
            this.saaPreloader1 = new SaaUI.SaaPreloader();
            this.loading = new SaaUI.SaaPanel();
            this.mainView = new Guna.UI2.WinForms.Guna2Panel();
            this.saaPanel2 = new SaaUI.SaaPanel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.saaLabel3 = new SaaUI.SaaLabel();
            this.saaLabel2 = new SaaUI.SaaLabel();
            this.txtUsername = new SaaUI.SaaTextBox();
            this.txtPassword = new SaaUI.SaaTextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.saaLabel1 = new SaaUI.SaaLabel();
            this.loading.SuspendLayout();
            this.mainView.SuspendLayout();
            this.saaPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saaPreloader1
            // 
            this.saaPreloader1.BackColor = System.Drawing.Color.Transparent;
            this.saaPreloader1.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            this.saaPreloader1.DashOffset = 0F;
            this.saaPreloader1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.saaPreloader1.LineEnd = System.Drawing.Drawing2D.LineCap.Round;
            this.saaPreloader1.LineStart = System.Drawing.Drawing2D.LineCap.Round;
            this.saaPreloader1.LoaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.saaPreloader1.LoaderWidth = 5;
            this.saaPreloader1.Location = new System.Drawing.Point(245, 298);
            this.saaPreloader1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.saaPreloader1.MaxAngle = 360;
            this.saaPreloader1.MinAngle = 0;
            this.saaPreloader1.Name = "saaPreloader1";
            this.saaPreloader1.Reverse = false;
            this.saaPreloader1.Size = new System.Drawing.Size(179, 179);
            this.saaPreloader1.SpeedInMilliSeconds = 20;
            this.saaPreloader1.Start = true;
            this.saaPreloader1.StepDown = 4;
            this.saaPreloader1.StepUp = 4;
            this.saaPreloader1.TabIndex = 0;
            // 
            // loading
            // 
            this.loading.BackColor = System.Drawing.Color.IndianRed;
            this.loading.BackColor2 = System.Drawing.Color.Navy;
            this.loading.BackColorAngle = 95F;
            this.loading.Border = 0;
            this.loading.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.loading.BorderColor2 = System.Drawing.Color.DarkCyan;
            this.loading.BorderColorAngle = 0;
            this.loading.ColorType = SaaUI.PanelColorType.Gradient;
            this.loading.Controls.Add(this.saaPreloader1);
            this.loading.EnableDoubleBuffering = true;
            this.loading.ForceDrawRegion = true;
            this.loading.Location = new System.Drawing.Point(0, 0);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(706, 779);
            this.loading.TabIndex = 1;
            this.loading.Transparence = 100;
            // 
            // mainView
            // 
            this.mainView.BackgroundImage = global::srvlocal_gui.Properties.Resources.Ocean_backgrounds_wallpapers_HD;
            this.mainView.Controls.Add(this.saaPanel2);
            this.mainView.Location = new System.Drawing.Point(0, 0);
            this.mainView.Name = "mainView";
            this.mainView.Size = new System.Drawing.Size(701, 776);
            this.mainView.TabIndex = 2;
            // 
            // saaPanel2
            // 
            this.saaPanel2.BackColor = System.Drawing.Color.White;
            this.saaPanel2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaPanel2.BackColorAngle = 90F;
            this.saaPanel2.Border = 0;
            this.saaPanel2.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaPanel2.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaPanel2.BorderColorAngle = 0;
            this.saaPanel2.ColorType = SaaUI.PanelColorType.Default;
            this.saaPanel2.Controls.Add(this.guna2Button1);
            this.saaPanel2.Controls.Add(this.saaLabel3);
            this.saaPanel2.Controls.Add(this.saaLabel2);
            this.saaPanel2.Controls.Add(this.txtUsername);
            this.saaPanel2.Controls.Add(this.txtPassword);
            this.saaPanel2.Controls.Add(this.guna2Panel1);
            this.saaPanel2.Controls.Add(this.saaLabel1);
            this.saaPanel2.EnableDoubleBuffering = true;
            this.saaPanel2.ForceDrawRegion = true;
            this.saaPanel2.Location = new System.Drawing.Point(68, 53);
            this.saaPanel2.Name = "saaPanel2";
            this.saaPanel2.Radius.BottomLeft = 15;
            this.saaPanel2.Radius.BottomRight = 15;
            this.saaPanel2.Radius.TopLeft = 15;
            this.saaPanel2.Radius.TopRight = 15;
            this.saaPanel2.Size = new System.Drawing.Size(566, 681);
            this.saaPanel2.TabIndex = 3;
            this.saaPanel2.Transparence = 100;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Black;
            this.guna2Button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(107, 512);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(367, 68);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "Login";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // saaLabel3
            // 
            this.saaLabel3.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel3.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saaLabel3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.saaLabel3.Location = new System.Drawing.Point(107, 377);
            this.saaLabel3.Name = "saaLabel3";
            this.saaLabel3.Size = new System.Drawing.Size(150, 34);
            this.saaLabel3.TabIndex = 3;
            this.saaLabel3.Text = "Password";
            // 
            // saaLabel2
            // 
            this.saaLabel2.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel2.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saaLabel2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.saaLabel2.Location = new System.Drawing.Point(109, 265);
            this.saaLabel2.Name = "saaLabel2";
            this.saaLabel2.Size = new System.Drawing.Size(150, 34);
            this.saaLabel2.TabIndex = 3;
            this.saaLabel2.Text = "Email";
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSizing = true;
            this.txtUsername.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsername.Location = new System.Drawing.Point(107, 307);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(363, 31);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSizing = true;
            this.txtPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtPassword.Location = new System.Drawing.Point(107, 414);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(363, 31);
            this.txtPassword.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BackgroundImage = global::srvlocal_gui.Properties.Resources.google_icon_131222;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Panel1.Location = new System.Drawing.Point(107, 107);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(110, 104);
            this.guna2Panel1.TabIndex = 0;
            // 
            // saaLabel1
            // 
            this.saaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel1.Font = new System.Drawing.Font("Segoe UI Variable Display", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saaLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saaLabel1.Location = new System.Drawing.Point(223, 134);
            this.saaLabel1.Name = "saaLabel1";
            this.saaLabel1.Size = new System.Drawing.Size(251, 51);
            this.saaLabel1.TabIndex = 1;
            this.saaLabel1.Text = "-Cloud Login";
            // 
            // GoogleLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 766);
            this.Controls.Add(this.mainView);
            this.Controls.Add(this.loading);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 822);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 822);
            this.Name = "GoogleLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G-Cloud Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GoogleLogin_Load);
            this.loading.ResumeLayout(false);
            this.mainView.ResumeLayout(false);
            this.saaPanel2.ResumeLayout(false);
            this.saaPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SaaUI.SaaPreloader saaPreloader1;
        private SaaUI.SaaPanel loading;
        private Guna.UI2.WinForms.Guna2Panel mainView;
        private SaaUI.SaaPanel saaPanel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private SaaUI.SaaLabel saaLabel3;
        private SaaUI.SaaLabel saaLabel2;
        private SaaUI.SaaTextBox txtUsername;
        private SaaUI.SaaTextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private SaaUI.SaaLabel saaLabel1;
    }
}