using System;

namespace SynchronizeIt
{
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
