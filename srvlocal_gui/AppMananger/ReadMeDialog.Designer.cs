namespace srvlocal_gui.AppManager
{
    partial class ReadMeDialog
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
            mdText = new MetroFramework.Drawing.Html.HtmlLabel();
            themer = new Telerik.WinControls.RadThemeManager();
            office2019LightTheme1 = new Telerik.WinControls.Themes.Office2019LightTheme();
            bntCancel = new Guna.UI2.WinForms.Guna2Button();
            bntUpdate = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            lblVersion = new Label();
            progress = new Ookii.Dialogs.WinForms.ProgressDialog(components);
            progessbar = new Guna.UI2.WinForms.Guna2ProgressBar();
            SuspendLayout();
            // 
            // mdText
            // 
            mdText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mdText.AutoScroll = true;
            mdText.AutoScrollMinSize = new Size(86, 30);
            mdText.AutoSize = false;
            mdText.BackColor = SystemColors.Window;
            mdText.Location = new Point(20, 50);
            mdText.Margin = new Padding(2);
            mdText.Name = "mdText";
            mdText.Size = new Size(474, 422);
            mdText.TabIndex = 0;
            mdText.Text = "htmlLabel1";
            // 
            // bntCancel
            // 
            bntCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bntCancel.Animated = true;
            bntCancel.BorderRadius = 15;
            bntCancel.DisabledState.BorderColor = Color.DarkGray;
            bntCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            bntCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            bntCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            bntCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bntCancel.ForeColor = Color.White;
            bntCancel.Location = new Point(356, 488);
            bntCancel.Margin = new Padding(2);
            bntCancel.Name = "bntCancel";
            bntCancel.Size = new Size(138, 34);
            bntCancel.TabIndex = 3;
            bntCancel.Text = "Cancel";
            bntCancel.Click += bntCancel_Click;
            // 
            // bntUpdate
            // 
            bntUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bntUpdate.Animated = true;
            bntUpdate.BorderRadius = 15;
            bntUpdate.DisabledState.BorderColor = Color.DarkGray;
            bntUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            bntUpdate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            bntUpdate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            bntUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bntUpdate.ForeColor = Color.White;
            bntUpdate.Location = new Point(154, 488);
            bntUpdate.Margin = new Padding(2);
            bntUpdate.Name = "bntUpdate";
            bntUpdate.Size = new Size(187, 34);
            bntUpdate.TabIndex = 3;
            bntUpdate.Text = "Update Now!";
            bntUpdate.Click += bntUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 4;
            label1.Text = "Newest Version :";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(138, 16);
            lblVersion.Margin = new Padding(2, 0, 2, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(50, 20);
            lblVersion.TabIndex = 4;
            lblVersion.Text = "label1";
            // 
            // progress
            // 
            progress.CancellationText = "Cancel";
            progress.Description = "Install Update";
            progress.ShowTimeRemaining = true;
            progress.Text = "Installing...";
            progress.WindowTitle = "Updater";
            progress.DoWork += progress_DoWork;
            // 
            // progessbar
            // 
            progessbar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progessbar.BorderColor = SystemColors.ButtonShadow;
            progessbar.BorderRadius = 15;
            progessbar.BorderThickness = 2;
            progessbar.Location = new Point(20, 486);
            progessbar.Margin = new Padding(2);
            progessbar.Name = "progessbar";
            progessbar.ProgressColor = Color.FromArgb(192, 255, 192);
            progessbar.ProgressColor2 = Color.FromArgb(0, 192, 0);
            progessbar.ShowText = true;
            progessbar.Size = new Size(474, 36);
            progessbar.TabIndex = 5;
            progessbar.Text = "guna2ProgressBar1";
            progessbar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            progessbar.Visible = false;
            // 
            // ReadMeDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(511, 538);
            Controls.Add(progessbar);
            Controls.Add(lblVersion);
            Controls.Add(label1);
            Controls.Add(bntUpdate);
            Controls.Add(bntCancel);
            Controls.Add(mdText);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(2);
            MinimumSize = new Size(457, 309);
            Name = "ReadMeDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReadMeDialog";
            FormClosing += ReadMeDialog_FormClosing;
            Load += ReadMeDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Drawing.Html.HtmlLabel mdText;
        private Telerik.WinControls.RadThemeManager themer;
        private Telerik.WinControls.Themes.Office2019LightTheme office2019LightTheme1;
        private Guna.UI2.WinForms.Guna2Button bntCancel;
        private Guna.UI2.WinForms.Guna2Button bntUpdate;
        private Label label1;
        private Label lblVersion;
        private Ookii.Dialogs.WinForms.ProgressDialog progress;
        private Guna.UI2.WinForms.Guna2ProgressBar progessbar;
    }
}