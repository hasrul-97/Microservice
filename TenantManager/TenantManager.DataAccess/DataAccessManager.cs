using System;
using System.Threading.Tasks;
using TenantManager.Abstraction.DataAccess;
using TenantManager.Abstraction.Repository;
using TenantManager.DataAccess.Core;
using TenantManager.Entities;

namespace TenantManager.DataAccess
{
    public class DataAccessManager : IDataAccessManager
    {
        private readonly IRepositoryManager _repository;
        public DataAccessManager(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<Tenant> GetRootFolderDetails(string tenantID, string userID)
        {
            try
            {
                Tenant tenant = null;
                var tenantData = (await _repository.FetchDataWithParameter<Tenant>(SQLQueries.GetFolder, new { UserID = userID, TenantID = tenantID }));
                if (tenantData != null)
                {
                    tenant = tenantData;
                    if (await RootFolderIsNotPresentForTenant(tenant))
                    {
                        await CreateRootFolder(tenant.RootFolderID, tenant.UserID, tenant.TenantID);
                    }
                }
                return tenant;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RootFolderIsNotPresentForTenant(Tenant tenant)
        {
            var rootFolder = await _repository.FetchDataWithParameter<FolderDetail>(SQLQueries.GetUserRootFolder, new { UserID = tenant.UserID, TenantID = tenant.TenantID, RootFolderID = tenant.RootFolderID });
            if (rootFolder == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> CreateRootFolder(string rootFolderId, string userId, string tenantId)
        {
            try
            {
                FolderDetail folder = new FolderDetail();
                folder.UserID = userId;
                SetConstantValues(folder);
                folder.FolderID = rootFolderId;
                folder.TenantID = tenantId;
                folder.Name = "Root Folder";
                int numberOfRowsAffected = await _repository.AddToDatabaseWithParameter(SQLQueries.CreateRootFolder, folder);
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
    }
}
