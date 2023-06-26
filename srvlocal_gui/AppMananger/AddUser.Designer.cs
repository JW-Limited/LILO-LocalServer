namespace srvlocal_gui.AppMananger
{
    partial class AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            saaLabel1 = new SaaUI.SaaLabel();
            saaLabel2 = new SaaUI.SaaLabel();
            saaLabel3 = new SaaUI.SaaLabel();
            saaLabel4 = new SaaUI.SaaLabel();
            saaLabel5 = new SaaUI.SaaLabel();
            saaButton1 = new SaaUI.SaaButton();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            colorPreviewPanel = new Guna.UI2.WinForms.Guna2Panel();
            colorComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            txtPassword = new Sipaa.Framework.STextBox();
            txtEmail = new Sipaa.Framework.STextBox();
            txtUser = new Sipaa.Framework.STextBox();
            panel1 = new Panel();
            saaPreloader1 = new SaaUI.SaaPreloader();
            adminPopup = new Ookii.Dialogs.WinForms.CredentialDialog(components);
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // saaLabel1
            // 
            saaLabel1.BackColor = Color.Transparent;
            saaLabel1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            saaLabel1.Location = new Point(22, 25);
            saaLabel1.Name = "saaLabel1";
            saaLabel1.Size = new Size(234, 34);
            saaLabel1.TabIndex = 0;
            saaLabel1.Text = "Add a new User :";
            // 
            // saaLabel2
            // 
            saaLabel2.BackColor = Color.Transparent;
            saaLabel2.Location = new Point(48, 50);
            saaLabel2.Name = "saaLabel2";
            saaLabel2.Size = new Size(150, 34);
            saaLabel2.TabIndex = 0;
            saaLabel2.Text = "Username";
            // 
            // saaLabel3
            // 
            saaLabel3.BackColor = Color.Transparent;
            saaLabel3.Location = new Point(48, 105);
            saaLabel3.Name = "saaLabel3";
            saaLabel3.Size = new Size(150, 34);
            saaLabel3.TabIndex = 0;
            saaLabel3.Text = "Password";
            // 
            // saaLabel4
            // 
            saaLabel4.BackColor = Color.Transparent;
            saaLabel4.Location = new Point(48, 159);
            saaLabel4.Name = "saaLabel4";
            saaLabel4.Size = new Size(150, 34);
            saaLabel4.TabIndex = 0;
            saaLabel4.Text = "Email";
            // 
            // saaLabel5
            // 
            saaLabel5.BackColor = Color.Transparent;
            saaLabel5.Location = new Point(48, 212);
            saaLabel5.Name = "saaLabel5";
            saaLabel5.Size = new Size(150, 34);
            saaLabel5.TabIndex = 0;
            saaLabel5.Text = "Favourite Color";
            // 
            // saaButton1
            // 
            saaButton1.BackColor = Color.FromArgb(64, 158, 255);
            saaButton1.BackColor2 = Color.FromArgb(64, 158, 255);
            saaButton1.BackColorAngle = 90F;
            saaButton1.Border = 1;
            saaButton1.BorderColor = Color.FromArgb(43, 133, 228);
            saaButton1.BorderColor2 = Color.FromArgb(43, 133, 228);
            saaButton1.BorderColorAngle = 0;
            saaButton1.ClickColor1 = Color.FromArgb(43, 133, 228);
            saaButton1.ClickColor2 = Color.FromArgb(92, 173, 255);
            saaButton1.EnableDoubleBuffering = true;
            saaButton1.ForeColor = SystemColors.ButtonHighlight;
            saaButton1.HoverColor1 = Color.FromArgb(64, 158, 255);
            saaButton1.HoverColor2 = Color.FromArgb(92, 173, 255);
            saaButton1.Icon = null;
            saaButton1.IconOffsetX = 5F;
            saaButton1.IconOffsetY = 5F;
            saaButton1.IconSize = new Size(20, 20);
            saaButton1.Location = new Point(48, 306);
            saaButton1.Name = "saaButton1";
            saaButton1.Radius.BottomLeft = 2;
            saaButton1.Radius.BottomRight = 2;
            saaButton1.Radius.TopLeft = 2;
            saaButton1.Radius.TopRight = 2;
            saaButton1.Size = new Size(512, 45);
            saaButton1.TabIndex = 2;
            saaButton1.TextOffsetX = 0F;
            saaButton1.TextOffsetY = 0F;
            saaButton1.Value = "Add User";
            saaButton1.Click += saaButton1_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderRadius = 20;
            guna2Panel1.Controls.Add(saaLabel1);
            guna2Panel1.FillColor = Color.Azure;
            guna2Panel1.Location = new Point(1, -7);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Size = new Size(601, 78);
            guna2Panel1.TabIndex = 3;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.Transparent;
            guna2Panel2.BorderRadius = 20;
            guna2Panel2.Controls.Add(colorPreviewPanel);
            guna2Panel2.Controls.Add(colorComboBox);
            guna2Panel2.Controls.Add(txtPassword);
            guna2Panel2.Controls.Add(txtEmail);
            guna2Panel2.Controls.Add(txtUser);
            guna2Panel2.Controls.Add(saaButton1);
            guna2Panel2.Controls.Add(saaLabel2);
            guna2Panel2.Controls.Add(saaLabel3);
            guna2Panel2.Controls.Add(saaLabel4);
            guna2Panel2.Controls.Add(saaLabel5);
            guna2Panel2.FillColor = Color.FromArgb(224, 224, 224);
            guna2Panel2.Location = new Point(1, 89);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.Size = new Size(601, 403);
            guna2Panel2.TabIndex = 3;
            // 
            // colorPreviewPanel
            // 
            colorPreviewPanel.BorderColor = Color.DarkGray;
            colorPreviewPanel.BorderRadius = 10;
            colorPreviewPanel.BorderThickness = 2;
            colorPreviewPanel.FillColor = Color.Transparent;
            colorPreviewPanel.Location = new Point(221, 210);
            colorPreviewPanel.Name = "colorPreviewPanel";
            colorPreviewPanel.Size = new Size(43, 36);
            colorPreviewPanel.TabIndex = 5;
            // 
            // colorComboBox
            // 
            colorComboBox.BackColor = Color.Transparent;
            colorComboBox.BorderRadius = 10;
            colorComboBox.BorderThickness = 0;
            colorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            colorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            colorComboBox.FocusedColor = Color.FromArgb(94, 148, 255);
            colorComboBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            colorComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            colorComboBox.ForeColor = Color.FromArgb(68, 88, 112);
            colorComboBox.ItemHeight = 30;
            colorComboBox.Location = new Point(270, 210);
            colorComboBox.Name = "colorComboBox";
            colorComboBox.Size = new Size(290, 36);
            colorComboBox.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Window;
            txtPassword.BorderColor = Color.FromArgb(224, 224, 224);
            txtPassword.BorderFocusColor = Color.HotPink;
            txtPassword.BorderRadius = 10;
            txtPassword.BorderSize = 2;
            txtPassword.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
            txtPassword.Location = new Point(221, 101);
            txtPassword.Margin = new Padding(4);
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(10, 7, 10, 7);
            txtPassword.PasswordChar = false;
            txtPassword.PlaceholderColor = Color.DarkGray;
            txtPassword.PlaceholderText = "";
            txtPassword.Size = new Size(339, 39);
            txtPassword.TabIndex = 3;
            txtPassword.Texts = "";
            txtPassword.UnderlinedStyle = false;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.Window;
            txtEmail.BorderColor = Color.FromArgb(224, 224, 224);
            txtEmail.BorderFocusColor = Color.HotPink;
            txtEmail.BorderRadius = 10;
            txtEmail.BorderSize = 2;
            txtEmail.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.ForeColor = Color.FromArgb(64, 64, 64);
            txtEmail.Location = new Point(221, 156);
            txtEmail.Margin = new Padding(4);
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Padding = new Padding(10, 7, 10, 7);
            txtEmail.PasswordChar = false;
            txtEmail.PlaceholderColor = Color.DarkGray;
            txtEmail.PlaceholderText = "";
            txtEmail.Size = new Size(339, 39);
            txtEmail.TabIndex = 3;
            txtEmail.Texts = "";
            txtEmail.UnderlinedStyle = false;
            // 
            // txtUser
            // 
            txtUser.BackColor = SystemColors.Window;
            txtUser.BorderColor = Color.FromArgb(224, 224, 224);
            txtUser.BorderFocusColor = Color.HotPink;
            txtUser.BorderRadius = 10;
            txtUser.BorderSize = 2;
            txtUser.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtUser.ForeColor = Color.FromArgb(64, 64, 64);
            txtUser.Location = new Point(221, 48);
            txtUser.Margin = new Padding(4);
            txtUser.Multiline = false;
            txtUser.Name = "txtUser";
            txtUser.Padding = new Padding(10, 7, 10, 7);
            txtUser.PasswordChar = false;
            txtUser.PlaceholderColor = Color.DarkGray;
            txtUser.PlaceholderText = "";
            txtUser.Size = new Size(339, 39);
            txtUser.TabIndex = 3;
            txtUser.Texts = "";
            txtUser.UnderlinedStyle = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(saaPreloader1);
            panel1.Location = new Point(1, 127);
            panel1.Name = "panel1";
            panel1.Size = new Size(601, 342);
            panel1.TabIndex = 4;
            panel1.Visible = false;
            // 
            // saaPreloader1
            // 
            saaPreloader1.BackColor = Color.Transparent;
            saaPreloader1.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            saaPreloader1.DashOffset = 0F;
            saaPreloader1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            saaPreloader1.LineEnd = System.Drawing.Drawing2D.LineCap.Round;
            saaPreloader1.LineStart = System.Drawing.Drawing2D.LineCap.Round;
            saaPreloader1.LoaderColor = Color.FromArgb(127, 170, 255);
            saaPreloader1.LoaderWidth = 5;
            saaPreloader1.Location = new Point(206, 74);
            saaPreloader1.Margin = new Padding(5, 6, 5, 6);
            saaPreloader1.MaxAngle = 360;
            saaPreloader1.MinAngle = 0;
            saaPreloader1.Name = "saaPreloader1";
            saaPreloader1.Reverse = false;
            saaPreloader1.Size = new Size(200, 200);
            saaPreloader1.SpeedInMilliSeconds = 20;
            saaPreloader1.Start = true;
            saaPreloader1.StepDown = 4;
            saaPreloader1.StepUp = 4;
            saaPreloader1.TabIndex = 0;
            // 
            // adminPopup
            // 
            adminPopup.AdditionalEntropy = null;
            adminPopup.DownlevelTextMode = Ookii.Dialogs.WinForms.DownlevelTextMode.MainInstructionOnly;
            adminPopup.MainInstruction = "Login";
            adminPopup.WindowTitle = "Administration";
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(599, 468);
            Controls.Add(panel1);
            Controls.Add(guna2Panel2);
            Controls.Add(guna2Panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(623, 526);
            MinimizeBox = false;
            MinimumSize = new Size(623, 526);
            Name = "AddUser";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += AddUser_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SaaUI.SaaLabel saaLabel1;
        private SaaUI.SaaLabel saaLabel2;
        private SaaUI.SaaLabel saaLabel3;
        private SaaUI.SaaLabel saaLabel4;
        private SaaUI.SaaLabel saaLabel5;
        private SaaUI.SaaButton saaButton1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Sipaa.Framework.STextBox txtPassword;
        private Sipaa.Framework.STextBox txtEmail;
        private Sipaa.Framework.STextBox txtUser;
        private Panel panel1;
        private SaaUI.SaaPreloader saaPreloader1;
        private Ookii.Dialogs.WinForms.CredentialDialog adminPopup;
        private Guna.UI2.WinForms.Guna2ComboBox colorComboBox;
        private Guna.UI2.WinForms.Guna2Panel colorPreviewPanel;
    }
}