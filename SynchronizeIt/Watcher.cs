using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronizeIt
{
    class Watcher
    {
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
    }
}