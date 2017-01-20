using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace SynchronizeIt
{
  partial class Form1 : Form
  {
    #region Fields
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private Thread _syncThread;
    private Thread _fileSizeEstimator;
    //private Thread _thread2;
    private bool _running = false;

    //private string watcherthreadpath1;
    private ArrayList _syncInfoItems2 = new ArrayList();

    private long _bytesCopied;
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion

    #region Constructor
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Form1()
    {
      InitializeComponent();
      UpdateStatus("Idle");
    }
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion

    #region Event Handlers
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Form1_Load(object sender, EventArgs e)
    {
      LoadSyncInfoItems();
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

    private void deletSyncFolderMenuItem_Click(object sender, EventArgs e)
    {
      if (_syncInfoItemsLB.SelectedItem == null)
        return;

      DeleteSyncInfoItem((SyncInfoItem)_syncInfoItemsLB.SelectedItem);
    }
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion

    #region Status
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void UpdateStatus(string status)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new MethodInvoker(delegate()
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
        this.Invoke(new MethodInvoker(delegate()
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
        this.Invoke(new MethodInvoker(delegate()
        {
          string shortFileName = Path.GetFileName(file);
          _currentFile.Text = shortFileName;
          _currentFile.Refresh();
        }));
      }
    }
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion

    #region FileSystemWatcher Code
    //private void WatcherThread()
    //{
    //  LogMessage("Starting WatcherThread()");
    //  fileSystemWatcher1.Path = watcherthreadpath1;
    //  fileSystemWatcher1.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName
    //     | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
    //  fileSystemWatcher1.IncludeSubdirectories = true;
    //  fileSystemWatcher1.EnableRaisingEvents = true;
    //}

    //private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
    //{
    //  LogMessage("Watcher changed event for [" + e.FullPath + "] " + e.ChangeType.ToString());

    //  // If created/deleted/renamed, let those handlers do the work
    //  if ((e.ChangeType == WatcherChangeTypes.Created) || (e.ChangeType == WatcherChangeTypes.Deleted) || (e.ChangeType == WatcherChangeTypes.Renamed))
    //    return;

    //  string path2 = GetPath2(e.FullPath);

    //  // If it's a directory handle it this way
    //  if (Directory.Exists(e.FullPath))
    //  {
    //    return;
    //  }
    //  else
    //  {
    //    if (File.Exists(path2))
    //    {
    //      if (DoFilesDiffer(e.FullPath, path2))
    //      {
    //        LogMessage("Copy file [" + e.FullPath + "] to [" + path2 + "]");
    //        CopyFile(e.FullPath, path2, true);
    //      }
    //    }
    //  }
    //}

    //private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
    //{
    //  LogMessage("Watcher deleted event for [" + e.FullPath + "]");

    //  string path2 = GetPath2(e.FullPath);

    //  try
    //  {
    //    if (Directory.Exists(path2))
    //    {
    //      LogMessage("Delete directory [" + path2 + "]");
    //      Directory.Delete(path2, true);
    //    }
    //    else
    //    {
    //      LogMessage("Delete file [" + path2 + "]");
    //      File.Delete(path2);
    //    }
    //  }
    //  catch (Exception ex)
    //  {
    //    LogMessage("Exception : " + ex.Message);
    //  }

    //}

    //private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
    //{
    //  LogMessage("Watcher created event for [" + e.FullPath + "]");

    //  string path2 = GetPath2(e.FullPath);

    //  if (Directory.Exists(e.FullPath))
    //  {
    //    LogMessage("Create directory [" + e.FullPath + "]");
    //    try
    //    {
    //      Directory.CreateDirectory(e.FullPath);
    //    }
    //    catch (Exception ex)
    //    {
    //      LogMessage("Exception : " + ex.Message);
    //    }
    //  }
    //  else
    //  {
    //    if (DoFilesDiffer(e.FullPath, path2))
    //    {
    //      LogMessage("Copy file [" + e.FullPath + "] to [" + path2 + "]");
    //      CopyFile(e.FullPath, path2, true);
    //    }
    //  }
    //}

    //private void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
    //{
    //  LogMessage("Watcher renamed event for [" + e.FullPath + "] to [" + e.OldFullPath + "]");

    //  string newpath2 = GetPath2(e.FullPath);
    //  string oldpath2 = GetPath2(e.OldFullPath);

    //  try
    //  {
    //    if (Directory.Exists(e.FullPath))
    //    {
    //      LogMessage("Move directory [" + oldpath2 + "] to [" + newpath2 + "]");
    //      Directory.Move(oldpath2, newpath2);
    //    }
    //    else if (File.Exists(e.FullPath))
    //    {
    //      LogMessage("Move file [" + oldpath2 + "] to [" + newpath2 + "]");
    //      File.Move(oldpath2, newpath2);
    //    }
    //  }
    //  catch (Exception ex)
    //  {
    //    LogMessage("Exception : " + ex.Message);
    //  }
    //}
    #endregion

    #region Calculate Size of File Copy Operation

    private long _totalFileCopySize;

    private void CalculateTotalFileCopySize()
    {
      LogMessage("Starting CalculateTotalFileCopySize()");

      _totalFileCopySize = 0;
      UpdateBytesToCopyLabel();

      foreach (SyncInfoItem item in _syncInfoItems2)
      {
        if (_running == false)
          break;
        CalculateTotalFileCopySize(item.SourcePath, item);
      }

      LogMessage("Ending CalculateTotalFileCopySize()");
    }

    private void CalculateTotalFileCopySize(string sourceDir, SyncInfoItem item)
    {
      UpdateEstDirLabel(sourceDir);

      // Calculate the size of all files to be copied.
      foreach (string sourceFile in Directory.GetFiles(sourceDir))
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
    private int _syncDelayMinutes = 6000;

    private void SyncThread()
    {
      LogMessage("Starting SyncThread()");
      while (_running)
      {
        UpdateStatus("Synchronizing files");
        foreach (SyncInfoItem item in _syncInfoItems2)
        {
          if (DestinationUnavailable(item.DestPath))
            continue;

          SyncFilesAndDirectories(item);
        }
        UpdateStatus("Idle");
        MessageBox.Show("Sync Complete!");
        Thread.Sleep(_syncDelayMinutes * 60 * 1000);
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

      try
      {
        // Create all the subdirectories
        foreach (string sourceSubDir in Directory.GetDirectories(sourceDir))
          CreateDir(GetDestPath(sourceSubDir, item));
      }
      catch (Exception e)
      {
        LogError("Exception: " + e.Message, false);
      }

      // Copy all files in this directory.
      foreach (string sourceFile in Directory.GetFiles(sourceDir))
      {
        if (_running == false)
          return;
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
        LogMessage("Copy file [" + file1 + "] to [" + file2 + "]");
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
        LogError("Exception: " + e.Message, false);
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
      catch (Exception)
      {
        LogError("Could not create directory: " + dirName, false);
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
      catch (Exception)
      {
        LogError("Could not delete file: " + filename, false);
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
      catch (Exception)
      {
        LogError("Could not delete directory: " + dirName, false);
      }
    }

    private bool DestinationUnavailable(string path)
    {
      string basePath = GetBasePath(path);
      if (Directory.Exists(basePath) == false)
      {
        LogError("Critical Error: Destination Drive Offline: " + basePath, true);
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
    //      LogMessage("Delete file [" + file2 + "]");
    //      try
    //      {
    //        _currentFile.Text = file2;
    //        File.Delete(file2);
    //      }
    //      catch (Exception e)
    //      {
    //        LogMessage("Exception : " + e.Message);
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
    //      LogMessage("Delete directory [" + dir2 + "]");
    //      try
    //      {
    //        Directory.Delete(dir2, true);
    //      }
    //      catch (Exception e)
    //      {
    //        LogMessage("Exception : " + e.Message);
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
      LogMessage("Exiting program");
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
      if (LogfileAvailable() == false)
      {
        MessageBox.Show("Could not open logfile");
        return;
      }

      _running = true;

      startMenuItem.Enabled = false;
      stopMenuItem.Enabled = true;

      _syncThread = new Thread(new ThreadStart(SyncThread));
      _syncThread.Priority = ThreadPriority.Lowest;
      _syncThread.Start();

      _fileSizeEstimator = new Thread(new ThreadStart(CalculateTotalFileCopySize));
      _fileSizeEstimator.Priority = ThreadPriority.Lowest;
      _fileSizeEstimator.Start();

      //_thread2 = new Thread(new ThreadStart(WatcherThread));
      //_thread2.Priority = ThreadPriority.Lowest;
      //_thread2.Start();
    }

    private bool LogfileAvailable()
    {
      try
      {
        using (StreamWriter file = new StreamWriter(_logfileName, true))
        {
        }
      }
      catch
      {
        return false;
      }
      return true;
    }

    private void StopStuff()
    {
      _running = false;

      startMenuItem.Enabled = true;
      stopMenuItem.Enabled = false;

      LogMessage("Stopping");
      UpdateStatus("Stopping");

      if (_syncThread != null)
        _syncThread.Abort();

      if (_fileSizeEstimator != null)
        _fileSizeEstimator.Abort();

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
    private string _logfileName = "SynchronizeIt.log";
    private void LogMessage(string msg)
    {
      while (true)
      {
        try
        {
          if (File.Exists(_logfileName))
          {
            FileInfo fil = new FileInfo(_logfileName);
            if (fil.Length >= 10000000)
              File.Delete(_logfileName);
          }

          lock (this)
          {
            using (StreamWriter file = new StreamWriter(_logfileName, true))
            {
              file.Write(DateTime.Now + ": ");
              file.WriteLine(msg);
              return;
            }
          }
        }
        catch(Exception)
        {
        }
      }
    }

    private void LogError(string error, bool showErrorToUser)
    {
      this.BeginInvoke(new MethodInvoker(delegate()
      {
//        MessageBox.Show(error);
        label4.Text = error;
        LogMessage(error);
      }));
    }

    private void UpdateBytesCopiedLabel()
    {
      this.BeginInvoke(new MethodInvoker(delegate()
      {
        _toolStripProgress.Value = Convert.ToInt32(_bytesCopied / 1000);
        double mbytes = ((double)_bytesCopied / 1024) / 1024;
        _megaBytesCopiedLbl.Text = mbytes.ToString("N");
      }));
    }

    private void UpdateBytesToCopyLabel()
    {
      this.BeginInvoke(new MethodInvoker(delegate()
      {
        _toolStripProgress.Maximum = Convert.ToInt32(_totalFileCopySize / 1000);
        double mbytes = ((double)_totalFileCopySize / 1024) / 1024;
        _mbToCopy.Text = mbytes.ToString("N");
      }));
    }

    private void UpdateEstDirLabel(string sourceDir)
    {
      this.BeginInvoke(new MethodInvoker(delegate()
      {
        _estDirLbl.Text = sourceDir;
        _estDirLbl.Refresh();
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
        formatter.Serialize(fs, _syncInfoItems2);
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
        _syncInfoItems2 = (ArrayList)b.Deserialize(fs);
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
      _syncInfoItems2.Add(item);
      SaveSyncInfoItems();
      RefreshSyncInfoItems();
    }

    private void DeleteSyncInfoItem(SyncInfoItem item)
    {
      _syncInfoItems2.Remove(item);
      SaveSyncInfoItems();
      RefreshSyncInfoItems();
    }

    private void RefreshSyncInfoItems()
    {
      _syncInfoItemsLB.Items.Clear();
      foreach (SyncInfoItem item in _syncInfoItems2)
        _syncInfoItemsLB.Items.Add(item);
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      //SaveSyncInfoTracks();
    }
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion
  }

  #region SyncInfoItem class definition
  // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  [Serializable]
  public class SyncInfoItem
  {
    public string SourcePath;
    public string DestPath;

    public SyncInfoItem(string source, string dest)
    {
      SourcePath = source;
      DestPath = dest;
    }

    public override string ToString()
    {
      return SourcePath + " --> " + DestPath;
    }
  }
  // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  #endregion

  public struct SynchronizationTracking
  {
    public string DestFile;
    public DateTime SourceFileModifiedDateTime;
    public DateTime DestFileModifiedDateTime;
    public bool Copied;

    public SynchronizationTracking(string destFile, DateTime sourceDT, DateTime destDT, bool copied)
    {
      DestFile = destFile;
      SourceFileModifiedDateTime = sourceDT;
      DestFileModifiedDateTime = destDT;
      Copied = copied;
    }
  }
}
