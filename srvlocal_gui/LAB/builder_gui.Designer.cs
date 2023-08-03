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
            updater = new System.Windows.Forms.Timer(components);
            mainView = new SplitContainer();
            codeEditor = new ICSharpCode.TextEditor.TextEditorControlEx();
            menuStrip1 = new MenuStrip();
            cmbLanguage = new ToolStripComboBox();
            txtFileName = new ToolStripTextBox();
            contextMenuStripEx1 = new ICSharpCode.TextEditor.UserControls.ContextMenuStripEx();
            dateiDrop.SuspendLayout();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainView).BeginInit();
            mainView.Panel2.SuspendLayout();
            mainView.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // fileMenu
            // 
            fileMenu.BackColor = Color.FromArgb(43, 43, 43);
            fileMenu.DropDown = dateiDrop;
            fileMenu.ForeColor = Color.FromArgb(220, 220, 220);
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(69, 29);
            fileMenu.Text = "&Datei";
            fileMenu.Click += fileMenu_Click;
            // 
            // dateiDrop
            // 
            dateiDrop.ImageScalingSize = new Size(24, 24);
            dateiDrop.Items.AddRange(new ToolStripItem[] { neuToolStripMenuItem, öffnenToolStripMenuItem, startfensterToolStripMenuItem, hinzufügenToolStripMenuItem, hinzufügenToolStripMenuItem1, dToolStripMenuItem, schließenToolStripMenuItem, projektSchließenToolStripMenuItem, dToolStripMenuItem1, allesSpeichernToolStripMenuItem, aktuelleDateiSpeichernToolStripMenuItem, aktuelleDateiSpeichernUnterToolStripMenuItem, dToolStripMenuItem2, beendenToolStripMenuItem });
            dateiDrop.Name = "contextMenuStrip1";
            dateiDrop.OwnerItem = fileMenu;
            dateiDrop.Size = new Size(322, 348);
            // 
            // neuToolStripMenuItem
            // 
            neuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { projektToolStripMenuItem, dateiToolStripMenuItem, toolStripMenuItem2, dToolStripMenuItem3, projectAusVorhandenemCodeToolStripMenuItem });
            neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            neuToolStripMenuItem.Size = new Size(321, 32);
            neuToolStripMenuItem.Text = "&Neu";
            neuToolStripMenuItem.Click += neuToolStripMenuItem_Click;
            // 
            // projektToolStripMenuItem
            // 
            projektToolStripMenuItem.Name = "projektToolStripMenuItem";
            projektToolStripMenuItem.Size = new Size(363, 34);
            projektToolStripMenuItem.Text = "Projekt";
            projektToolStripMenuItem.Click += NewProject;
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(363, 34);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(363, 34);
            toolStripMenuItem2.Text = "Repository";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // dToolStripMenuItem3
            // 
            dToolStripMenuItem3.Name = "dToolStripMenuItem3";
            dToolStripMenuItem3.Size = new Size(360, 6);
            // 
            // projectAusVorhandenemCodeToolStripMenuItem
            // 
            projectAusVorhandenemCodeToolStripMenuItem.Name = "projectAusVorhandenemCodeToolStripMenuItem";
            projectAusVorhandenemCodeToolStripMenuItem.Size = new Size(363, 34);
            projectAusVorhandenemCodeToolStripMenuItem.Text = "Projekt aus vorhandenem Code";
            projectAusVorhandenemCodeToolStripMenuItem.Click += projectAusVorhandenemCodeToolStripMenuItem_Click;
            // 
            // öffnenToolStripMenuItem
            // 
            öffnenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { projektProjektmappeToolStripMenuItem, ordnerToolStripMenuItem, toolStripSeparator3, dateiToolStripMenuItem1 });
            öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            öffnenToolStripMenuItem.Size = new Size(321, 32);
            öffnenToolStripMenuItem.Text = "&Öffnen";
            // 
            // projektProjektmappeToolStripMenuItem
            // 
            projektProjektmappeToolStripMenuItem.Name = "projektProjektmappeToolStripMenuItem";
            projektProjektmappeToolStripMenuItem.Size = new Size(287, 34);
            projektProjektmappeToolStripMenuItem.Text = "Projekt/Projektmappe";
            projektProjektmappeToolStripMenuItem.Click += projektProjektmappeToolStripMenuItem_Click;
            // 
            // ordnerToolStripMenuItem
            // 
            ordnerToolStripMenuItem.Name = "ordnerToolStripMenuItem";
            ordnerToolStripMenuItem.Size = new Size(287, 34);
            ordnerToolStripMenuItem.Text = "Ordner";
            ordnerToolStripMenuItem.Click += ordnerToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(284, 6);
            // 
            // dateiToolStripMenuItem1
            // 
            dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            dateiToolStripMenuItem1.Size = new Size(287, 34);
            dateiToolStripMenuItem1.Text = "Datei";
            dateiToolStripMenuItem1.Click += dateiToolStripMenuItem1_Click;
            // 
            // startfensterToolStripMenuItem
            // 
            startfensterToolStripMenuItem.Name = "startfensterToolStripMenuItem";
            startfensterToolStripMenuItem.Size = new Size(321, 32);
            startfensterToolStripMenuItem.Text = "&Startfenster";
            startfensterToolStripMenuItem.Click += startfensterToolStripMenuItem_Click;
            // 
            // hinzufügenToolStripMenuItem
            // 
            hinzufügenToolStripMenuItem.Name = "hinzufügenToolStripMenuItem";
            hinzufügenToolStripMenuItem.Size = new Size(318, 6);
            // 
            // hinzufügenToolStripMenuItem1
            // 
            hinzufügenToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { neuesProjektToolStripMenuItem, vorhandenesProjektToolStripMenuItem });
            hinzufügenToolStripMenuItem1.Name = "hinzufügenToolStripMenuItem1";
            hinzufügenToolStripMenuItem1.Size = new Size(321, 32);
            hinzufügenToolStripMenuItem1.Text = "Hinzufügen";
            // 
            // neuesProjektToolStripMenuItem
            // 
            neuesProjektToolStripMenuItem.Name = "neuesProjektToolStripMenuItem";
            neuesProjektToolStripMenuItem.Size = new Size(277, 34);
            neuesProjektToolStripMenuItem.Text = "Neues Projekt";
            // 
            // vorhandenesProjektToolStripMenuItem
            // 
            vorhandenesProjektToolStripMenuItem.Name = "vorhandenesProjektToolStripMenuItem";
            vorhandenesProjektToolStripMenuItem.Size = new Size(277, 34);
            vorhandenesProjektToolStripMenuItem.Text = "Vorhandenes Projekt";
            // 
            // dToolStripMenuItem
            // 
            dToolStripMenuItem.Name = "dToolStripMenuItem";
            dToolStripMenuItem.Size = new Size(318, 6);
            // 
            // schließenToolStripMenuItem
            // 
            schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            schließenToolStripMenuItem.Size = new Size(321, 32);
            schließenToolStripMenuItem.Text = "&Schließen";
            // 
            // projektSchließenToolStripMenuItem
            // 
            projektSchließenToolStripMenuItem.Name = "projektSchließenToolStripMenuItem";
            projektSchließenToolStripMenuItem.Size = new Size(321, 32);
            projektSchließenToolStripMenuItem.Text = "&Projekt schließen";
            // 
            // dToolStripMenuItem1
            // 
            dToolStripMenuItem1.Name = "dToolStripMenuItem1";
            dToolStripMenuItem1.Size = new Size(318, 6);
            // 
            // allesSpeichernToolStripMenuItem
            // 
            allesSpeichernToolStripMenuItem.Name = "allesSpeichernToolStripMenuItem";
            allesSpeichernToolStripMenuItem.Size = new Size(321, 32);
            allesSpeichernToolStripMenuItem.Text = "&Alles Speichern";
            // 
            // aktuelleDateiSpeichernToolStripMenuItem
            // 
            aktuelleDateiSpeichernToolStripMenuItem.Name = "aktuelleDateiSpeichernToolStripMenuItem";
            aktuelleDateiSpeichernToolStripMenuItem.Size = new Size(321, 32);
            aktuelleDateiSpeichernToolStripMenuItem.Text = "Aktuelle Datei Speichern";
            // 
            // aktuelleDateiSpeichernUnterToolStripMenuItem
            // 
            aktuelleDateiSpeichernUnterToolStripMenuItem.Name = "aktuelleDateiSpeichernUnterToolStripMenuItem";
            aktuelleDateiSpeichernUnterToolStripMenuItem.Size = new Size(321, 32);
            aktuelleDateiSpeichernUnterToolStripMenuItem.Text = "Aktuelle Datei Speichern unter";
            // 
            // dToolStripMenuItem2
            // 
            dToolStripMenuItem2.Name = "dToolStripMenuItem2";
            dToolStripMenuItem2.Size = new Size(318, 6);
            // 
            // beendenToolStripMenuItem
            // 
            beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            beendenToolStripMenuItem.Size = new Size(321, 32);
            beendenToolStripMenuItem.Text = "&Beenden";
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(32, 32, 32);
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { status });
            statusStrip.Location = new Point(0, 1023);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(2, 0, 22, 0);
            statusStrip.Size = new Size(1828, 32);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // status
            // 
            status.ForeColor = SystemColors.ButtonFace;
            status.Name = "status";
            status.Size = new Size(60, 25);
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
            editMenu.Size = new Size(111, 29);
            editMenu.Text = "&Bearbeiten";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            undoToolStripMenuItem.Image = (Image)resources.GetObject("undoToolStripMenuItem.Image");
            undoToolStripMenuItem.ImageTransparentColor = Color.Black;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(298, 34);
            undoToolStripMenuItem.Text = "&Rückgängig";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            redoToolStripMenuItem.Image = (Image)resources.GetObject("redoToolStripMenuItem.Image");
            redoToolStripMenuItem.ImageTransparentColor = Color.Black;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(298, 34);
            redoToolStripMenuItem.Text = "&Wiederholen";
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new Size(295, 6);
            // 
            // codealligmentToolStripMenuItem
            // 
            codealligmentToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            codealligmentToolStripMenuItem.Name = "codealligmentToolStripMenuItem";
            codealligmentToolStripMenuItem.Size = new Size(298, 34);
            codealligmentToolStripMenuItem.Text = "Codealligment";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.ForeColor = Color.FromArgb(220, 220, 220);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(298, 34);
            toolStripMenuItem1.Text = "Visaforce";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(295, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = Color.Black;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(298, 34);
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
            copyToolStripMenuItem.Size = new Size(298, 34);
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
            pasteToolStripMenuItem.Size = new Size(298, 34);
            pasteToolStripMenuItem.Text = "&Einfügen";
            pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(295, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(298, 34);
            selectAllToolStripMenuItem.Text = "&Alle auswählen";
            // 
            // viewMenu
            // 
            viewMenu.BackColor = Color.FromArgb(43, 43, 43);
            viewMenu.DropDownItems.AddRange(new ToolStripItem[] { codeToolStripMenuItem, designerToolStripMenuItem, toolStripSeparator9, toolboxToolStripMenuItem, dateiexplorerToolStripMenuItem, eigenschaftenToolStripMenuItem, teamexplorerToolStripMenuItem, toolStripSeparator11, terminalToolStripMenuItem, toolStripSeparator10, toolBarToolStripMenuItem, statusBarToolStripMenuItem });
            viewMenu.ForeColor = Color.FromArgb(220, 220, 220);
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new Size(86, 29);
            viewMenu.Text = "&Ansicht";
            // 
            // codeToolStripMenuItem
            // 
            codeToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            codeToolStripMenuItem.Name = "codeToolStripMenuItem";
            codeToolStripMenuItem.Size = new Size(223, 34);
            codeToolStripMenuItem.Text = "Code";
            // 
            // designerToolStripMenuItem
            // 
            designerToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            designerToolStripMenuItem.Name = "designerToolStripMenuItem";
            designerToolStripMenuItem.Size = new Size(223, 34);
            designerToolStripMenuItem.Text = "Designer";
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(220, 6);
            // 
            // toolboxToolStripMenuItem
            // 
            toolboxToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            toolboxToolStripMenuItem.Name = "toolboxToolStripMenuItem";
            toolboxToolStripMenuItem.Size = new Size(223, 34);
            toolboxToolStripMenuItem.Text = "Toolbox";
            toolboxToolStripMenuItem.Click += toolboxToolStripMenuItem_Click;
            // 
            // dateiexplorerToolStripMenuItem
            // 
            dateiexplorerToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            dateiexplorerToolStripMenuItem.Name = "dateiexplorerToolStripMenuItem";
            dateiexplorerToolStripMenuItem.Size = new Size(223, 34);
            dateiexplorerToolStripMenuItem.Text = "Dateiexplorer";
            // 
            // eigenschaftenToolStripMenuItem
            // 
            eigenschaftenToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            eigenschaftenToolStripMenuItem.Name = "eigenschaftenToolStripMenuItem";
            eigenschaftenToolStripMenuItem.Size = new Size(223, 34);
            eigenschaftenToolStripMenuItem.Text = "Eigenschaften";
            // 
            // teamexplorerToolStripMenuItem
            // 
            teamexplorerToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            teamexplorerToolStripMenuItem.Name = "teamexplorerToolStripMenuItem";
            teamexplorerToolStripMenuItem.Size = new Size(223, 34);
            teamexplorerToolStripMenuItem.Text = "Teamexplorer";
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(220, 6);
            // 
            // terminalToolStripMenuItem
            // 
            terminalToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            terminalToolStripMenuItem.Name = "terminalToolStripMenuItem";
            terminalToolStripMenuItem.Size = new Size(223, 34);
            terminalToolStripMenuItem.Text = "Terminal";
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(220, 6);
            // 
            // toolBarToolStripMenuItem
            // 
            toolBarToolStripMenuItem.Checked = true;
            toolBarToolStripMenuItem.CheckOnClick = true;
            toolBarToolStripMenuItem.CheckState = CheckState.Checked;
            toolBarToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            toolBarToolStripMenuItem.Size = new Size(223, 34);
            toolBarToolStripMenuItem.Text = "&Symbolleiste";
            toolBarToolStripMenuItem.Click += ToolBarToolStripMenuItem_Click;
            // 
            // statusBarToolStripMenuItem
            // 
            statusBarToolStripMenuItem.Checked = true;
            statusBarToolStripMenuItem.CheckOnClick = true;
            statusBarToolStripMenuItem.CheckState = CheckState.Checked;
            statusBarToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            statusBarToolStripMenuItem.Size = new Size(223, 34);
            statusBarToolStripMenuItem.Text = "Status&leiste";
            statusBarToolStripMenuItem.Click += StatusBarToolStripMenuItem_Click;
            // 
            // projectToolStripMenuItem
            // 
            projectToolStripMenuItem.BackColor = Color.FromArgb(43, 43, 43);
            projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { formANewWindowToolStripMenuItem, addSideSidefileToolStripMenuItem });
            projectToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            projectToolStripMenuItem.Size = new Size(82, 29);
            projectToolStripMenuItem.Text = "&Project";
            // 
            // formANewWindowToolStripMenuItem
            // 
            formANewWindowToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            formANewWindowToolStripMenuItem.Name = "formANewWindowToolStripMenuItem";
            formANewWindowToolStripMenuItem.Size = new Size(315, 34);
            formANewWindowToolStripMenuItem.Text = "Add Form (Windowform)";
            // 
            // addSideSidefileToolStripMenuItem
            // 
            addSideSidefileToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            addSideSidefileToolStripMenuItem.Name = "addSideSidefileToolStripMenuItem";
            addSideSidefileToolStripMenuItem.Size = new Size(315, 34);
            addSideSidefileToolStripMenuItem.Text = "Add Side (Sidefile)";
            // 
            // toolsMenu
            // 
            toolsMenu.BackColor = Color.FromArgb(43, 43, 43);
            toolsMenu.DropDownItems.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            toolsMenu.ForeColor = Color.FromArgb(220, 220, 220);
            toolsMenu.Name = "toolsMenu";
            toolsMenu.Size = new Size(69, 29);
            toolsMenu.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(189, 34);
            optionsToolStripMenuItem.Text = "&Optionen";
            // 
            // windowsMenu
            // 
            windowsMenu.BackColor = Color.FromArgb(43, 43, 43);
            windowsMenu.DropDownItems.AddRange(new ToolStripItem[] { newWindowToolStripMenuItem, cascadeToolStripMenuItem, tileVerticalToolStripMenuItem, tileHorizontalToolStripMenuItem, closeAllToolStripMenuItem, arrangeIconsToolStripMenuItem });
            windowsMenu.ForeColor = Color.FromArgb(220, 220, 220);
            windowsMenu.Name = "windowsMenu";
            windowsMenu.Size = new Size(85, 29);
            windowsMenu.Text = "&Fenster";
            // 
            // newWindowToolStripMenuItem
            // 
            newWindowToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            newWindowToolStripMenuItem.Size = new Size(264, 34);
            newWindowToolStripMenuItem.Text = "&Neues Fenster";
            newWindowToolStripMenuItem.Click += ShowNewForm;
            // 
            // cascadeToolStripMenuItem
            // 
            cascadeToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new Size(264, 34);
            cascadeToolStripMenuItem.Text = "Ü&berlappend";
            cascadeToolStripMenuItem.Click += CascadeToolStripMenuItem_Click;
            // 
            // tileVerticalToolStripMenuItem
            // 
            tileVerticalToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            tileVerticalToolStripMenuItem.Size = new Size(264, 34);
            tileVerticalToolStripMenuItem.Text = "&Nebeneinander";
            tileVerticalToolStripMenuItem.Click += TileVerticalToolStripMenuItem_Click;
            // 
            // tileHorizontalToolStripMenuItem
            // 
            tileHorizontalToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            tileHorizontalToolStripMenuItem.Size = new Size(264, 34);
            tileHorizontalToolStripMenuItem.Text = "&Untereinander";
            tileHorizontalToolStripMenuItem.Click += TileHorizontalToolStripMenuItem_Click;
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(264, 34);
            closeAllToolStripMenuItem.Text = "&Alle schließen";
            closeAllToolStripMenuItem.Click += CloseAllToolStripMenuItem_Click;
            // 
            // arrangeIconsToolStripMenuItem
            // 
            arrangeIconsToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            arrangeIconsToolStripMenuItem.Size = new Size(264, 34);
            arrangeIconsToolStripMenuItem.Text = "Symbole &anordnen";
            arrangeIconsToolStripMenuItem.Click += ArrangeIconsToolStripMenuItem_Click;
            // 
            // helpMenu
            // 
            helpMenu.BackColor = Color.FromArgb(43, 43, 43);
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] { contentsToolStripMenuItem, searchToolStripMenuItem, indexToolStripMenuItem, toolStripSeparator8, aboutToolStripMenuItem });
            helpMenu.ForeColor = Color.FromArgb(220, 220, 220);
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(64, 29);
            helpMenu.Text = "&Hilfe";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.BackColor = SystemColors.Control;
            contentsToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F1;
            contentsToolStripMenuItem.Size = new Size(233, 34);
            contentsToolStripMenuItem.Text = "&Inhalt";
            contentsToolStripMenuItem.Click += contentsToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.BackColor = SystemColors.Control;
            searchToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            searchToolStripMenuItem.Image = (Image)resources.GetObject("searchToolStripMenuItem.Image");
            searchToolStripMenuItem.ImageTransparentColor = Color.Black;
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(233, 34);
            searchToolStripMenuItem.Text = "&Suchen";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.BackColor = SystemColors.Control;
            indexToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            indexToolStripMenuItem.Image = (Image)resources.GetObject("indexToolStripMenuItem.Image");
            indexToolStripMenuItem.ImageTransparentColor = Color.Black;
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new Size(233, 34);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(230, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.BackColor = SystemColors.Control;
            aboutToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(233, 34);
            aboutToolStripMenuItem.Text = "&Info... ...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // menuStrip
            // 
            menuStrip.AllowItemReorder = true;
            menuStrip.AllowMerge = false;
            menuStrip.BackColor = Color.FromArgb(21, 21, 21);
            menuStrip.ContextMenuStrip = contextMenuStrip1;
            menuStrip.ForeColor = Color.FromArgb(220, 220, 220);
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, viewMenu, projectToolStripMenuItem, toolsMenu, windowsMenu, helpMenu });
            menuStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
            menuStrip.Location = new Point(0, 0);
            menuStrip.MdiWindowListItem = windowsMenu;
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(10, 4, 0, 4);
            menuStrip.Size = new Size(1828, 37);
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
            contextMenuStrip1.Size = new Size(159, 68);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(158, 32);
            toolStripMenuItem3.Text = "Neu";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(158, 32);
            toolStripMenuItem4.Text = "Schließen";
            // 
            // updater
            // 
            updater.Enabled = true;
            updater.Tick += updater_Tick;
            // 
            // mainView
            // 
            mainView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainView.Location = new Point(0, 40);
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
            mainView.Panel2.Controls.Add(codeEditor);
            mainView.Panel2.Controls.Add(menuStrip1);
            mainView.Size = new Size(1828, 1012);
            mainView.SplitterDistance = 302;
            mainView.TabIndex = 6;
            // 
            // codeEditor
            // 
            codeEditor.ContextMenuEnabled = true;
            codeEditor.ContextMenuShowDefaultIcons = true;
            codeEditor.ContextMenuShowShortCutKeys = true;
            codeEditor.Dock = DockStyle.Fill;
            codeEditor.FoldingStrategy = "C#";
            codeEditor.Font = new Font("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point);
            codeEditor.HideVScrollBarIfPossible = true;
            codeEditor.IsIconBarVisible = true;
            codeEditor.Location = new Point(0, 37);
            codeEditor.Margin = new Padding(4);
            codeEditor.Name = "codeEditor";
            codeEditor.ShowVRuler = false;
            codeEditor.Size = new Size(1522, 975);
            codeEditor.SyntaxHighlighting = "C#";
            codeEditor.TabIndent = 1;
            codeEditor.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.HighlightText;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cmbLanguage, txtFileName });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 2, 0, 2);
            menuStrip1.Size = new Size(1522, 37);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cmbLanguage
            // 
            cmbLanguage.Alignment = ToolStripItemAlignment.Right;
            cmbLanguage.AutoCompleteCustomSource.AddRange(new string[] { "C#", "XML" });
            cmbLanguage.BackColor = Color.Gainsboro;
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FlatStyle = FlatStyle.Standard;
            cmbLanguage.Items.AddRange(new object[] { "C#", "XML" });
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(150, 33);
            cmbLanguage.Sorted = true;
            cmbLanguage.ToolTipText = "Language";
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // txtFileName
            // 
            txtFileName.AutoSize = false;
            txtFileName.AutoToolTip = true;
            txtFileName.BackColor = SystemColors.ButtonHighlight;
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.ShortcutsEnabled = false;
            txtFileName.Size = new Size(400, 31);
            txtFileName.Text = "Unknown File";
            txtFileName.Click += toolStripTextBox1_Click;
            // 
            // contextMenuStripEx1
            // 
            contextMenuStripEx1.ImageScalingSize = new Size(24, 24);
            contextMenuStripEx1.Name = "contextMenuStripEx1";
            contextMenuStripEx1.Size = new Size(61, 4);
            // 
            // builder_gui
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1828, 1055);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(mainView);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(5, 6, 5, 6);
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
            mainView.Panel2.ResumeLayout(false);
            mainView.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainView).EndInit();
            mainView.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Timer updater;
        private SplitContainer mainView;
        private ICSharpCode.TextEditor.UserControls.ContextMenuStripEx contextMenuStripEx1;
        private MenuStrip menuStrip1;
        public ToolStripComboBox cmbLanguage;
        private ICSharpCode.TextEditor.TextEditorControlEx codeEditor;
        private ToolStripTextBox txtFileName;
        private Telerik.WinControls.UI.RadSyntaxEditor radSyntaxEditor1;
    }
}



