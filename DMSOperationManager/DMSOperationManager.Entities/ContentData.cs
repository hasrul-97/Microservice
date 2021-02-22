using System;
using System.Collections.Generic;
using System.Text;

namespace DMSOperationManager.Entities
{
    public class ContentData
    {
        public ContentData()
        {

        }
        public ContentData(string folderID, string name, string tenantID, string type, string parent, string physicalLocation, string userID, DateTime createdOn, string fileType, string createdBy, DateTime lastModifiedOn, string lastModifiedBy)
        {
            FolderID = folderID;
            Name = name;
            TenantID = tenantID;
            Type = type;
            Parent = parent;
            PhysicalLocation = physicalLocation;
            UserID = userID;
            CreatedOn = createdOn;
            FileType = fileType;
            CreatedBy = createdBy;
            LastModifiedOn = lastModifiedOn;
            LastModifiedBy = lastModifiedBy;
        }

        public string FolderID { get; set; }
        public string Name { get; set; }
        public string TenantID { get; set; }
        public string Type { get; set; }
        public string Parent { get; set; }
        public string PhysicalLocation { get; set; }
        public string UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string FileType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
