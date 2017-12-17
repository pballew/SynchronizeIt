namespace SynchronizeIt
{
   partial class UI
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
      this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
      this.label3 = new System.Windows.Forms.Label();
      this._statusText = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this._currentDirectory = new System.Windows.Forms.Label();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this._syncInfoItemsLB = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this._currentFile = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.startMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.stopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.syncFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addNewSyncFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteSyncFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this._toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this._toolStripProgress = new System.Windows.Forms.ToolStripProgressBar();
      this.label6 = new System.Windows.Forms.Label();
      this._megaBytesCopiedLbl = new System.Windows.Forms.Label();
      this._mbToCopy = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // fileSystemWatcher1
      // 
      this.fileSystemWatcher1.EnableRaisingEvents = true;
      this.fileSystemWatcher1.SynchronizingObject = this;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(8, 404);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 20);
      this.label3.TabIndex = 6;
      this.label3.Text = "Status:";
      // 
      // _statusText
      // 
      this._statusText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._statusText.AutoSize = true;
      this._statusText.Location = new System.Drawing.Point(145, 404);
      this._statusText.Name = "_statusText";
      this._statusText.Size = new System.Drawing.Size(35, 20);
      this._statusText.TabIndex = 7;
      this._statusText.Text = "Idle";
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(8, 460);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(76, 20);
      this.label5.TabIndex = 10;
      this.label5.Text = "Directory:";
      // 
      // _currentDirectory
      // 
      this._currentDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._currentDirectory.AutoSize = true;
      this._currentDirectory.Location = new System.Drawing.Point(145, 460);
      this._currentDirectory.Name = "_currentDirectory";
      this._currentDirectory.Size = new System.Drawing.Size(45, 20);
      this._currentDirectory.TabIndex = 11;
      this._currentDirectory.Text = "none";
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "SynchronizeIt";
      this.notifyIcon1.Visible = true;
      // 
      // _syncInfoItemsLB
      // 
      this._syncInfoItemsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._syncInfoItemsLB.FormattingEnabled = true;
      this._syncInfoItemsLB.ItemHeight = 20;
      this._syncInfoItemsLB.Location = new System.Drawing.Point(4, 44);
      this._syncInfoItemsLB.Name = "_syncInfoItemsLB";
      this._syncInfoItemsLB.Size = new System.Drawing.Size(903, 344);
      this._syncInfoItemsLB.TabIndex = 12;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 432);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 20);
      this.label1.TabIndex = 19;
      this.label1.Text = "File:";
      // 
      // _currentFile
      // 
      this._currentFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._currentFile.AutoSize = true;
      this._currentFile.Location = new System.Drawing.Point(145, 432);
      this._currentFile.Name = "_currentFile";
      this._currentFile.Size = new System.Drawing.Size(45, 20);
      this._currentFile.TabIndex = 20;
      this._currentFile.Text = "none";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(8, 486);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(83, 20);
      this.label2.TabIndex = 21;
      this.label2.Text = "Last Error:";
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(145, 486);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(45, 20);
      this.label4.TabIndex = 22;
      this.label4.Text = "none";
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.syncFoldersToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(916, 33);
      this.menuStrip1.TabIndex = 23;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // startToolStripMenuItem
      // 
      this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMenuItem,
            this.stopMenuItem,
            this.exitMenuItem});
      this.startToolStripMenuItem.Name = "startToolStripMenuItem";
      this.startToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
      this.startToolStripMenuItem.Text = "Actions";
      // 
      // startMenuItem
      // 
      this.startMenuItem.Name = "startMenuItem";
      this.startMenuItem.Size = new System.Drawing.Size(134, 30);
      this.startMenuItem.Text = "Start";
      this.startMenuItem.Click += new System.EventHandler(this.startMenuItem_Click);
      // 
      // stopMenuItem
      // 
      this.stopMenuItem.Enabled = false;
      this.stopMenuItem.Name = "stopMenuItem";
      this.stopMenuItem.Size = new System.Drawing.Size(134, 30);
      this.stopMenuItem.Text = "Stop";
      this.stopMenuItem.Click += new System.EventHandler(this.stopMenuItem_Click);
      // 
      // exitMenuItem
      // 
      this.exitMenuItem.Name = "exitMenuItem";
      this.exitMenuItem.Size = new System.Drawing.Size(134, 30);
      this.exitMenuItem.Text = "Exit";
      this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
      // 
      // syncFoldersToolStripMenuItem
      // 
      this.syncFoldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSyncFolderMenuItem,
            this.deleteSyncFolderMenuItem});
      this.syncFoldersToolStripMenuItem.Name = "syncFoldersToolStripMenuItem";
      this.syncFoldersToolStripMenuItem.Size = new System.Drawing.Size(123, 29);
      this.syncFoldersToolStripMenuItem.Text = "Sync Folders";
      // 
      // addNewSyncFolderMenuItem
      // 
      this.addNewSyncFolderMenuItem.Name = "addNewSyncFolderMenuItem";
      this.addNewSyncFolderMenuItem.Size = new System.Drawing.Size(171, 30);
      this.addNewSyncFolderMenuItem.Text = "Add New";
      this.addNewSyncFolderMenuItem.Click += new System.EventHandler(this.addNewSyncFolderMenuItem_Click);
      // 
      // deleteSyncFolderMenuItem
      // 
      this.deleteSyncFolderMenuItem.Name = "deleteSyncFolderMenuItem";
      this.deleteSyncFolderMenuItem.Size = new System.Drawing.Size(171, 30);
      this.deleteSyncFolderMenuItem.Text = "Delete";
      this.deleteSyncFolderMenuItem.Click += new System.EventHandler(this.deleteSyncFolderMenuItem_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
      this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripStatus,
            this._toolStripProgress});
      this.statusStrip1.Location = new System.Drawing.Point(7, 514);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(860, 41);
      this.statusStrip1.TabIndex = 24;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // _toolStripStatus
      // 
      this._toolStripStatus.Name = "_toolStripStatus";
      this._toolStripStatus.Size = new System.Drawing.Size(41, 36);
      this._toolStripStatus.Text = "Idle";
      // 
      // _toolStripProgress
      // 
      this._toolStripProgress.Name = "_toolStripProgress";
      this._toolStripProgress.Size = new System.Drawing.Size(800, 35);
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(465, 404);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(91, 20);
      this.label6.TabIndex = 25;
      this.label6.Text = "MB Copied:";
      // 
      // _megaBytesCopiedLbl
      // 
      this._megaBytesCopiedLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._megaBytesCopiedLbl.AutoSize = true;
      this._megaBytesCopiedLbl.Location = new System.Drawing.Point(595, 404);
      this._megaBytesCopiedLbl.Name = "_megaBytesCopiedLbl";
      this._megaBytesCopiedLbl.Size = new System.Drawing.Size(18, 20);
      this._megaBytesCopiedLbl.TabIndex = 26;
      this._megaBytesCopiedLbl.Text = "0";
      // 
      // _mbToCopy
      // 
      this._mbToCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._mbToCopy.AutoSize = true;
      this._mbToCopy.Location = new System.Drawing.Point(857, 404);
      this._mbToCopy.Name = "_mbToCopy";
      this._mbToCopy.Size = new System.Drawing.Size(18, 20);
      this._mbToCopy.TabIndex = 28;
      this._mbToCopy.Text = "0";
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(723, 404);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(99, 20);
      this.label7.TabIndex = 27;
      this.label7.Text = "MB To Copy:";
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.deleteFolderToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(172, 64);
      // 
      // addItemToolStripMenuItem
      // 
      this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
      this.addItemToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
      this.addItemToolStripMenuItem.Text = "Add New";
      this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
      // 
      // deleteFolderToolStripMenuItem
      // 
      this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
      this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
      this.deleteFolderToolStripMenuItem.Text = "Delete";
      this.deleteFolderToolStripMenuItem.Click += new System.EventHandler(this.deleteFolderToolStripMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
      this.ClientSize = new System.Drawing.Size(916, 555);
      this.Controls.Add(this.label7);
      this.Controls.Add(this._mbToCopy);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this._megaBytesCopiedLbl);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label1);
      this.Controls.Add(this._syncInfoItemsLB);
      this.Controls.Add(this._currentFile);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label3);
      this.Controls.Add(this._currentDirectory);
      this.Controls.Add(this._statusText);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "SynchronizeIt";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

      }

      #endregion

      private System.IO.FileSystemWatcher fileSystemWatcher1;
      private System.Windows.Forms.Label label3;
     private System.Windows.Forms.Label _statusText;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label _currentDirectory;
      private System.Windows.Forms.NotifyIcon notifyIcon1;
     private System.Windows.Forms.ListBox _syncInfoItemsLB;
     private System.Windows.Forms.Label label1;
     private System.Windows.Forms.Label _currentFile;
     private System.Windows.Forms.Label label2;
     private System.Windows.Forms.Label label4;
     private System.Windows.Forms.MenuStrip menuStrip1;
     private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
     private System.Windows.Forms.ToolStripMenuItem startMenuItem;
     private System.Windows.Forms.ToolStripMenuItem stopMenuItem;
     private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
     private System.Windows.Forms.ToolStripMenuItem syncFoldersToolStripMenuItem;
     private System.Windows.Forms.ToolStripMenuItem addNewSyncFolderMenuItem;
     private System.Windows.Forms.ToolStripMenuItem deleteSyncFolderMenuItem;
     private System.Windows.Forms.StatusStrip statusStrip1;
     private System.Windows.Forms.ToolStripStatusLabel _toolStripStatus;
     private System.Windows.Forms.ToolStripProgressBar _toolStripProgress;
     private System.Windows.Forms.Label label6;
     private System.Windows.Forms.Label _megaBytesCopiedLbl;
     private System.Windows.Forms.Label _mbToCopy;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
  }
}

