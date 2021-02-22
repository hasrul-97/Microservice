using DMSManager.Abstraction.DataAccess;
using DMSManager.Abstraction.Repository;
using DMSManager.DataAccess.Core;
using DMSManager.Entities;
using DMSManager.Entities.Constants;
using DMSManager.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMSManager.DataAccess
{
    public class DataAccessManager : IDataAccessManager
    {
        private readonly IRepositoryManager _repositoryManager;
        public DataAccessManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<string> CreateFolder(FolderDetail folder)
        {
            try
            {
                SetConstantValues(folder);
                int numberOfRowsAffected = await _repositoryManager.AddToDatabaseWithParameter(SQLQueries.CreateFolder, folder);
                if (numberOfRowsAffected > 0)
                {
                    return "Folder has been created successfully";
                }
                else
                {
                    throw new Exception("An error has occured while creating the folder.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void SetConstantValues(FolderDetail folder)
        {
            folder.FolderID = Guid.NewGuid().ToString();
            folder.CreatedOn = DateTime.UtcNow;
            folder.Type = "Folder";
            folder.CreatedBy = folder.UserID;
            folder.LastModifiedBy = folder.UserID;
            folder.LastModifiedOn = DateTime.UtcNow;
        }

        public async Task<List<FolderDataRaw>> GetFolders(string tenant, string userID, string parent)
        {
            try
            {
                List<FolderDataRaw> folderData = await _repositoryManager.FetchListWithParameter<FolderDataRaw>(SQLQueries.GetUserFolders, new { UserID = userID, TenantID = tenant, Parent = parent });
                return folderData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> RenameFolder(FolderManager folder)
        {
            try
            {
                folder.LastModifiedBy = folder.UserID;
                folder.LastModifiedOn = DateTime.UtcNow;
                int numberOfRowsAffected = await _repositoryManager.UpdateWithParameter(SQLQueries.RenameFolder, folder);
                if (numberOfRowsAffected > 0)
                {
                    return "Folder has been renamed successfully";
                }
                else
                {
                    throw new NotFoundException("The specified folder is not present.");
                }
            }
            catch (Exception)
            {
                throw; ;
            }
        }

        public async Task<string> DeleteFolder(FolderDetail folder)
        {
            try
            {
                List<FolderDataRaw> folders = await _repositoryManager.FetchListWithParameter<FolderDataRaw>(SQLQueries.FETCH_ALL_SUB_CONTENT_FOR_FOLDER, new { FolderID = folder.FolderID });
                foreach (var content in folders)
                {
                    int numberOfRowsAffected = await _repositoryManager.DeleteWithParameter(SQLQueries.DeleteFolder, content);
                    if (numberOfRowsAffected > 0)
                    {
                        continue;
                    }
                    else
                    {
                        throw new Exception("The specified folder is not present");
                    }
                }
                return ConstantValues.TaskCompleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> SaveFile(FileDetail file)
        {
            try
            {
                SetConstantValues(file);
                int numberOfRowsAffected = await _repositoryManager.AddToDatabaseWithParameter(SQLQueries.CreateFile, file);
                if (numberOfRowsAffected > 0)
                {
                    return "File has been uploaded successfully";
                }
                else
                {
                    throw new Exception("An error has occured while uploading the file.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void SetConstantValues(FileDetail file)
        {
            file.FolderID = Guid.NewGuid().ToString();
            file.CreatedOn = DateTime.UtcNow;
            file.Type = "File";
            file.CreatedBy = file.UserID;
            file.LastModifiedBy = file.UserID;
            file.LastModifiedOn = DateTime.UtcNow;
        }
    }
}
