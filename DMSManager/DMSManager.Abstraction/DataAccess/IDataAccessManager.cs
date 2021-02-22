using DMSManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMSManager.Abstraction.DataAccess
{
    public interface IDataAccessManager
    {
        Task<List<FolderDataRaw>> GetFolders(string tenant, string userID, string parent);
        Task<string> CreateFolder(FolderDetail folder);
        Task<string> RenameFolder(FolderManager folder);
        Task<string> DeleteFolder(FolderDetail folder);
        Task<string> SaveFile(FileDetail file);
    }
}