using DMSAPI.Entities;
using DMSAPI.ServiceWrapper.Utility;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DMSAPI.ServiceWrapper
{
    public class TenantServiceWrapper
    {
        private string serviceId = string.Empty;
        private WrapperUtility _utility;
        public TenantServiceWrapper(WrapperUtility utility, IConfiguration configuration)
        {
            _utility = utility;
            serviceId = configuration.GetSection("TenantManager").Value;
        }
        public async Task<Tenant> GetTenantAsync(string tenant)
        {
            var url = string.Format("{0}{1}", await _utility.GetInstanceURI(serviceId), tenant);
            return (await _utility.GetAsync<Tenant>(url));
        }

        public async Task<string> GetTokenAsync(string tenant)
        {
            var url = string.Format("{0}{1}/token", await _utility.GetInstanceURI(serviceId), tenant);
            return (await _utility.GetStringAsync(url));
        }
    }
}
