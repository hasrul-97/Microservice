using System;
using System.Collections.Generic;
using System.Text;

namespace Folder.Command.Entities
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
    }

    public class FolderManager
    {
        public string FolderID { get; set; }
        public string PreviousName { get; set; }
        public string NewName { get; set; }
        public string TenantID { get; set; }
        public string UserID { get; set; }
    }
}