using Folder.Command.Abstraction.ServiceWrapper;
using Folder.Command.Entities;
using Folder.ServiceWrapper.Utlities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Steeltoe.Discovery;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Folder.ServiceWrapper
{
    public class UserServiceWrapper
    {

        private HttpClient _httpClient;
        private string serviceId = string.Empty;
        private WrapperUtility _utility;
        public UserServiceWrapper(WrapperUtility utility, IHttpClientFactory factory, IConfiguration configuration)
        {
            _utility = utility;
            _httpClient = factory.CreateClient();
            serviceId = configuration.GetSection("TenantManager").Value;
        }
        public async Task<string> GetUserRootFolder(string tenant)
        {
            var url = string.Format("{0}{1}", await _utility.GetInstanceURI(serviceId), tenant);
            return await _utility.GetStringAsync(url);
        }
    }
}
