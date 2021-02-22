using System;
using System.Collections.Generic;
using System.Text;

namespace Folder.Command.Entities
{
    public class FolderData
    {
        public FolderData()
        {
            Items = new List<IStorageItem>();
        }
        public List<IStorageItem> Items { get; set; }
        public string UserID { get; set; }
        public string Tenant { get; set; }
    }

    public interface IStorageItem
    {
        public string FolderID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Type { get; set; }
    }

    public class Folder : IStorageItem
    {
        public Folder(string folderID, string name, DateTime createdOn)
        {
            FolderID = folderID;
            Name = name;
            CreatedOn = createdOn;
            Type = "Folder";
        }
        public string FolderID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Type { get; set; }
    }
    public class File : IStorageItem
    {
        public File(string folderID, string name, DateTime createdOn)
        {
            FolderID = folderID;
            Name = name;
            CreatedOn = createdOn;
            Type = "File";
        }
        public string FolderID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Type { get; set; }
    }
}
