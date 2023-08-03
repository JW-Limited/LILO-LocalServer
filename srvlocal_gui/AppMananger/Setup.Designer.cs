namespace srvlocal_gui.AppManager
{
    partial class Setup
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
            radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            roundRectShapeTitle = new Telerik.WinControls.RoundRectShape(components);
            roundRectShapeForm = new Telerik.WinControls.RoundRectShape(components);
            ((System.ComponentModel.ISupportInitialize)radTitleBar1).BeginInit();
            SuspendLayout();
            // 
            // radTitleBar1
            // 
            radTitleBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radTitleBar1.Location = new Point(4, 4);
            radTitleBar1.Margin = new Padding(9, 9, 9, 9);
            radTitleBar1.Name = "radTitleBar1";
            // 
            // 
            // 
            radTitleBar1.RootElement.ApplyShapeToControl = true;
            radTitleBar1.RootElement.Shape = roundRectShapeTitle;
            radTitleBar1.Size = new Size(596, 76);
            radTitleBar1.TabIndex = 0;
            radTitleBar1.TabStop = false;
            radTitleBar1.Text = "Setuopo";
            // 
            // roundRectShapeTitle
            // 
            roundRectShapeTitle.BottomLeftRounded = false;
            roundRectShapeTitle.BottomRightRounded = false;
            // 
            // Setup
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 632);
            Controls.Add(radTitleBar1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Setup";
            Shape = roundRectShapeForm;
            Text = "Setuopo";
            ((System.ComponentModel.ISupportInitialize)radTitleBar1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.RoundRectShape roundRectShapeForm;
        private Telerik.WinControls.RoundRectShape roundRectShapeTitle;
    }
}
