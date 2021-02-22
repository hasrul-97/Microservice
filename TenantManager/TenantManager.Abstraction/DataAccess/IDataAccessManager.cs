using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenantManager.Entities;

namespace TenantManager.Abstraction.DataAccess
{
    public interface IDataAccessManager
    {
        Task<Tenant> GetRootFolderDetails(string tenantID, string userID);
    }
}
