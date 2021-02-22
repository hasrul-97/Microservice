using System;
using System.Collections.Generic;
using System.Text;

namespace DMSManager.Entities
{
    public class FolderData
    {
        public FolderData()
        {
            Items = new List<StorageItem>();
        }
        public List<StorageItem> Items { get; set; }
        public string Parent { get; set; }
        public string UserID { get; set; }
        public string Tenant { get; set; }
    }
}
