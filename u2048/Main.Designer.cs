namespace u2048
{
    partial class Main
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.undoMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.new4x4GameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.new5x5GameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.new6x6GameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.new7x7GameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.new8x8GameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.appWebpageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(396, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.undoMoveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.new4x4GameToolStripMenuItem,
            this.new5x5GameToolStripMenuItem,
            this.new6x6GameToolStripMenuItem,
            this.new7x7GameToolStripMenuItem,
            this.new8x8GameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
      this.newToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
      this.newToolStripMenuItem.Text = "New";
      this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
      // 
      // undoMoveToolStripMenuItem
      // 
      this.undoMoveToolStripMenuItem.Name = "undoMoveToolStripMenuItem";
      this.undoMoveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.undoMoveToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
      this.undoMoveToolStripMenuItem.Text = "Undo move";
      this.undoMoveToolStripMenuItem.Click += new System.EventHandler(this.undoMoveToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 6);
      // 
      // new4x4GameToolStripMenuItem
      // 
      this.new4x4GameToolStripMenuItem.Name = "new4x4GameToolStripMenuItem";
      this.new4x4GameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
      this.new4x4GameToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
      this.new4x4GameToolStripMenuItem.Text = "New 4x4 game";
      this.new4x4GameToolStripMenuItem.Click += new System.EventHandler(this.new4x4GameToolStripMenuItem_Click);
      // 
      // new5x5GameToolStripMenuItem
      // 
      this.new5x5GameToolStripMenuItem.Name = "new5x5GameToolStripMenuItem";
      this.new5x5GameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5)));
      this.new5x5GameToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
      this.new5x5GameToolStripMenuItem.Text = "New 5x5 game";
      this.new5x5GameToolStripMenuItem.Click += new System.EventHandler(this.new5x5GameToolStripMenuItem_Click);
      // 
      // new6x6GameToolStripMenuItem
      // 
      this.new6x6GameToolStripMenuItem.Name = "new6x6GameToolStripMenuItem";
      this.new6x6GameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D6)));
      this.new6x6GameToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
      this.new6x6GameToolStripMenuItem.Text = "New 6x6 game";
      this.new6x6GameToolStripMenuItem.Click += new System.EventHandler(this.new6x6GameToolStripMenuItem_Click);
      // 
      // new7x7GameToolStripMenuItem
      // 
      this.new7x7GameToolStripMenuItem.Name = "new7x7GameToolStripMenuItem";
      this.new7x7GameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D7)));
      this.new7x7GameToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
      this.new7x7GameToolStripMenuItem.Text = "New 7x7 game";
      this.new7x7GameToolStripMenuItem.Click += new System.EventHandler(this.new7x7GameToolStripMenuItem_Click);
      // 
      // new8x8GameToolStripMenuItem
      // 
      this.new8x8GameToolStripMenuItem.Name = "new8x8GameToolStripMenuItem";
      this.new8x8GameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D8)));
      this.new8x8GameToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
      this.new8x8GameToolStripMenuItem.Text = "New 8x8 game";
      this.new8x8GameToolStripMenuItem.Click += new System.EventHandler(this.new8x8GameToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appWebpageToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // appWebpageToolStripMenuItem
      // 
      this.appWebpageToolStripMenuItem.Name = "appWebpageToolStripMenuItem";
      this.appWebpageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.appWebpageToolStripMenuItem.Text = "App Webpage";
      this.appWebpageToolStripMenuItem.Click += new System.EventHandler(this.appWebpageToolStripMenuItem_Click);
      // 
      // checkForUpdatesToolStripMenuItem
      // 
      this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
      this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
      this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(396, 541);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Main";
      this.Text = "u2048";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
      this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Main_MouseClick);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem new4x4GameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem new5x5GameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem new6x6GameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem new7x7GameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem new8x8GameToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem undoMoveToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem appWebpageToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
  }
}

