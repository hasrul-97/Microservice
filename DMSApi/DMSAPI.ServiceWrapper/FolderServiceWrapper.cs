using DMSAPI.Entities;
using DMSAPI.ServiceWrapper.Utility;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DMSAPI.ServiceWrapper
{
    public class FolderServiceWrapper
    {
        private WrapperUtility _utility;
        private string serviceId = string.Empty;
        public FolderServiceWrapper(WrapperUtility utility, IConfiguration configuration)
        {
            _utility = utility;
            serviceId = configuration.GetSection("DMSManager").Value;
        }

        public async Task<FolderData> GetAsync(string tenant, string userId, string rootFolderId)
        {
            var url = string.Format("{0}DMS/?tenant={1}&userID={2}&rootFolderId={3}", await _utility.GetInstanceURI(serviceId), tenant, userId, rootFolderId);
            return await _utility.GetAsync<FolderData>(url);
        }

        public async Task<string> CreateAsync(FolderDetail folder)
        {
            var url = string.Format("{0}DMS", await _utility.GetInstanceURI(serviceId));
            return await _utility.PostAsync<FolderDetail>(folder, url);
        }

        public async Task<string> CreateAsync(FileDetail file)
        {
            var url = string.Format("{0}DMS/File/Save", await _utility.GetInstanceURI(serviceId));
            return await _utility.PostAsync<FileDetail>(file, url);
        }

        public async Task<string> RenameAsync(FolderManager folder)
        {
            var url = string.Format("{0}DMS", await _utility.GetInstanceURI(serviceId));
            return await _utility.PutAsync<FolderManager>(folder, url);
        }

        public async Task<string> DeleteAsync(FolderDetail folder)
        {
            var url = string.Format("{0}DMS", await _utility.GetInstanceURI(serviceId));
            return await _utility.DeleteAsync<FolderDetail>(folder, url);
        }
    }
}
