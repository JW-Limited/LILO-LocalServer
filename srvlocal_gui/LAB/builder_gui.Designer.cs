namespace srvlocal_gui.LAB
{
    partial class builder_gui
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(builder_gui));
            fileMenu = new ToolStripMenuItem();
            dateiDrop = new ContextMenuStrip(components);
            neuToolStripMenuItem = new ToolStripMenuItem();
            projektToolStripMenuItem = new ToolStripMenuItem();
            dateiToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            dToolStripMenuItem3 = new ToolStripSeparator();
            projectAusVorhandenemCodeToolStripMenuItem = new ToolStripMenuItem();
            öffnenToolStripMenuItem = new ToolStripMenuItem();
            projektProjektmappeToolStripMenuItem = new ToolStripMenuItem();
            ordnerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            dateiToolStripMenuItem1 = new ToolStripMenuItem();
            startfensterToolStripMenuItem = new ToolStripMenuItem();
            hinzufügenToolStripMenuItem = new ToolStripSeparator();
            hinzufügenToolStripMenuItem1 = new ToolStripMenuItem();
            neuesProjektToolStripMenuItem = new ToolStripMenuItem();
            vorhandenesProjektToolStripMenuItem = new ToolStripMenuItem();
            dToolStripMenuItem = new ToolStripSeparator();
            schließenToolStripMenuItem = new ToolStripMenuItem();
            projektSchließenToolStripMenuItem = new ToolStripMenuItem();
            dToolStripMenuItem1 = new ToolStripSeparator();
            allesSpeichernToolStripMenuItem = new ToolStripMenuItem();
            aktuelleDateiSpeichernToolStripMenuItem = new ToolStripMenuItem();
            aktuelleDateiSpeichernUnterToolStripMenuItem = new ToolStripMenuItem();
            dToolStripMenuItem2 = new ToolStripSeparator();
            beendenToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            status = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            clickAnimator1 = new Zeroit.Framework.Metro.ClickAnimator();
            addFile = new Ookii.Dialogs.WinForms.VistaOpenFileDialog();
            saveFile = new Ookii.Dialogs.WinForms.VistaSaveFileDialog();
            editMenu = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator12 = new ToolStripSeparator();
            codealligmentToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            viewMenu = new ToolStripMenuItem();
            codeToolStripMenuItem = new ToolStripMenuItem();
            designerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            toolboxToolStripMenuItem = new ToolStripMenuItem();
            dateiexplorerToolStripMenuItem = new ToolStripMenuItem();
            eigenschaftenToolStripMenuItem = new ToolStripMenuItem();
            teamexplorerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            terminalToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            toolBarToolStripMenuItem = new ToolStripMenuItem();
            statusBarToolStripMenuItem = new ToolStripMenuItem();
            projectToolStripMenuItem = new ToolStripMenuItem();
            formANewWindowToolStripMenuItem = new ToolStripMenuItem();
            addSideSidefileToolStripMenuItem = new ToolStripMenuItem();
            toolsMenu = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            windowsMenu = new ToolStripMenuItem();
            newWindowToolStripMenuItem = new ToolStripMenuItem();
            cascadeToolStripMenuItem = new ToolStripMenuItem();
            tileVerticalToolStripMenuItem = new ToolStripMenuItem();
            tileHorizontalToolStripMenuItem = new ToolStripMenuItem();
            closeAllToolStripMenuItem = new ToolStripMenuItem();
            arrangeIconsToolStripMenuItem = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            contentsToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            indexToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            menuStrip = new DarkUI.Controls.DarkMenuStrip();
            contextMenuStrip1 = new LABLibary.Form.DropDown(components);
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            dropDown1 = new LABLibary.Form.DropDown(components);
            updater = new System.Windows.Forms.Timer(components);
            mainView = new SplitContainer();
            contextMenuStripEx1 = new ICSharpCode.TextEditor.UserControls.ContextMenuStripEx();
            dateiDrop.SuspendLayout();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainView).BeginInit();
            mainView.SuspendLayout();
            SuspendLayout();
            // 
            // fileMenu
            // 
            fileMenu.BackColor = Color.FromArgb(43, 43, 43);
            fileMenu.DropDown = dateiDrop;
            fileMenu.ForeColor = Color.FromArgb(220, 220, 220);
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(59, 24);
            fileMenu.Text = "&Datei";
            fileMenu.Click += fileMenu_Click;
            // 
            // dateiDrop
            // 
            dateiDrop.ImageScalingSize = new Size(24, 24);
            dateiDrop.Items.AddRange(new ToolStripItem[] { neuToolStripMenuItem, öffnenToolStripMenuItem, startfensterToolStripMenuItem, hinzufügenToolStripMenuItem, hinzufügenToolStripMenuItem1, dToolStripMenuItem, schließenToolStripMenuItem, projektSchließenToolStripMenuItem, dToolStripMenuItem1, allesSpeichernToolStripMenuItem, aktuelleDateiSpeichernToolStripMenuItem, aktuelleDateiSpeichernUnterToolStripMenuItem, dToolStripMenuItem2, beendenToolStripMenuItem });
            dateiDrop.Name = "contextMenuStrip1";
            dateiDrop.OwnerItem = fileMenu;
            dateiDrop.Size = new Size(280, 268);
            // 
            // neuToolStripMenuItem
            // 
            neuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { projektToolStripMenuItem, dateiToolStripMenuItem, toolStripMenuItem2, dToolStripMenuItem3, projectAusVorhandenemCodeToolStripMenuItem });
            neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            neuToolStripMenuItem.Size = new Size(279, 24);
            neuToolStripMenuItem.Text = "&Neu";
            neuToolStripMenuItem.Click += neuToolStripMenuItem_Click;
            // 
            // projektToolStripMenuItem
            // 
            projektToolStripMenuItem.Name = "projektToolStripMenuItem";
            projektToolStripMenuItem.Size = new Size(298, 26);
            projektToolStripMenuItem.Text = "Projekt";
            projektToolStripMenuItem.Click += NewProject;
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(298, 26);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(298, 26);
            toolStripMenuItem2.Text = "Repository";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // dToolStripMenuItem3
            // 
            dToolStripMenuItem3.Name = "dToolStripMenuItem3";
            dToolStripMenuItem3.Size = new Size(295, 6);
            // 
            // projectAusVorhandenemCodeToolStripMenuItem
            // 
            projectAusVorhandenemCodeToolStripMenuItem.Name = "projectAusVorhandenemCodeToolStripMenuItem";
            projectAusVorhandenemCodeToolStripMenuItem.Size = new Size(298, 26);
            projectAusVorhandenemCodeToolStripMenuItem.Text = "Projekt aus vorhandenem Code";
            projectAusVorhandenemCodeToolStripMenuItem.Click += projectAusVorhandenemCodeToolStripMenuItem_Click;
            // 
            // öffnenToolStripMenuItem
            // 
            öffnenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { projektProjektmappeToolStripMenuItem, ordnerToolStripMenuItem, toolStripSeparator3, dateiToolStripMenuItem1 });
            öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            öffnenToolStripMenuItem.Size = new Size(279, 24);
            öffnenToolStripMenuItem.Text = "&Öffnen";
            // 
            // projektProjektmappeToolStripMenuItem
            // 
            projektProjektmappeToolStripMenuItem.Name = "projektProjektmappeToolStripMenuItem";
            projektProjektmappeToolStripMenuItem.Size = new Size(237, 26);
            projektProjektmappeToolStripMenuItem.Text = "Projekt/Projektmappe";
            projektProjektmappeToolStripMenuItem.Click += projektProjektmappeToolStripMenuItem_Click;
            // 
            // ordnerToolStripMenuItem
            // 
            ordnerToolStripMenuItem.Name = "ordnerToolStripMenuItem";
            ordnerToolStripMenuItem.Size = new Size(237, 26);
            ordnerToolStripMenuItem.Text = "Ordner";
            ordnerToolStripMenuItem.Click += ordnerToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(234, 6);
            // 
            // dateiToolStripMenuItem1
            // 
            dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            dateiToolStripMenuItem1.Size = new Size(237, 26);
            dateiToolStripMenuItem1.Text = "Datei";
            // 
            // startfensterToolStripMenuItem
            // 
            startfensterToolStripMenuItem.Name = "startfensterToolStripMenuItem";
            startfensterToolStripMenuItem.Size = new Size(279, 24);
            startfensterToolStripMenuItem.Text = "&Startfenster";
            // 
            // hinzufügenToolStripMenuItem
            // 
            hinzufügenToolStripMenuItem.Name = "hinzufügenToolStripMenuItem";
            hinzufügenToolStripMenuItem.Size = new Size(276, 6);
            // 
            // hinzufügenToolStripMenuItem1
            // 
            hinzufügenToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { neuesProjektToolStripMenuItem, vorhandenesProjektToolStripMenuItem });
            hinzufügenToolStripMenuItem1.Name = "hinzufügenToolStripMenuItem1";
            hinzufügenToolStripMenuItem1.Size = new Size(279, 24);
            hinzufügenToolStripMenuItem1.Text = "Hinzufügen";
            // 
            // neuesProjektToolStripMenuItem
            // 
            neuesProjektToolStripMenuItem.Name = "neuesProjektToolStripMenuItem";
            neuesProjektToolStripMenuItem.Size = new Size(227, 26);
            neuesProjektToolStripMenuItem.Text = "Neues Projekt";
            // 
            // vorhandenesProjektToolStripMenuItem
            // 
            vorhandenesProjektToolStripMenuItem.Name = "vorhandenesProjektToolStripMenuItem";
            vorhandenesProjektToolStripMenuItem.Size = new Size(227, 26);
            vorhandenesProjektToolStripMenuItem.Text = "Vorhandenes Projekt";
            // 
            // dToolStripMenuItem
            // 
            dToolStripMenuItem.Name = "dToolStripMenuItem";
            dToolStripMenuItem.Size = new Size(276, 6);
            // 
            // schließenToolStripMenuItem
            // 
            schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            schließenToolStripMenuItem.Size = new Size(279, 24);
            schließenToolStripMenuItem.Text = "&Schließen";
            // 
            // projektSchließenToolStripMenuItem
            // 
            projektSchließenToolStripMenuItem.Name = "projektSchließenToolStripMenuItem";
            projektSchließenToolStripMenuItem.Size = new Size(279, 24);
            projektSchließenToolStripMenuItem.Text = "&Projekt schließen";
            // 
            // dToolStripMenuItem1
            // 
            dToolStripMenuItem1.Name = "dToolStripMenuItem1";
            dToolStripMenuItem1.Size = new Size(276, 6);
            // 
            // allesSpeichernToolStripMenuItem
            // 
            allesSpeichernToolStripMenuItem.Name = "allesSpeichernToolStripMenuItem";
            allesSpeichernToolStripMenuItem.Size = new Size(279, 24);
            allesSpeichernToolStripMenuItem.Text = "&Alles Speichern";
            // 
            // aktuelleDateiSpeichernToolStripMenuItem
            // 
            aktuelleDateiSpeichernToolStripMenuItem.Name = "aktuelleDateiSpeichernToolStripMenuItem";
            aktuelleDateiSpeichernToolStripMenuItem.Size = new Size(279, 24);
            aktuelleDateiSpeichernToolStripMenuItem.Text = "Aktuelle Datei Speichern";
            // 
            // aktuelleDateiSpeichernUnterToolStripMenuItem
            // 
            aktuelleDateiSpeichernUnterToolStripMenuItem.Name = "aktuelleDateiSpeichernUnterToolStripMenuItem";
            aktuelleDateiSpeichernUnterToolStripMenuItem.Size = new Size(279, 24);
            aktuelleDateiSpeichernUnterToolStripMenuItem.Text = "Aktuelle Datei Speichern unter";
            // 
            // dToolStripMenuItem2
            // 
            dToolStripMenuItem2.Name = "dToolStripMenuItem2";
            dToolStripMenuItem2.Size = new Size(276, 6);
            // 
            // beendenToolStripMenuItem
            // 
            beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            beendenToolStripMenuItem.Size = new Size(279, 24);
            beendenToolStripMenuItem.Text = "&Beenden";
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(32, 32, 32);
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { status });
            statusStrip.Location = new Point(0, 792);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(2, 0, 18, 0);
            statusStrip.Size = new Size(1422, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // status
            // 
            status.ForeColor = SystemColors.ButtonFace;
            status.Name = "status";
            status.Size = new Size(49, 20);
            status.Text = "Status";
            // 
            // clickAnimator1
            // 
            clickAnimator1.Shape = Zeroit.Framework.Metro.ClickAnimator.DrawMode.Circle;
            // 
            // addFile
            // 
            addFile.DefaultExt = "lab";
            addFile.FileName = "addFile";
            addFile.Filter = null;
            // 
            // saveFile
            // 
            saveFile.CheckFileExists = true;
            saveFile.CreatePrompt = true;
            saveFile.DefaultExt = "labc";
            saveFile.Filter = "LAB Code(*.labc)|.labc";
            saveFile.RestoreDirectory = true;
            saveFile.ShowHelp = true;
            saveFile.Title = "Save edited _filename_ ";
            // 
            // editMenu
            // 
            editMenu.BackColor = Color.FromArgb(43, 43, 43);
            editMenu.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator12, codealligmentToolStripMenuItem, toolStripMenuItem1, toolStripSeparator6, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator7, selectAllToolStripMenuItem });
            editMenu.ForeColor = Color.FromArgb(220, 220, 220);
            editMenu.Name = "editMenu";
            editMenu.Size = new Size(95, 24);
            editMenu.Text = "&Bearbeiten";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            undoToolStripMenuItem.Image = (Image)resources.GetObject("undoToolStripMenuItem.Image");
            undoToolStripMenuItem.ImageTransparentColor = Color.Black;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(247, 26);
            undoToolStripMenuItem.Text = "&Rückgängig";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            redoToolStripMenuItem.Image = (Image)resources.GetObject("redoToolStripMenuItem.Image");
            redoToolStripMenuItem.ImageTransparentColor = Color.Black;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(247, 26);
            redoToolStripMenuItem.Text = "&Wiederholen";
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new Size(244, 6);
            // 
            // codealligmentToolStripMenuItem
            // 
            codealligmentToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            codealligmentToolStripMenuItem.Name = "codealligmentToolStripMenuItem";
            codealligmentToolStripMenuItem.Size = new Size(247, 26);
            codealligmentToolStripMenuItem.Text = "Codealligment";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.ForeColor = Color.FromArgb(220, 220, 220);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(247, 26);
            toolStripMenuItem1.Text = "Visaforce";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(244, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = Color.Black;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(247, 26);
            cutToolStripMenuItem.Text = "&Ausschneiden";
            cutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = Color.Black;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(247, 26);
            copyToolStripMenuItem.Text = "&Kopieren";
            copyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            pasteToolStripMenuItem.Image = (Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = Color.Black;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(247, 26);
            pasteToolStripMenuItem.Text = "&Einfügen";
            pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(244, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(247, 26);
            selectAllToolStripMenuItem.Text = "&Alle auswählen";
            // 
            // viewMenu
            // 
            viewMenu.BackColor = Color.FromArgb(43, 43, 43);
            viewMenu.DropDownItems.AddRange(new ToolStripItem[] { codeToolStripMenuItem, designerToolStripMenuItem, toolStripSeparator9, toolboxToolStripMenuItem, dateiexplorerToolStripMenuItem, eigenschaftenToolStripMenuItem, teamexplorerToolStripMenuItem, toolStripSeparator11, terminalToolStripMenuItem, toolStripSeparator10, toolBarToolStripMenuItem, statusBarToolStripMenuItem });
            viewMenu.ForeColor = Color.FromArgb(220, 220, 220);
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new Size(71, 24);
            viewMenu.Text = "&Ansicht";
            // 
            // codeToolStripMenuItem
            // 
            codeToolStripMenuItem.Name = "codeToolStripMenuItem";
            codeToolStripMenuItem.Size = new Size(184, 26);
            codeToolStripMenuItem.Text = "Code";
            // 
            // designerToolStripMenuItem
            // 
            designerToolStripMenuItem.Name = "designerToolStripMenuItem";
            designerToolStripMenuItem.Size = new Size(184, 26);
            designerToolStripMenuItem.Text = "Designer";
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(181, 6);
            // 
            // toolboxToolStripMenuItem
            // 
            toolboxToolStripMenuItem.Name = "toolboxToolStripMenuItem";
            toolboxToolStripMenuItem.Size = new Size(184, 26);
            toolboxToolStripMenuItem.Text = "Toolbox";
            // 
            // dateiexplorerToolStripMenuItem
            // 
            dateiexplorerToolStripMenuItem.Name = "dateiexplorerToolStripMenuItem";
            dateiexplorerToolStripMenuItem.Size = new Size(184, 26);
            dateiexplorerToolStripMenuItem.Text = "Dateiexplorer";
            // 
            // eigenschaftenToolStripMenuItem
            // 
            eigenschaftenToolStripMenuItem.Name = "eigenschaftenToolStripMenuItem";
            eigenschaftenToolStripMenuItem.Size = new Size(184, 26);
            eigenschaftenToolStripMenuItem.Text = "Eigenschaften";
            // 
            // teamexplorerToolStripMenuItem
            // 
            teamexplorerToolStripMenuItem.Name = "teamexplorerToolStripMenuItem";
            teamexplorerToolStripMenuItem.Size = new Size(184, 26);
            teamexplorerToolStripMenuItem.Text = "Teamexplorer";
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(181, 6);
            // 
            // terminalToolStripMenuItem
            // 
            terminalToolStripMenuItem.Name = "terminalToolStripMenuItem";
            terminalToolStripMenuItem.Size = new Size(184, 26);
            terminalToolStripMenuItem.Text = "Terminal";
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(181, 6);
            // 
            // toolBarToolStripMenuItem
            // 
            toolBarToolStripMenuItem.Checked = true;
            toolBarToolStripMenuItem.CheckOnClick = true;
            toolBarToolStripMenuItem.CheckState = CheckState.Checked;
            toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            toolBarToolStripMenuItem.Size = new Size(184, 26);
            toolBarToolStripMenuItem.Text = "&Symbolleiste";
            toolBarToolStripMenuItem.Click += ToolBarToolStripMenuItem_Click;
            // 
            // statusBarToolStripMenuItem
            // 
            statusBarToolStripMenuItem.Checked = true;
            statusBarToolStripMenuItem.CheckOnClick = true;
            statusBarToolStripMenuItem.CheckState = CheckState.Checked;
            statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            statusBarToolStripMenuItem.Size = new Size(184, 26);
            statusBarToolStripMenuItem.Text = "Status&leiste";
            statusBarToolStripMenuItem.Click += StatusBarToolStripMenuItem_Click;
            // 
            // projectToolStripMenuItem
            // 
            projectToolStripMenuItem.BackColor = Color.FromArgb(43, 43, 43);
            projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { formANewWindowToolStripMenuItem, addSideSidefileToolStripMenuItem });
            projectToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            projectToolStripMenuItem.Size = new Size(69, 24);
            projectToolStripMenuItem.Text = "&Project";
            // 
            // formANewWindowToolStripMenuItem
            // 
            formANewWindowToolStripMenuItem.Name = "formANewWindowToolStripMenuItem";
            formANewWindowToolStripMenuItem.Size = new Size(259, 26);
            formANewWindowToolStripMenuItem.Text = "Add Form (Windowform)";
            // 
            // addSideSidefileToolStripMenuItem
            // 
            addSideSidefileToolStripMenuItem.Name = "addSideSidefileToolStripMenuItem";
            addSideSidefileToolStripMenuItem.Size = new Size(259, 26);
            addSideSidefileToolStripMenuItem.Text = "Add Side (Sidefile)";
            // 
            // toolsMenu
            // 
            toolsMenu.BackColor = Color.FromArgb(43, 43, 43);
            toolsMenu.DropDownItems.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            toolsMenu.ForeColor = Color.FromArgb(220, 220, 220);
            toolsMenu.Name = "toolsMenu";
            toolsMenu.Size = new Size(58, 24);
            toolsMenu.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(154, 26);
            optionsToolStripMenuItem.Text = "&Optionen";
            // 
            // windowsMenu
            // 
            windowsMenu.BackColor = Color.FromArgb(43, 43, 43);
            windowsMenu.DropDownItems.AddRange(new ToolStripItem[] { newWindowToolStripMenuItem, cascadeToolStripMenuItem, tileVerticalToolStripMenuItem, tileHorizontalToolStripMenuItem, closeAllToolStripMenuItem, arrangeIconsToolStripMenuItem });
            windowsMenu.ForeColor = Color.FromArgb(220, 220, 220);
            windowsMenu.Name = "windowsMenu";
            windowsMenu.Size = new Size(70, 24);
            windowsMenu.Text = "&Fenster";
            // 
            // newWindowToolStripMenuItem
            // 
            newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            newWindowToolStripMenuItem.Size = new Size(217, 26);
            newWindowToolStripMenuItem.Text = "&Neues Fenster";
            newWindowToolStripMenuItem.Click += ShowNewForm;
            // 
            // cascadeToolStripMenuItem
            // 
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new Size(217, 26);
            cascadeToolStripMenuItem.Text = "Ü&berlappend";
            cascadeToolStripMenuItem.Click += CascadeToolStripMenuItem_Click;
            // 
            // tileVerticalToolStripMenuItem
            // 
            tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            tileVerticalToolStripMenuItem.Size = new Size(217, 26);
            tileVerticalToolStripMenuItem.Text = "&Nebeneinander";
            tileVerticalToolStripMenuItem.Click += TileVerticalToolStripMenuItem_Click;
            // 
            // tileHorizontalToolStripMenuItem
            // 
            tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            tileHorizontalToolStripMenuItem.Size = new Size(217, 26);
            tileHorizontalToolStripMenuItem.Text = "&Untereinander";
            tileHorizontalToolStripMenuItem.Click += TileHorizontalToolStripMenuItem_Click;
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(217, 26);
            closeAllToolStripMenuItem.Text = "&Alle schließen";
            closeAllToolStripMenuItem.Click += CloseAllToolStripMenuItem_Click;
            // 
            // arrangeIconsToolStripMenuItem
            // 
            arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            arrangeIconsToolStripMenuItem.Size = new Size(217, 26);
            arrangeIconsToolStripMenuItem.Text = "Symbole &anordnen";
            arrangeIconsToolStripMenuItem.Click += ArrangeIconsToolStripMenuItem_Click;
            // 
            // helpMenu
            // 
            helpMenu.BackColor = Color.FromArgb(43, 43, 43);
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] { contentsToolStripMenuItem, searchToolStripMenuItem, indexToolStripMenuItem, toolStripSeparator8, aboutToolStripMenuItem });
            helpMenu.ForeColor = Color.FromArgb(220, 220, 220);
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(55, 24);
            helpMenu.Text = "&Hilfe";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.BackColor = SystemColors.Control;
            contentsToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F1;
            contentsToolStripMenuItem.Size = new Size(190, 26);
            contentsToolStripMenuItem.Text = "&Inhalt";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.BackColor = SystemColors.Control;
            searchToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            searchToolStripMenuItem.Image = (Image)resources.GetObject("searchToolStripMenuItem.Image");
            searchToolStripMenuItem.ImageTransparentColor = Color.Black;
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(190, 26);
            searchToolStripMenuItem.Text = "&Suchen";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.BackColor = SystemColors.Control;
            indexToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            indexToolStripMenuItem.Image = (Image)resources.GetObject("indexToolStripMenuItem.Image");
            indexToolStripMenuItem.ImageTransparentColor = Color.Black;
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new Size(190, 26);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(187, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.BackColor = SystemColors.Control;
            aboutToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(190, 26);
            aboutToolStripMenuItem.Text = "&Info... ...";
            // 
            // menuStrip
            // 
            menuStrip.AllowItemReorder = true;
            menuStrip.BackColor = Color.FromArgb(21, 21, 21);
            menuStrip.ContextMenuStrip = contextMenuStrip1;
            menuStrip.ForeColor = Color.FromArgb(220, 220, 220);
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, viewMenu, projectToolStripMenuItem, toolsMenu, windowsMenu, helpMenu });
            menuStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
            menuStrip.Location = new Point(0, 0);
            menuStrip.MdiWindowListItem = windowsMenu;
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(8, 3, 0, 3);
            menuStrip.Size = new Size(1422, 30);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            menuStrip.ItemClicked += menuStrip_ItemClicked;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.IsMainMenu = false;
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem3, toolStripMenuItem4 });
            contextMenuStrip1.MenuItemHeight = 25;
            contextMenuStrip1.MenuItemTextColor = Color.Empty;
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.PrimaryColor = Color.Empty;
            contextMenuStrip1.Size = new Size(142, 52);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(141, 24);
            toolStripMenuItem3.Text = "Neu";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(141, 24);
            toolStripMenuItem4.Text = "Schließen";
            // 
            // dropDown1
            // 
            dropDown1.ImageScalingSize = new Size(24, 24);
            dropDown1.IsMainMenu = false;
            dropDown1.MenuItemHeight = 25;
            dropDown1.MenuItemTextColor = Color.Empty;
            dropDown1.Name = "dropDown1";
            dropDown1.PrimaryColor = Color.Empty;
            dropDown1.Size = new Size(61, 4);
            dropDown1.Opening += dropDown1_Opening;
            // 
            // updater
            // 
            updater.Enabled = true;
            updater.Tick += updater_Tick;
            // 
            // mainView
            // 
            mainView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainView.Location = new Point(0, 32);
            mainView.Margin = new Padding(2);
            mainView.Name = "mainView";
            // 
            // mainView.Panel1
            // 
            mainView.Panel1.BackColor = Color.White;
            // 
            // mainView.Panel2
            // 
            mainView.Panel2.BackColor = Color.White;
            mainView.Size = new Size(1422, 760);
            mainView.SplitterDistance = 298;
            mainView.SplitterWidth = 3;
            mainView.TabIndex = 6;
            // 
            // contextMenuStripEx1
            // 
            contextMenuStripEx1.ImageScalingSize = new Size(24, 24);
            contextMenuStripEx1.Name = "contextMenuStripEx1";
            contextMenuStripEx1.Size = new Size(61, 4);
            // 
            // builder_gui
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1422, 818);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(mainView);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 5, 4, 5);
            Name = "builder_gui";
            Text = "builder_gui";
            Load += builder_gui_Load;
            Shown += builder_gui_Shown;
            dateiDrop.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainView).EndInit();
            mainView.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private StatusStrip statusStrip;
        private ToolStripStatusLabel status;
        private ToolTip toolTip;
        private Zeroit.Framework.Metro.ClickAnimator clickAnimator1;
        private Ookii.Dialogs.WinForms.VistaOpenFileDialog addFile;
        private Ookii.Dialogs.WinForms.VistaSaveFileDialog saveFile;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem editMenu;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem codealligmentToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem viewMenu;
        private ToolStripMenuItem codeToolStripMenuItem;
        private ToolStripMenuItem designerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem toolboxToolStripMenuItem;
        private ToolStripMenuItem dateiexplorerToolStripMenuItem;
        private ToolStripMenuItem eigenschaftenToolStripMenuItem;
        private ToolStripMenuItem teamexplorerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem terminalToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem toolBarToolStripMenuItem;
        private ToolStripMenuItem statusBarToolStripMenuItem;
        private ToolStripMenuItem projectToolStripMenuItem;
        private ToolStripMenuItem formANewWindowToolStripMenuItem;
        private ToolStripMenuItem addSideSidefileToolStripMenuItem;
        private ToolStripMenuItem toolsMenu;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem windowsMenu;
        private ToolStripMenuItem newWindowToolStripMenuItem;
        private ToolStripMenuItem cascadeToolStripMenuItem;
        private ToolStripMenuItem tileVerticalToolStripMenuItem;
        private ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private DarkUI.Controls.DarkMenuStrip menuStrip;
        private ContextMenuStrip dateiDrop;
        private ToolStripMenuItem neuToolStripMenuItem;
        private ToolStripMenuItem öffnenToolStripMenuItem;
        private ToolStripMenuItem startfensterToolStripMenuItem;
        private ToolStripSeparator hinzufügenToolStripMenuItem;
        private ToolStripMenuItem hinzufügenToolStripMenuItem1;
        private ToolStripSeparator dToolStripMenuItem;
        private ToolStripMenuItem schließenToolStripMenuItem;
        private ToolStripMenuItem projektSchließenToolStripMenuItem;
        private ToolStripMenuItem projektToolStripMenuItem;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem projectAusVorhandenemCodeToolStripMenuItem;
        private ToolStripSeparator dToolStripMenuItem1;
        private ToolStripMenuItem allesSpeichernToolStripMenuItem;
        private ToolStripMenuItem aktuelleDateiSpeichernToolStripMenuItem;
        private ToolStripMenuItem aktuelleDateiSpeichernUnterToolStripMenuItem;
        private ToolStripSeparator dToolStripMenuItem2;
        private ToolStripMenuItem beendenToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator dToolStripMenuItem3;
        private ToolStripMenuItem projektProjektmappeToolStripMenuItem;
        private ToolStripMenuItem ordnerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem dateiToolStripMenuItem1;
        private ToolStripMenuItem neuesProjektToolStripMenuItem;
        private ToolStripMenuItem vorhandenesProjektToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private LABLibary.Form.DropDown contextMenuStrip1;
        private LABLibary.Form.DropDown dropDown1;
        private System.Windows.Forms.Timer updater;
        private SplitContainer mainView;
        private ICSharpCode.TextEditor.UserControls.ContextMenuStripEx contextMenuStripEx1;
    }
}



