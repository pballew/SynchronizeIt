using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace SynchronizeIt
{
    partial class UI : Form
    {
        #region Fields
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private Thread _syncThread;
        private Thread _fileSizeEstimatorThread;
        //private Thread _thread2;
        private bool _running = false;

        //private string watcherthreadpath1;
        private List<SyncInfoItem> _syncInfoItems = new List<SyncInfoItem>();

        private long _bytesCopied;

        private Logger _logger = new Logger();

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Constructor
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public UI()
        {
            InitializeComponent();
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Event Handlers
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateStatus("Idle");
            LoadSyncInfoItems();
            _syncInfoItemsLB.ContextMenuStrip = contextMenuStrip1;
            //LoadSyncInfoTracks();
        }

        private void startMenuItem_Click(object sender, EventArgs e)
        {
            StartStuff();
        }

        private void stopMenuItem_Click(object sender, EventArgs e)
        {
            StopStuff();
            UpdateStatus("Stopped");
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownAndExitApp();
        }

        private void addNewSyncFolderMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSyncFolder();
        }

        private void deleteSyncFolderMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSyncInfoItem();
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Status
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void UpdateStatus(string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    UpdateStatus2(status);
                }));
            }
            else
                UpdateStatus2(status);
        }

        private void UpdateStatus2(string status)
        {
            _statusText.Text = status;
            _statusText.Refresh();
            _toolStripStatus.Text = status;
        }

        private void SetCurrentPath(string path)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    _currentDirectory.Text = path;
                    _currentDirectory.Refresh();
                }));
            }
        }

        private void SetCurrentFile(string file)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    string shortFileName = Path.GetFileName(file);
                    _currentFile.Text = shortFileName;
                    _currentFile.Refresh();
                }));
            }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Calculate Size of File Copy Operation
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private long _totalFileCopySize;

        private void CalculateTotalFileCopySize()
        {
            _logger.LogMessage(LogLevel.Info, "Starting CalculateTotalFileCopySize()");

            _totalFileCopySize = 0;
            UpdateBytesToCopyLabel();

            foreach (SyncInfoItem item in _syncInfoItems)
            {
                if (_running == false)
                    break;
                CalculateTotalFileCopySize(item.SourcePath, item);
            }

            _logger.LogMessage(LogLevel.Info, "Ending CalculateTotalFileCopySize()");
        }

        private void CalculateTotalFileCopySize(string sourceDir, SyncInfoItem item)
        {
            // Calculate the size of all files to be copied
            List<string> files;
            try
            {
                files = new List<string>(Directory.GetFiles(sourceDir));
            }
            catch (Exception e)
            {
                _logger.LogMessage(LogLevel.Error, $"Error getting files from {sourceDir}", e);
                return;
            }

            foreach (string sourceFile in files)
            {
                if (_running == false)
                    return;

                FileInfo fi = new FileInfo(sourceFile);

                string destFile = GetDestPath(sourceFile, item);
                if (DoFilesDiffer(sourceFile, destFile))
                {
                    _totalFileCopySize += fi.Length;
                    UpdateBytesToCopyLabel();
                }
            }

            // Recurse through the other directories
            foreach (string newSourceDir in Directory.GetDirectories(sourceDir))
            {
                if (_running == false)
                    return;
                CalculateTotalFileCopySize(newSourceDir, item);
            }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Manual Synchronization
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //private int _syncDelayMinutes = 6000;

        private void SyncThread()
        {
            _logger.LogMessage(LogLevel.Info, "Starting SyncThread()");
            while (_running)
            {
                UpdateStatus("Synchronizing files");
                foreach (SyncInfoItem item in _syncInfoItems)
                {
                    if (DestinationUnavailable(item.DestPath))
                        continue;

                    SyncFilesAndDirectories(item);
                }
                UpdateStatus("Idle");
                //MessageBox.Show("Sync Complete!");
                //Thread.Sleep(_syncDelayMinutes * 60 * 1000);
            }
        }

        private void SyncFilesAndDirectories(SyncInfoItem item)
        {
            _bytesCopied = 0;
            UpdateBytesCopiedLabel();

            if (_running)
                AddFiles(item);

            //if (_running)
            //  DeleteFiles(item);
        }

        private void AddFiles(SyncInfoItem item)
        {
            if (_running)
                AddFiles(item.SourcePath, item);
        }

        private void AddFiles(string sourceDir, SyncInfoItem item)
        {
            if (_running == false)
                return;

            if (DestinationUnavailable(item.DestPath))
                return;

            // Display the current path to the user
            SetCurrentPath(sourceDir);

            foreach (string sourceSubDir in Directory.GetDirectories(sourceDir))
            {
                try
                {
                    // Create all the subdirectories
                    CreateDir(GetDestPath(sourceSubDir, item));
                }
                catch (Exception e)
                {
                    _logger.LogMessage(LogLevel.Error, $"Error creating subdirectory {sourceSubDir}", e);
                }
            }
            // Copy all files in this directory.
            List<string> files;
            try
            {
                files = new List<string>(Directory.GetFiles(sourceDir));
            }
            catch (Exception e)
            {
                _logger.LogMessage(LogLevel.Error, $"Error copying files to directory {sourceDir}", e);
                return;
            }
            foreach (string sourceFile in Directory.GetFiles(sourceDir))
            {
                if (_running == false)
                {
                    return;
                }
                string destFile = GetDestPath(sourceFile, item);

                //if (NeedToSync(sourceFile, destFile) == true)
                //{
                CopyFile(sourceFile, destFile);
                //}
            }

            string destDir = GetDestPath(sourceDir, item);
            if (Directory.Exists(destDir) == true)
            {
                // Delete any files in the dest directory that are not in the source
                foreach (string destFile in Directory.GetFiles(destDir))
                {
                    if (_running == false)
                        return;
                    string sourceFile = GetSourcePath(destFile, item);

                    if (File.Exists(sourceFile) == false)
                        DeleteFile(destFile);
                }

                // Delete any directories in the dest directory that are not in the source
                foreach (string destSubDir in Directory.GetDirectories(destDir))
                {
                    if (_running == false)
                        return;
                    string sourceSubDir = GetSourcePath(destSubDir, item);
                    if (Directory.Exists(sourceSubDir) == false)
                        DeleteDirectory(destSubDir);
                }
            }

            // Recurse through the other directories
            foreach (string newSourceDir in Directory.GetDirectories(sourceDir))
            {
                if (_running == false)
                    return;
                AddFiles(newSourceDir, item);
            }
        }

        //private bool NeedToSync(string sourceFile, string destFile)
        //{
        //  if (_syncTracks.ContainsKey(sourceFile))
        //  {
        //    SynchronizationTracking st = _syncTracks[sourceFile];
        //    if (File.GetLastWriteTime(sourceFile) > st.DestFileModifiedDateTime)
        //      return true;
        //  }
        //  return false;
        //}

        private string GetDestPath(string sourcePath, SyncInfoItem item)
        {
            return sourcePath.Replace(item.SourcePath, item.DestPath);
        }

        private string GetSourcePath(string destPath, SyncInfoItem item)
        {
            return destPath.Replace(item.DestPath, item.SourcePath);
        }

        private string GetBasePath(string filePath)
        {
            string[] basePath = filePath.Split('\\');
            return basePath[0];
        }

        private void CopyFile(string sourcefile, string destFile)
        {
            bool overwrite = false;

            if (DestinationUnavailable(destFile))
                return;

            if (File.Exists(destFile))
                overwrite = true;

            if (DoFilesDiffer(sourcefile, destFile))
            {
                long bytes = CopyFile(sourcefile, destFile, overwrite); ;
                _bytesCopied += bytes;
                UpdateBytesCopiedLabel();
            }
        }

        //Dictionary<string, SynchronizationTracking> _syncTracks = new Dictionary<string, SynchronizationTracking>();

        private long CopyFile(string file1, string file2, bool overwrite)
        {
            try
            {
                _logger.LogMessage(LogLevel.Info, "Copy file [" + file1 + "] to [" + file2 + "]");
                SetCurrentFile(file1);
                CreateDir(GetPath(file2));

                File.Copy(file1, file2, overwrite);

                //DateTime dt = File.GetLastWriteTime(file1);
                //File.SetLastWriteTime(file2, dt);
                //dt = File.GetCreationTime(file1);
                //File.SetCreationTime(file2, dt);
                //dt = File.GetLastAccessTime(file1);
                //File.SetLastAccessTime(file2, dt);

                //if (_syncTracks.ContainsKey(file1))
                //  _syncTracks.Remove(file1);

                //_syncTracks.Add(file1, new SynchronizationTracking(file2, File.GetLastWriteTime(file1), File.GetLastWriteTime(file2), true));
            }
            catch (Exception e)
            {
                _logger.LogMessage(LogLevel.Error, $"Error copying files {file1} to {file2}", e);
                return 0;
            }

            FileInfo fi = new FileInfo(file1);
            return fi.Length;
        }

        private void CreateDir(string dirName)
        {
            if (DestinationUnavailable(dirName))
                return;

            try
            {
                if (Directory.Exists(dirName) == false)
                    Directory.CreateDirectory(dirName);
            }
            catch (Exception e)
            {
                _logger.LogMessage(LogLevel.Error, $"Error creating directory {dirName}", e);
                return;
            }
        }

        private void DeleteFile(string filename)
        {
            if (DestinationUnavailable(filename))
                return;

            try
            {
                File.Delete(filename);
            }
            catch (Exception e)
            {
                _logger.LogMessage(LogLevel.Error, $"Error deleting file {filename}", e);
            }
        }

        private void DeleteDirectory(string dirName)
        {
            if (DestinationUnavailable(dirName))
                return;

            try
            {
                Directory.Delete(dirName, true);
            }
            catch (Exception e)
            {
                _logger.LogMessage(LogLevel.Error, $"Error deleting directory {dirName}", e);
            }
        }

        private bool DestinationUnavailable(string path)
        {
            string basePath = GetBasePath(path);
            if (Directory.Exists(basePath) == false)
            {
                _logger.LogMessage(LogLevel.Error, $"DestinationUnavailable {path}");
                return true;
            }
            return false;
        }

        private string GetPath(string filename)
        {
            return Path.GetDirectoryName(filename);
        }

        private void DeleteFiles(SyncInfoItem item)
        {
            foreach (string destFile in Directory.GetFiles(item.DestPath, "*", SearchOption.AllDirectories))
            {
                SetCurrentPath(GetPath(destFile));
                string sourceFile = GetSourcePath(destFile, item);
                MessageBox.Show(sourceFile);
                if (File.Exists(sourceFile) == false)
                {
                    MessageBox.Show("deleting " + destFile);
                    File.Delete(destFile);
                }
            }
        }

        //private void DeleteFiles(SyncInfoItem item)
        //{
        //  _currentDirectory.Text = item.DestPath;

        //  foreach (string file2 in Directory.GetFiles(item.DestPath))
        //  {
        //    if (_running == false)
        //      break;

        //    string file1 = GetPath1(item);
        //    if (File.Exists(file1) == false)
        //    {
        //      _logger.LogMessage(LogLevel.Info, "Delete file [" + file2 + "]");
        //      try
        //      {
        //        _currentFile.Text = file2;
        //        File.Delete(file2);
        //      }
        //      catch (Exception e)
        //      {
        //        _logger.LogMessage(LogLevel.Info, "Exception : " + e.Message);
        //      }
        //    }
        //  }

        //  foreach (string dir2 in Directory.GetDirectories(item.DestPath))
        //  {
        //    if (_running == false)
        //      break;

        //    string dir1 = GetPath1(item);

        //    if (Directory.Exists(dir1) == false)
        //    {
        //      _logger.LogMessage(LogLevel.Info, "Delete directory [" + dir2 + "]");
        //      try
        //      {
        //        Directory.Delete(dir2, true);
        //      }
        //      catch (Exception e)
        //      {
        //        _logger.LogMessage(LogLevel.Info, "Exception : " + e.Message);
        //      }
        //    }

        //    DeleteFiles(dir2);
        //  }
        //}
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Helpers
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ShutdownAndExitApp()
        {
            _logger.LogMessage(LogLevel.Info, "Exiting program");
            StopStuff();
            Application.Exit();
        }

        private void AddNewSyncFolder()
        {
            FolderBrowserDialog sourceFolderDlg = new FolderBrowserDialog();
            sourceFolderDlg.ShowNewFolderButton = true;
            sourceFolderDlg.Description = "Choose the source folder...";
            sourceFolderDlg.ShowDialog();
            if (sourceFolderDlg.SelectedPath == "")
                return;

            FolderBrowserDialog destFolderDlg = new FolderBrowserDialog();
            destFolderDlg.ShowNewFolderButton = true;
            sourceFolderDlg.Description = "Choose the destination folder...";
            destFolderDlg.ShowDialog();
            if (destFolderDlg.SelectedPath == "")
                return;

            if (sourceFolderDlg.SelectedPath == destFolderDlg.SelectedPath)
            {
                MessageBox.Show("Source and destination cannot be the same");
                return;
            }

            AddSyncInfoItem(new SyncInfoItem(sourceFolderDlg.SelectedPath, destFolderDlg.SelectedPath));
        }


        private void StartStuff()
        {
            _running = true;

            startMenuItem.Enabled = false;
            stopMenuItem.Enabled = true;

            _syncThread = new Thread(new ThreadStart(SyncThread));
            _syncThread.Priority = ThreadPriority.Lowest;
            _syncThread.Start();

            _fileSizeEstimatorThread = new Thread(new ThreadStart(CalculateTotalFileCopySize));
            _fileSizeEstimatorThread.Priority = ThreadPriority.BelowNormal;
            _fileSizeEstimatorThread.Start();

            //_thread2 = new Thread(new ThreadStart(WatcherThread));
            //_thread2.Priority = ThreadPriority.Lowest;
            //_thread2.Start();
        }

        private void StopStuff()
        {
            _running = false;

            startMenuItem.Enabled = true;
            stopMenuItem.Enabled = false;

            _logger.LogMessage(LogLevel.Info, "Stopping");
            UpdateStatus("Stopping");

            if (_syncThread != null)
            {
                _syncThread.Abort();
                _syncThread = null;
            }

            if (_fileSizeEstimatorThread != null)
            {
                _fileSizeEstimatorThread.Abort();
                _fileSizeEstimatorThread = null;
            }

            UpdateStatus("Idle");

            //if (_thread2 != null)
            //  _thread2.Join();

            //fileSystemWatcher1.EnableRaisingEvents = false;
        }

        private bool DoFilesDiffer(string path1, string path2)
        {
            if ((File.Exists(path1) == false) || (File.Exists(path2) == false))
                return true;

            // If the files are more than 3 seconds apart, consider them different.  Can't use the exact time because FAT doesn't get the exact number.
            TimeSpan ts = File.GetLastWriteTime(path1) - File.GetLastWriteTime(path2);
            double seconds = ts.TotalSeconds;
            double diffSeconds = Math.Abs(seconds);

            if (diffSeconds > 3)
                return true;

            return false;
        }

        private string GetPath2(SyncInfoItem item)
        {
            return item.SourcePath.Replace(item.SourcePath, item.DestPath);
        }

        private string GetPath1(SyncInfoItem item)
        {
            return item.DestPath.Replace(item.DestPath, item.SourcePath);
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Logging
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void UpdateBytesCopiedLabel()
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _toolStripProgress.Value = Convert.ToInt32(_bytesCopied / 1000);
                double mbytes = ((double)_bytesCopied / 1024) / 1024;
                _megaBytesCopiedLbl.Text = mbytes.ToString("N");
            }));
        }

        private void UpdateBytesToCopyLabel()
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _toolStripProgress.Maximum = Convert.ToInt32(_totalFileCopySize / 1000);
                double mbytes = ((double)_totalFileCopySize / 1024) / 1024;
                _mbToCopy.Text = mbytes.ToString("N");
            }));
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Overrides
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            base.OnClosing(e);
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region ToolStrip menuitems
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownAndExitApp();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Sync Info
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SaveSyncInfoItems()
        {
            using (FileStream fs = new FileStream("syncinfo.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, _syncInfoItems);
                fs.Close();
            }
        }

        //private void SaveSyncInfoTracks()
        //{
        //  using (FileStream fs = new FileStream("syncTracks.dat", FileMode.Create))
        //  {
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    formatter.Serialize(fs, _syncTracks);
        //    fs.Close();
        //  }
        //}

        private void LoadSyncInfoItems()
        {
            if (File.Exists("syncinfo.dat") == false)
                return;

            using (FileStream fs = new FileStream("syncinfo.dat", FileMode.Open))
            {
                BinaryFormatter b = new BinaryFormatter();
                _syncInfoItems = (List<SyncInfoItem>)b.Deserialize(fs);
                fs.Close();
            }
            RefreshSyncInfoItems();
        }

        //private void LoadSyncInfoTracks()
        //{
        //  if (File.Exists("syncTracks.dat") == false)
        //    return;

        //  using (FileStream fs = new FileStream("syncTracks.dat", FileMode.Open))
        //  {
        //    BinaryFormatter b = new BinaryFormatter();
        //    _syncTracks = (Dictionary<string, SynchronizationTracking>)b.Deserialize(fs);
        //    fs.Close();
        //  }
        //}

        private void AddSyncInfoItem(SyncInfoItem item)
        {
            _syncInfoItems.Add(item);
            SaveSyncInfoItems();
            RefreshSyncInfoItems();
        }

        private void DeleteSyncInfoItem()
        {
            if (_syncInfoItemsLB.SelectedItem == null)
                return;

            _syncInfoItems.Remove((SyncInfoItem)_syncInfoItemsLB.SelectedItem);
            SaveSyncInfoItems();
            RefreshSyncInfoItems();
        }

        private void RefreshSyncInfoItems()
        {
            _syncInfoItemsLB.Items.Clear();
            foreach (SyncInfoItem item in _syncInfoItems)
                _syncInfoItemsLB.Items.Add(item);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //SaveSyncInfoTracks();
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSyncFolder();
        }

        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            if (item.Text == "Delete")
            {
                DeleteSyncInfoItem();
            }
        }
    }
}
