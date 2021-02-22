using System;
using System.Collections.Generic;
using System.Text;

namespace DMSManager.Entities
{
    public class FolderManager
    {
        public string FolderID { get; set; }
        public string PreviousName { get; set; }
        public string NewName { get; set; }
        public string TenantID { get; set; }
        public string UserID { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
