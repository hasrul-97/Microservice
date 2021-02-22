using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenantManager.Entities;

namespace TenantManager.Abstraction.Business
{
    public interface IBusinessManager
    {
        Task<Tenant> GetRootFolderDetails(string tenantID,string userID);
        Task<string> GenerateToken();
    }
}
