using System;
using System.Collections.Generic;
using System.Text;

namespace TenantManager.Entities
{
    public class FolderDetail
    {
        public FolderDetail()
        {
            CreatedOn = DateTime.UtcNow;
        }
        public string FolderID { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public DateTime CreatedOn { get; set; }
        public string TenantID { get; set; }
        public string Type { get; set; }
        public string UserID { get; set; }
        public string PhysicalLocation { get; set; }
        public string FileType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
