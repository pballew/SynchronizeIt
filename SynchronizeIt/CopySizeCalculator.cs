using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SynchronizeIt
{
    public class CopySizeCalculator
    {
        private bool _running = true;
        private string _startSourceDir;
        private string _endSourceDir;

        public long TotalSize { get; private set; }

        public void StopRunning()
        {
            _running = false;
        }

        public CopySizeCalculator(string sourceDir, string destDir)
        {
            _startSourceDir = sourceDir;
            _endSourceDir = destDir;
        }

        public long CalculateTotalFileCopySize()
        {
            return CalculateTotalFileCopySizeInternal(_startSourceDir, _endSourceDir);
        }

        private long CalculateTotalFileCopySizeInternal(string sourceDir, string destDir)
        {
            // Calculate the size of all files to be copied
            IEnumerable<string> files = new List<string>();
            try
            {
                files = Directory.EnumerateFiles(sourceDir);
            }
            catch (Exception)
            {
                // TODO: Log this
                return 0;
            }
            foreach (string sourceFile in new List<string>(files))
            {
                if (_running == false) break;
                FileInfo fi = new FileInfo(sourceFile);

                //string destFile = GetDestPath(sourceFile, item);
                //if (DoFilesDiffer(sourceFile, destFile))
                //{
                TotalSize += fi.Length;
                //    UpdateBytesToCopyLabel();
                //}
            }

            // Recurse through the other directories
            IEnumerable<string> directories = new List<string>();
            try
            {
                directories = Directory.EnumerateDirectories(sourceDir);
            }
            catch (Exception)
            {
                // TODO: Log this
                return 0;
            }
            foreach (string newSourceDir in directories)
            {
                if (_running == false) break;
                // TODO: Fix issue with different source and dest root resulting in bad newDestDir
                string newDestDir = newSourceDir.Replace(_startSourceDir, _endSourceDir);
                CalculateTotalFileCopySizeInternal(newSourceDir, newDestDir);
            }

            return TotalSize;
        }
    }
}