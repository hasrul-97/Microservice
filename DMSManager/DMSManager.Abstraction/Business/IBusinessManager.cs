using DMSManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMSManager.Abstraction.Business
{
    public interface IBusinessManager
    {
        Task<FolderData> GetFolders(string tenant, string userID, string parent);
        Task<string> CreateFolder(FolderDetail folder);
        Task<string> RenameFolder(FolderManager folder);
        Task<string> DeleteFolder(FolderDetail folder);
        Task<string> SaveFile(FileDetail file);
    }
}
