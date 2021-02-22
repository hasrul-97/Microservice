using System;
using System.Collections.Generic;
using System.Text;

namespace DMSOperationManager.Entities
{
    public class CopyAttributes
    {
        public CopyAttributes()
        {
            
        }
        public CopyAttributes(StorageItem sourceFolder, StorageItem target)
        {
            SourceFolders = sourceFolder;
            Target = target;
        }
        public StorageItem SourceFolders { get; set; }
        public StorageItem Target { get; set; }
        public string ConnectionID { get; set; }
        public string UserID { get; set; }
        public bool CanMerge { get; set; }
    }
}
