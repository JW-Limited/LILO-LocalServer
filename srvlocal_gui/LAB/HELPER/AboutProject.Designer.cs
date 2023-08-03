namespace srvlocal_gui.LAB.HELPER
{
    partial class AboutProject
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
            tableLayoutPanel = new TableLayoutPanel();
            logoPictureBox = new PictureBox();
            labelVersion = new Label();
            okButton = new Button();
            txtProduct = new TextBox();
            txtAuthor = new TextBox();
            txtCompany = new TextBox();
            txtAbout = new TextBox();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
            tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(labelVersion, 1, 1);
            tableLayoutPanel.Controls.Add(okButton, 1, 5);
            tableLayoutPanel.Controls.Add(txtProduct, 1, 0);
            tableLayoutPanel.Controls.Add(txtAuthor, 1, 2);
            tableLayoutPanel.Controls.Add(txtCompany, 1, 3);
            tableLayoutPanel.Controls.Add(txtAbout, 1, 4);
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.Size = new Size(684, 533);
            tableLayoutPanel.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            logoPictureBox.BackgroundImage = Properties.Resources.Ocean_backgrounds_wallpapers_HD;
            logoPictureBox.BackgroundImageLayout = ImageLayout.Center;
            logoPictureBox.Dock = DockStyle.Fill;
            logoPictureBox.Location = new Point(5, 6);
            logoPictureBox.Margin = new Padding(5, 6, 5, 6);
            logoPictureBox.Name = "logoPictureBox";
            tableLayoutPanel.SetRowSpan(logoPictureBox, 6);
            logoPictureBox.Size = new Size(215, 521);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 12;
            logoPictureBox.TabStop = false;
            // 
            // labelVersion
            // 
            labelVersion.Dock = DockStyle.Fill;
            labelVersion.Location = new Point(235, 53);
            labelVersion.Margin = new Padding(10, 0, 5, 0);
            labelVersion.MaximumSize = new Size(0, 32);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(444, 32);
            labelVersion.TabIndex = 0;
            labelVersion.Text = "Version";
            labelVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.Cancel;
            okButton.Location = new Point(232, 488);
            okButton.Margin = new Padding(5, 6, 5, 6);
            okButton.Name = "okButton";
            okButton.Size = new Size(447, 39);
            okButton.TabIndex = 24;
            okButton.Text = "&Save";
            // 
            // txtProduct
            // 
            txtProduct.Dock = DockStyle.Fill;
            txtProduct.Location = new Point(229, 4);
            txtProduct.Margin = new Padding(4);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(451, 31);
            txtProduct.TabIndex = 25;
            // 
            // txtAuthor
            // 
            txtAuthor.Dock = DockStyle.Fill;
            txtAuthor.Location = new Point(229, 110);
            txtAuthor.Margin = new Padding(4);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(451, 31);
            txtAuthor.TabIndex = 26;
            // 
            // txtCompany
            // 
            txtCompany.Dock = DockStyle.Fill;
            txtCompany.Location = new Point(229, 163);
            txtCompany.Margin = new Padding(4);
            txtCompany.Name = "txtCompany";
            txtCompany.Size = new Size(451, 31);
            txtCompany.TabIndex = 27;
            // 
            // txtAbout
            // 
            txtAbout.Dock = DockStyle.Fill;
            txtAbout.Location = new Point(229, 216);
            txtAbout.Margin = new Padding(4);
            txtAbout.Multiline = true;
            txtAbout.Name = "txtAbout";
            txtAbout.Size = new Size(451, 258);
            txtAbout.TabIndex = 28;
            // 
            // AboutProject
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 534);
            ControlBox = false;
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(4);
            MaximumSize = new Size(708, 590);
            MinimumSize = new Size(708, 590);
            Name = "AboutProject";
            ShowIcon = false;
            Text = "About Project";
            Load += AboutProject_Load;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel;
        private PictureBox logoPictureBox;
        private Label labelVersion;
        private Button okButton;
        private TextBox txtProduct;
        private TextBox txtAuthor;
        private TextBox txtCompany;
        private TextBox txtAbout;
    }
}