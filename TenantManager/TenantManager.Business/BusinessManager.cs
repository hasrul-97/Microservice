using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TenantManager.Abstraction.Business;
using TenantManager.Abstraction.DataAccess;
using TenantManager.Entities;

namespace TenantManager.Business
{
    public class BusinessManager : IBusinessManager
    {
        private readonly IDataAccessManager _dataAccess;
        private readonly IConfiguration _configuration;
        public BusinessManager(IDataAccessManager dataAccess, IConfiguration configuration)
        {
            _dataAccess = dataAccess;
            _configuration = configuration;
        }

        public async Task<string> GenerateToken()
        {
            // connect to our storage account and create a blob client
            var connectionString = _configuration.GetSection("StorageAccount").Value;
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            SharedAccessAccountPolicy policy = new SharedAccessAccountPolicy()
            {
                Permissions = SharedAccessAccountPermissions.Write | SharedAccessAccountPermissions.Create | SharedAccessAccountPermissions.Read,
                Services = SharedAccessAccountServices.Blob,
                ResourceTypes = SharedAccessAccountResourceTypes.Container | SharedAccessAccountResourceTypes.Object,
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(1),
                Protocols = SharedAccessProtocol.HttpsOnly,
            };

            return storageAccount.GetSharedAccessSignature(policy);
        }

        public async Task<Tenant> GetRootFolderDetails(string tenantID, string userID)
        {
            try
            {
                return await _dataAccess.GetRootFolderDetails(tenantID, userID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
