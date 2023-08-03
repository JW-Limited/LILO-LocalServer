namespace srvlocal_gui.AppMananger
{
    partial class DialogBigText
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
            lblTitle = new MetroSet_UI.Controls.MetroSetLabel();
            mainText = new TextBox();
            bntMain = new Guna.UI2.WinForms.Guna2Button();
            bntSecond = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.IsDerivedStyle = true;
            lblTitle.Location = new Point(32, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(328, 48);
            lblTitle.Style = MetroSet_UI.Enums.Style.Light;
            lblTitle.StyleManager = null;
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            lblTitle.ThemeAuthor = "Narwin";
            lblTitle.ThemeName = "MetroLite";
            // 
            // mainText
            // 
            mainText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainText.BackColor = SystemColors.ButtonHighlight;
            mainText.Location = new Point(24, 72);
            mainText.Multiline = true;
            mainText.Name = "mainText";
            mainText.ReadOnly = true;
            mainText.ScrollBars = ScrollBars.Vertical;
            mainText.Size = new Size(608, 784);
            mainText.TabIndex = 1;
            // 
            // bntMain
            // 
            bntMain.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bntMain.Animated = true;
            bntMain.BorderRadius = 15;
            bntMain.DisabledState.BorderColor = Color.DarkGray;
            bntMain.DisabledState.CustomBorderColor = Color.DarkGray;
            bntMain.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            bntMain.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            bntMain.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bntMain.ForeColor = Color.White;
            bntMain.Location = new Point(24, 872);
            bntMain.Margin = new Padding(2);
            bntMain.Name = "bntMain";
            bntMain.Size = new Size(418, 42);
            bntMain.TabIndex = 4;
            bntMain.Text = "Update Now!";
            bntMain.Click += bntMain_Click;
            // 
            // bntSecond
            // 
            bntSecond.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bntSecond.Animated = true;
            bntSecond.BorderRadius = 15;
            bntSecond.DisabledState.BorderColor = Color.DarkGray;
            bntSecond.DisabledState.CustomBorderColor = Color.DarkGray;
            bntSecond.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            bntSecond.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            bntSecond.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bntSecond.ForeColor = Color.White;
            bntSecond.Location = new Point(461, 872);
            bntSecond.Margin = new Padding(2);
            bntSecond.Name = "bntSecond";
            bntSecond.Size = new Size(172, 42);
            bntSecond.TabIndex = 5;
            bntSecond.Text = "Cancel";
            bntSecond.Click += bntSecond_Click;
            // 
            // DialogBigText
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(647, 937);
            Controls.Add(bntMain);
            Controls.Add(bntSecond);
            Controls.Add(mainText);
            Controls.Add(lblTitle);
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(669, 993);
            Name = "DialogBigText";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += DialogBigText_FormClosing;
            FormClosed += DialogBigText_FormClosed;
            Load += DialogBigText_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroSet_UI.Controls.MetroSetLabel lblTitle;
        private TextBox mainText;
        private Guna.UI2.WinForms.Guna2Button bntMain;
        private Guna.UI2.WinForms.Guna2Button bntSecond;
    }
}