using DMSOperationManager.Abstraction.DataAccess;
using DMSOperationManager.Abstraction.Repository;
using DMSOperationManager.DataAccess.Core;
using DMSOperationManager.Entities;
using DMSOperationManager.Entities.ReadonlyValues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMSOperationManager.DataAccess
{
    public class DataHandler : IDataHandler
    {
        private readonly IRepositoryManager _repository;
        public DataHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<ContentData> GetContentDataForFolder(StorageItem item)
        {
            try
            {
                return await _repository.FetchDataWithParameter<ContentData>(SQLQueries.GET_CONTENT_DATA_FOR_FOLDER, new { FolderID = item.Id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ContentData>> GetFolderDetails(List<StorageItem> sources)
        {
            try
            {
                List<ContentData> subContents = new List<ContentData>();
                foreach (var source in sources)
                {
                    subContents.AddRange(await _repository.FetchListWithParameter<ContentData>(SQLQueries.FETCH_ALL_SUB_CONTENT_FOR_FOLDER, new { FolderID = source.Id }));
                }
                return subContents;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<ContentData>> GetFolderDetails(StorageItem item)
        {
            try
            {
                return await _repository.FetchListWithParameter<ContentData>(SQLQueries.FETCH_ALL_SUB_CONTENT_FOR_FOLDER, new { FolderID = item.Id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ContentData>> GetFolderDetailsExcludingRoot(StorageItem item)
        {
            try
            {
                return await _repository.FetchListWithParameter<ContentData>(SQLQueries.FETCH_ALL_SUB_CONTENT_FOR_FOLDER_EXCLUDING_ROOT_FOLDER, new { FolderID = item.Id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Save(List<ContentData> folders)
        {
            try
            {
                int numberOfRowsAffected = await _repository.AddToDatabaseWithParameter(SQLQueries.SAVE_FOLDERS, folders);
                if (numberOfRowsAffected > 0)
                {
                    return Constants.TaskCompleted;
                }
                else
                {
                    return Constants.TaskFailed;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Save(ContentData folder)
        {
            try
            {
                int numberOfRowsAffected = await _repository.AddToDatabaseWithParameter(SQLQueries.SAVE_FOLDERS, folder);
                if (numberOfRowsAffected > 0)
                {
                    return Constants.TaskCompleted;
                }
                else
                {
                    return Constants.TaskFailed;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
