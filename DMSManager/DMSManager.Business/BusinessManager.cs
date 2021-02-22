using DMSManager.Abstraction.Business;
using DMSManager.Abstraction.DataAccess;
using DMSManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSManager.Business
{
    public class BusinessManager : IBusinessManager
    {
        private readonly IDataAccessManager _dataAccessManager;
        public BusinessManager(IDataAccessManager dataAccessManager)
        {
            _dataAccessManager = dataAccessManager;
        }

        public async Task<string> CreateFolder(FolderDetail folder)
        {
            try
            {
                return await _dataAccessManager.CreateFolder(folder);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteFolder(FolderDetail folder)
        {
            try
            {
                return await _dataAccessManager.DeleteFolder(folder);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FolderData> GetFolders(string tenant, string userID, string parent)
        {
            try
            {
                FolderData folders = new FolderData();
                folders.UserID = userID;
                folders.Parent = parent;
                List<FolderDataRaw> folderData = await _dataAccessManager.GetFolders(tenant, userID, parent);
                foreach (var item in folderData)
                {
                    if (item.Type == "Folder")
                    {
                        folders.Items.Add(new Folder(item.FolderID, item.Name, item.CreatedOn, item.CreatedBy, item.LastModifiedOn, item.LastModifiedBy, item.Parent));
                    }
                    else
                    {
                        var latestFile = folderData.FirstOrDefault(_ => _.Version.Equals(folderData.Max(_ => _.Version)));
                        if (folders.Items.Find(_ => _.Id.Equals(latestFile.FolderID)) == null)
                        {
                            folders.Items.Add(new File(latestFile.FolderID, latestFile.Name, latestFile.CreatedOn, latestFile.FileType, latestFile.CreatedBy, latestFile.LastModifiedOn, latestFile.LastModifiedBy, latestFile.Parent, latestFile.PhysicalLocation, latestFile.Version, latestFile.Size));
                        }
                    }
                }
                return folders;

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
                return await _dataAccessManager.RenameFolder(folder);
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
                return await _dataAccessManager.SaveFile(file);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
