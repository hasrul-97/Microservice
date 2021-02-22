using DMSOperationManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMSOperationManager.Abstraction.DataAccess
{
    public interface IDataHandler
    {
        Task<List<ContentData>> GetFolderDetails(List<StorageItem> items);
        Task<List<ContentData>> GetFolderDetails(StorageItem item);
        Task<List<ContentData>> GetFolderDetailsExcludingRoot(StorageItem item);
        Task<ContentData> GetContentDataForFolder(StorageItem item);
        Task<string> Save(List<ContentData> data);
        Task<string> Save(ContentData data);
    }
}
