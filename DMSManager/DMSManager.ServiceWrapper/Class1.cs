using System;

namespace DMSManager.ServiceWrapper
{
    public class TenantServiceWrapper
    {
        public TenantServiceWrapper(HttpClient http)
        {
            _http = http;
        }

        private HttpClient _http;

        public Tenant GetTenantContext(string tenant)
        {

        }
    }
}
