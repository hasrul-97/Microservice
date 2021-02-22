using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSAPI.Entities
{
    public class CopyMoveAttributes
    {
        public CopyMoveAttributes()
        {
            
        }
        public CopyMoveAttributes(StorageItem sourceFolder, StorageItem target, string userId, string connectionId,bool canMerge)
        {
            SourceFolders = sourceFolder;
            Target = target;
            UserID = userId;
            ConnectionID = connectionId;
            CanMerge = canMerge;
        }
        public StorageItem SourceFolders { get; set; }
        public StorageItem Target { get; set; }
        public string UserID { get; set; }
        public string ConnectionID { get; set; }
        public bool CanMerge { get; set; }
    }
}