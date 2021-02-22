using Folder.Command.Entities;
using Folder.ServiceWrapper.Utlities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Folder.ServiceWrapper
{
    public class DMSServiceWrapper
    {
        private WrapperUtility _utility;
        private string serviceId = string.Empty;
        public DMSServiceWrapper(WrapperUtility utility, IConfiguration configuration)
        {
            _utility = utility;
            serviceId = configuration.GetSection("DMSManager").Value;
        }

        public async Task<HttpResponseMessage> GetFolders(string tenant, string userId)
        {
            var url = string.Format("{0}DMS/?tenant={1}&userID={2}", await _utility.GetInstanceURI(serviceId), tenant, userId);
            return await _utility.GetAsync(url);
        }

        public async Task<HttpResponseMessage> CreateFolder(FolderDetail folder)
        {
            var url = string.Format("{0}DMS", await _utility.GetInstanceURI(serviceId));
            return await _utility.PostAsync<FolderDetail>(folder, url);
        }

        public async Task<HttpResponseMessage> RenameFolder(FolderManager folder)
        {
            var url = string.Format("{0}DMS", await _utility.GetInstanceURI(serviceId));
            return await _utility.PutAsync<FolderManager>(folder, url);
        }

        public async Task<HttpResponseMessage> DeleteFolder(FolderDetail folder)
        {
            var url = string.Format("{0}DMS", await _utility.GetInstanceURI(serviceId));
            return await _utility.DeleteAsync<FolderDetail>(folder, url);
        }
    }
}
