using System;

namespace SynchronizeIt
{
    #region SyncInfoItem class definition
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
    #endregion
}
