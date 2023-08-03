namespace srvlocal_gui.LAB.TOOLS
{
    partial class ProjectExplorer
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
            Shadow = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Dragger = new Guna.UI2.WinForms.Guna2DragControl(components);
            treeTest = new DarkUI.Controls.DarkTreeView();
            timer1 = new System.Windows.Forms.Timer(components);
            metroSetContextMenuStrip1 = new MetroSet_UI.Controls.MetroSetContextMenuStrip();
            menuStrip = new DarkUI.Controls.DarkMenuStrip();
            mruItemMenu1 = new OpenMRU.WinForm.Menu.MRUItemMenu();
            mruItemMenu2 = new OpenMRU.WinForm.Menu.MRUItemMenu();
            mruItemMenu3 = new OpenMRU.WinForm.Menu.MRUItemMenu();
            headerPanel.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // Shadow
            // 
            Shadow.TargetForm = this;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(32, 32, 32);
            headerPanel.Controls.Add(guna2ControlBox1);
            headerPanel.Controls.Add(guna2HtmlLabel1);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(4, 4, 4, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(474, 40);
            headerPanel.TabIndex = 1;
            headerPanel.MouseDown += guna2Panel1_MouseDown;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.FillColor = Color.FromArgb(32, 32, 32);
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(408, -1);
            guna2ControlBox1.Margin = new Padding(4, 4, 4, 4);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.Size = new Size(66, 41);
            guna2ControlBox1.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel1.AutoSize = false;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2HtmlLabel1.ForeColor = SystemColors.ButtonFace;
            guna2HtmlLabel1.Location = new Point(8, -1);
            guna2HtmlLabel1.Margin = new Padding(4, 4, 4, 4);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(400, 41);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "      Projektmappen Explorer";
            guna2HtmlLabel1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // Dragger
            // 
            Dragger.DockForm = true;
            Dragger.DockIndicatorColor = Color.Gray;
            Dragger.DockIndicatorTransparencyValue = 1D;
            Dragger.DragStartTransparencyValue = 1D;
            Dragger.TargetControl = headerPanel;
            Dragger.UseTransparentDrag = true;
            // 
            // treeTest
            // 
            treeTest.AllowMoveNodes = true;
            treeTest.Dock = DockStyle.Fill;
            treeTest.Font = new Font("Verdana", 11F, FontStyle.Regular, GraphicsUnit.Point);
            treeTest.Location = new Point(0, 77);
            treeTest.Margin = new Padding(2);
            treeTest.MaxDragChange = 20;
            treeTest.MultiSelect = true;
            treeTest.Name = "treeTest";
            treeTest.ShowIcons = true;
            treeTest.Size = new Size(474, 941);
            treeTest.TabIndex = 0;
            treeTest.Text = "darkTreeView1";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // metroSetContextMenuStrip1
            // 
            metroSetContextMenuStrip1.ImageScalingSize = new Size(24, 24);
            metroSetContextMenuStrip1.IsDerivedStyle = true;
            metroSetContextMenuStrip1.Name = "metroSetContextMenuStrip1";
            metroSetContextMenuStrip1.Size = new Size(61, 4);
            metroSetContextMenuStrip1.Style = MetroSet_UI.Enums.Style.Light;
            metroSetContextMenuStrip1.StyleManager = null;
            metroSetContextMenuStrip1.ThemeAuthor = "Narwin";
            metroSetContextMenuStrip1.ThemeName = "MetroLite";
            // 
            // menuStrip
            // 
            menuStrip.AllowItemReorder = true;
            menuStrip.AutoSize = false;
            menuStrip.BackColor = Color.FromArgb(21, 21, 21);
            menuStrip.ForeColor = Color.FromArgb(220, 220, 220);
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { mruItemMenu3, mruItemMenu1, mruItemMenu2 });
            menuStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
            menuStrip.Location = new Point(0, 40);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(10, 4, 0, 4);
            menuStrip.Size = new Size(474, 37);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "MenuStrip";
            // 
            // mruItemMenu1
            // 
            mruItemMenu1.BackColor = Color.FromArgb(43, 43, 43);
            mruItemMenu1.ForeColor = Color.FromArgb(220, 220, 220);
            mruItemMenu1.Image = Properties.Resources.icons8_plus_math_32;
            mruItemMenu1.Name = "mruItemMenu1";
            mruItemMenu1.Size = new Size(40, 28);
            // 
            // mruItemMenu2
            // 
            mruItemMenu2.BackColor = Color.FromArgb(43, 43, 43);
            mruItemMenu2.ForeColor = Color.FromArgb(220, 220, 220);
            mruItemMenu2.Image = Properties.Resources.icons8_close_32;
            mruItemMenu2.Name = "mruItemMenu2";
            mruItemMenu2.Size = new Size(40, 28);
            // 
            // mruItemMenu3
            // 
            mruItemMenu3.BackColor = Color.FromArgb(43, 43, 43);
            mruItemMenu3.ForeColor = Color.FromArgb(220, 220, 220);
            mruItemMenu3.Image = Properties.Resources.new_32;
            mruItemMenu3.Name = "mruItemMenu3";
            mruItemMenu3.Size = new Size(40, 28);
            // 
            // ProjectExplorer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(474, 1018);
            ControlBox = false;
            Controls.Add(treeTest);
            Controls.Add(menuStrip);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            Name = "ProjectExplorer";
            Text = "ProjectExplorer";
            Load += ProjectExplorer_Load;
            headerPanel.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowForm Shadow;
        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DragControl Dragger;
        private DarkUI.Controls.DarkTreeView treeTest;
        private System.Windows.Forms.Timer timer1;
        private MetroSet_UI.Controls.MetroSetContextMenuStrip metroSetContextMenuStrip1;
        private DarkUI.Controls.DarkMenuStrip menuStrip;
        private OpenMRU.WinForm.Menu.MRUItemMenu mruItemMenu3;
        private OpenMRU.WinForm.Menu.MRUItemMenu mruItemMenu1;
        private OpenMRU.WinForm.Menu.MRUItemMenu mruItemMenu2;
    }
}