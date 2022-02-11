namespace MoreClothingGUI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.editEntryArguments = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fastColoredTextBoxLeft = new FastColoredTextBoxNS.FastColoredTextBox();
            this.fastColoredTextBoxRight = new FastColoredTextBoxNS.FastColoredTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleOrientationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxRight)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editEntryArguments
            // 
            this.editEntryArguments.BackColor = System.Drawing.SystemColors.Control;
            this.editEntryArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editEntryArguments.Location = new System.Drawing.Point(0, 0);
            this.editEntryArguments.Margin = new System.Windows.Forms.Padding(9);
            this.editEntryArguments.Name = "editEntryArguments";
            this.editEntryArguments.Size = new System.Drawing.Size(591, 32);
            this.editEntryArguments.TabIndex = 0;
            this.editEntryArguments.Text = "Edit Entry Arguments";
            this.editEntryArguments.UseVisualStyleBackColor = false;
            this.editEntryArguments.Click += new System.EventHandler(this.editEntryArguments_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.menuStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 681);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 657);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.fastColoredTextBoxLeft);
            this.splitContainer1.Panel1MinSize = 320;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fastColoredTextBoxRight);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 657);
            this.splitContainer1.SplitterDistance = 591;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.panel3.Controls.Add(this.editEntryArguments);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 625);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 32);
            this.panel3.TabIndex = 3;
            // 
            // fastColoredTextBoxLeft
            // 
            this.fastColoredTextBoxLeft.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBoxLeft.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fastColoredTextBoxLeft.BackBrush = null;
            this.fastColoredTextBoxLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.fastColoredTextBoxLeft.CharHeight = 14;
            this.fastColoredTextBoxLeft.CharWidth = 8;
            this.fastColoredTextBoxLeft.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBoxLeft.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBoxLeft.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBoxLeft.ForeColor = System.Drawing.Color.White;
            this.fastColoredTextBoxLeft.Hotkeys = resources.GetString("fastColoredTextBoxLeft.Hotkeys");
            this.fastColoredTextBoxLeft.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.fastColoredTextBoxLeft.IsReplaceMode = false;
            this.fastColoredTextBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.fastColoredTextBoxLeft.Name = "fastColoredTextBoxLeft";
            this.fastColoredTextBoxLeft.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBoxLeft.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBoxLeft.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBoxLeft.ServiceColors")));
            this.fastColoredTextBoxLeft.ServiceLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.fastColoredTextBoxLeft.Size = new System.Drawing.Size(591, 657);
            this.fastColoredTextBoxLeft.TabIndex = 0;
            this.fastColoredTextBoxLeft.Zoom = 100;
            this.fastColoredTextBoxLeft.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBoxLeft_TextChanged);
            this.fastColoredTextBoxLeft.SelectionChangedDelayed += new System.EventHandler(this.fastColoredTextBoxLeft_SelectionChangedDelayed);
            this.fastColoredTextBoxLeft.CustomAction += new System.EventHandler<FastColoredTextBoxNS.CustomActionEventArgs>(this.fastColoredTextBoxLeft_CustomAction);
            this.fastColoredTextBoxLeft.Click += new System.EventHandler(this.fastColoredTextBoxLeft_Click);
            // 
            // fastColoredTextBoxRight
            // 
            this.fastColoredTextBoxRight.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBoxRight.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fastColoredTextBoxRight.BackBrush = null;
            this.fastColoredTextBoxRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.fastColoredTextBoxRight.CharHeight = 14;
            this.fastColoredTextBoxRight.CharWidth = 8;
            this.fastColoredTextBoxRight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBoxRight.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBoxRight.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBoxRight.ForeColor = System.Drawing.Color.White;
            this.fastColoredTextBoxRight.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.fastColoredTextBoxRight.IsReplaceMode = false;
            this.fastColoredTextBoxRight.Location = new System.Drawing.Point(0, 0);
            this.fastColoredTextBoxRight.Name = "fastColoredTextBoxRight";
            this.fastColoredTextBoxRight.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBoxRight.ReadOnly = true;
            this.fastColoredTextBoxRight.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBoxRight.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBoxRight.ServiceColors")));
            this.fastColoredTextBoxRight.ServiceLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.fastColoredTextBoxRight.Size = new System.Drawing.Size(653, 657);
            this.fastColoredTextBoxRight.TabIndex = 0;
            this.fastColoredTextBoxRight.Zoom = 100;
            this.fastColoredTextBoxRight.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBoxRight_TextChanged);
            this.fastColoredTextBoxRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fastColoredTextBoxRight_MouseDown);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.cacheToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.testToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.testToolStripMenuItem.Text = "Open Loader Folder";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem1,
            this.redoToolStripMenuItem1});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem1
            // 
            this.undoToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.undoToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.undoToolStripMenuItem1.Name = "undoToolStripMenuItem1";
            this.undoToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem1.Text = "Undo";
            this.undoToolStripMenuItem1.Click += new System.EventHandler(this.undoToolStripMenuItem1_Click);
            // 
            // redoToolStripMenuItem1
            // 
            this.redoToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.redoToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.redoToolStripMenuItem1.Name = "redoToolStripMenuItem1";
            this.redoToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem1.Text = "Redo";
            this.redoToolStripMenuItem1.Click += new System.EventHandler(this.redoToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.toggleOrientationToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.zoomInToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom in";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.zoomOutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // toggleOrientationToolStripMenuItem
            // 
            this.toggleOrientationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.toggleOrientationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.toggleOrientationToolStripMenuItem.Name = "toggleOrientationToolStripMenuItem";
            this.toggleOrientationToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.toggleOrientationToolStripMenuItem.Text = "Toggle orientation";
            this.toggleOrientationToolStripMenuItem.Click += new System.EventHandler(this.toggleOrientationToolStripMenuItem_Click_1);
            // 
            // cacheToolStripMenuItem
            // 
            this.cacheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purgeToolStripMenuItem});
            this.cacheToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cacheToolStripMenuItem.Name = "cacheToolStripMenuItem";
            this.cacheToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.cacheToolStripMenuItem.Text = "Cache";
            // 
            // purgeToolStripMenuItem
            // 
            this.purgeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.purgeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.purgeToolStripMenuItem.Name = "purgeToolStripMenuItem";
            this.purgeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.purgeToolStripMenuItem.Text = "Purge";
            this.purgeToolStripMenuItem.Click += new System.EventHandler(this.purgeToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem1.Text = "Generate";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "More Clothing GUI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxRight)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editEntryArguments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBoxLeft;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBoxRight;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleOrientationToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purgeToolStripMenuItem;
    }
}

