namespace SynchronizeIt
{
   partial class Form1
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
        this.label3 = new System.Windows.Forms.Label();
        this._statusText = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this._currentDirectory = new System.Windows.Forms.Label();
        this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
        this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
        this.deletSyncFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this._toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
        this._toolStripProgress = new System.Windows.Forms.ToolStripProgressBar();
        this.label6 = new System.Windows.Forms.Label();
        this._megaBytesCopiedLbl = new System.Windows.Forms.Label();
        this.label7 = new System.Windows.Forms.Label();
        this._mbToCopy = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this._estDirLbl = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
        this.contextMenuStrip1.SuspendLayout();
        this.menuStrip1.SuspendLayout();
        this.statusStrip1.SuspendLayout();
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
        this.label3.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label3.Location = new System.Drawing.Point(6, 247);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(54, 11);
        this.label3.TabIndex = 6;
        this.label3.Text = "Status:";
        // 
        // _statusText
        // 
        this._statusText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this._statusText.AutoSize = true;
        this._statusText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._statusText.Location = new System.Drawing.Point(92, 247);
        this._statusText.Name = "_statusText";
        this._statusText.Size = new System.Drawing.Size(33, 11);
        this._statusText.TabIndex = 7;
        this._statusText.Text = "Idle";
        // 
        // label5
        // 
        this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label5.Location = new System.Drawing.Point(6, 285);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(75, 11);
        this.label5.TabIndex = 10;
        this.label5.Text = "Directory:";
        // 
        // _currentDirectory
        // 
        this._currentDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this._currentDirectory.AutoSize = true;
        this._currentDirectory.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._currentDirectory.Location = new System.Drawing.Point(92, 285);
        this._currentDirectory.Name = "_currentDirectory";
        this._currentDirectory.Size = new System.Drawing.Size(33, 11);
        this._currentDirectory.TabIndex = 11;
        this._currentDirectory.Text = "none";
        // 
        // notifyIcon1
        // 
        this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
        this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
        this.notifyIcon1.Text = "SynchronizeIt";
        this.notifyIcon1.Visible = true;
        // 
        // contextMenuStrip1
        // 
        this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.showToolStripMenuItem});
        this.contextMenuStrip1.Name = "contextMenuStrip1";
        this.contextMenuStrip1.Size = new System.Drawing.Size(112, 48);
        // 
        // exitToolStripMenuItem
        // 
        this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
        this.exitToolStripMenuItem.Text = "Exit";
        this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
        // 
        // showToolStripMenuItem
        // 
        this.showToolStripMenuItem.Name = "showToolStripMenuItem";
        this.showToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
        this.showToolStripMenuItem.Text = "Show";
        this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
        // 
        // _syncInfoItemsLB
        // 
        this._syncInfoItemsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this._syncInfoItemsLB.FormattingEnabled = true;
        this._syncInfoItemsLB.Location = new System.Drawing.Point(4, 30);
        this._syncInfoItemsLB.Name = "_syncInfoItemsLB";
        this._syncInfoItemsLB.Size = new System.Drawing.Size(645, 186);
        this._syncInfoItemsLB.TabIndex = 12;
        // 
        // label1
        // 
        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(6, 266);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(40, 11);
        this.label1.TabIndex = 19;
        this.label1.Text = "File:";
        // 
        // _currentFile
        // 
        this._currentFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this._currentFile.AutoSize = true;
        this._currentFile.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._currentFile.Location = new System.Drawing.Point(92, 266);
        this._currentFile.Name = "_currentFile";
        this._currentFile.Size = new System.Drawing.Size(33, 11);
        this._currentFile.TabIndex = 20;
        this._currentFile.Text = "none";
        // 
        // label2
        // 
        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label2.Location = new System.Drawing.Point(6, 327);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(82, 11);
        this.label2.TabIndex = 21;
        this.label2.Text = "Last Error:";
        // 
        // label4
        // 
        this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label4.AutoSize = true;
        this.label4.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label4.Location = new System.Drawing.Point(92, 327);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(33, 11);
        this.label4.TabIndex = 22;
        this.label4.Text = "none";
        // 
        // menuStrip1
        // 
        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.syncFoldersToolStripMenuItem});
        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new System.Drawing.Size(653, 24);
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
        this.startToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
        this.startToolStripMenuItem.Text = "Actions";
        // 
        // startMenuItem
        // 
        this.startMenuItem.Name = "startMenuItem";
        this.startMenuItem.Size = new System.Drawing.Size(152, 22);
        this.startMenuItem.Text = "Start";
        this.startMenuItem.Click += new System.EventHandler(this.startMenuItem_Click);
        // 
        // stopMenuItem
        // 
        this.stopMenuItem.Enabled = false;
        this.stopMenuItem.Name = "stopMenuItem";
        this.stopMenuItem.Size = new System.Drawing.Size(152, 22);
        this.stopMenuItem.Text = "Stop";
        this.stopMenuItem.Click += new System.EventHandler(this.stopMenuItem_Click);
        // 
        // exitMenuItem
        // 
        this.exitMenuItem.Name = "exitMenuItem";
        this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
        this.exitMenuItem.Text = "Exit";
        this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
        // 
        // syncFoldersToolStripMenuItem
        // 
        this.syncFoldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSyncFolderMenuItem,
            this.deletSyncFolderMenuItem});
        this.syncFoldersToolStripMenuItem.Name = "syncFoldersToolStripMenuItem";
        this.syncFoldersToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
        this.syncFoldersToolStripMenuItem.Text = "Sync Folders";
        // 
        // addNewSyncFolderMenuItem
        // 
        this.addNewSyncFolderMenuItem.Name = "addNewSyncFolderMenuItem";
        this.addNewSyncFolderMenuItem.Size = new System.Drawing.Size(128, 22);
        this.addNewSyncFolderMenuItem.Text = "Add New";
        this.addNewSyncFolderMenuItem.Click += new System.EventHandler(this.addNewSyncFolderMenuItem_Click);
        // 
        // deletSyncFolderMenuItem
        // 
        this.deletSyncFolderMenuItem.Name = "deletSyncFolderMenuItem";
        this.deletSyncFolderMenuItem.Size = new System.Drawing.Size(128, 22);
        this.deletSyncFolderMenuItem.Text = "Delete";
        this.deletSyncFolderMenuItem.Click += new System.EventHandler(this.deletSyncFolderMenuItem_Click);
        // 
        // statusStrip1
        // 
        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripStatus,
            this._toolStripProgress});
        this.statusStrip1.Location = new System.Drawing.Point(0, 347);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(653, 22);
        this.statusStrip1.TabIndex = 24;
        this.statusStrip1.Text = "statusStrip1";
        // 
        // _toolStripStatus
        // 
        this._toolStripStatus.Name = "_toolStripStatus";
        this._toolStripStatus.Size = new System.Drawing.Size(25, 17);
        this._toolStripStatus.Text = "Idle";
        // 
        // _toolStripProgress
        // 
        this._toolStripProgress.Name = "_toolStripProgress";
        this._toolStripProgress.Size = new System.Drawing.Size(500, 16);
        // 
        // label6
        // 
        this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label6.AutoSize = true;
        this.label6.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label6.Location = new System.Drawing.Point(292, 247);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(75, 11);
        this.label6.TabIndex = 25;
        this.label6.Text = "MB Copied:";
        // 
        // _megaBytesCopiedLbl
        // 
        this._megaBytesCopiedLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this._megaBytesCopiedLbl.AutoSize = true;
        this._megaBytesCopiedLbl.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._megaBytesCopiedLbl.Location = new System.Drawing.Point(373, 247);
        this._megaBytesCopiedLbl.Name = "_megaBytesCopiedLbl";
        this._megaBytesCopiedLbl.Size = new System.Drawing.Size(12, 11);
        this._megaBytesCopiedLbl.TabIndex = 26;
        this._megaBytesCopiedLbl.Text = "0";
        // 
        // label7
        // 
        this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label7.AutoSize = true;
        this.label7.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label7.Location = new System.Drawing.Point(453, 247);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(82, 11);
        this.label7.TabIndex = 27;
        this.label7.Text = "MB To Copy:";
        // 
        // _mbToCopy
        // 
        this._mbToCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this._mbToCopy.AutoSize = true;
        this._mbToCopy.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._mbToCopy.Location = new System.Drawing.Point(537, 247);
        this._mbToCopy.Name = "_mbToCopy";
        this._mbToCopy.Size = new System.Drawing.Size(12, 11);
        this._mbToCopy.TabIndex = 28;
        this._mbToCopy.Text = "0";
        // 
        // label8
        // 
        this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label8.AutoSize = true;
        this.label8.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label8.Location = new System.Drawing.Point(6, 306);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(61, 11);
        this.label8.TabIndex = 29;
        this.label8.Text = "Est Dir:";
        // 
        // _estDirLbl
        // 
        this._estDirLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this._estDirLbl.AutoSize = true;
        this._estDirLbl.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._estDirLbl.Location = new System.Drawing.Point(92, 306);
        this._estDirLbl.Name = "_estDirLbl";
        this._estDirLbl.Size = new System.Drawing.Size(33, 11);
        this._estDirLbl.TabIndex = 30;
        this._estDirLbl.Text = "none";
        // 
        // Form1
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(653, 369);
        this.Controls.Add(this.label8);
        this.Controls.Add(this._estDirLbl);
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
        this.contextMenuStrip1.ResumeLayout(false);
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
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
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
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
     private System.Windows.Forms.ToolStripMenuItem deletSyncFolderMenuItem;
     private System.Windows.Forms.StatusStrip statusStrip1;
     private System.Windows.Forms.ToolStripStatusLabel _toolStripStatus;
     private System.Windows.Forms.ToolStripProgressBar _toolStripProgress;
     private System.Windows.Forms.Label label6;
     private System.Windows.Forms.Label _megaBytesCopiedLbl;
     private System.Windows.Forms.Label label7;
     private System.Windows.Forms.Label _mbToCopy;
     private System.Windows.Forms.Label label8;
     private System.Windows.Forms.Label _estDirLbl;
   }
}

