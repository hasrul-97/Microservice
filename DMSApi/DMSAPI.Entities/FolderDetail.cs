using System;
using System.Collections.Generic;
using System.Text;

namespace DMSAPI.Entities
{
    public class FolderDetail
    {
        public FolderDetail()
        {
            CreatedOn = DateTime.UtcNow;
        }
        public FolderDetail(string folderID, string name, string parent, DateTime createdOn, string tenantId, string type, string userID)
        {
            FolderID = folderID;
            Name = name;
            Parent = parent;
            CreatedOn = createdOn;
            TenantID = tenantId;
            Type = type;
            UserID = userID;
        }
        public string FolderID { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public DateTime CreatedOn { get; set; }
        public string TenantID { get; set; }
        public string Type { get; set; }
        public string UserID { get; set; }
        public string IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }

    public class FileDetail : FolderDetail
    {
        public string PhysicalLocation { get; set; }
        public string FileType { get; set; }
        public int Version { get; set; }
        public string Size { get; set; }

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
