using System;
using System.Collections.Generic;
using System.Text;

namespace DMSOperationManager.Entities
{
    public class StorageItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Type { get; set; }
        public string FileType { get; set; }
        public string Parent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
    }

    public class Folder : StorageItem
    {
        public Folder(string folderID, string name, DateTime createdOn, string createdBy, DateTime lastModifiedOn, string lastModifiedBy, string parent)
        {
            Id = folderID;
            Name = name;
            CreatedOn = createdOn;
            Type = "Folder";
            CreatedBy = createdBy;
            LastModifiedOn = lastModifiedOn;
            LastModifiedBy = lastModifiedBy;
            Parent = parent;
        }
    }
    public class File : StorageItem
    {
        public File(string folderID, string name, DateTime createdOn, string fileType, string createdBy, DateTime lastModifiedOn, string lastModifiedBy, string parent, string physicalLocation)
        {
            Id = folderID;
            Name = name;
            CreatedOn = createdOn;
            Type = "File";
            FileType = fileType;
            CreatedBy = createdBy;
            LastModifiedOn = lastModifiedOn;
            LastModifiedBy = lastModifiedBy;
            Parent = parent;
            PhysicalLocation = physicalLocation;
        }
        public string PhysicalLocation { get; set; }
    }
}
