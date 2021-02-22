using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSAPI.Entities
{
    public class FolderData
    {
        public FolderData()
        {
            Items = new List<StorageItem>();
        }
        public List<StorageItem> Items { get; set; }
        public string UserID { get; set; }
        public string Tenant { get; set; }
        public string Parent { get; set; }
    }
}
