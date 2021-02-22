using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TenantManager.Abstraction.Business;
using TenantManager.Abstraction.DataAccess;
using TenantManager.Abstraction.Repository;
using TenantManager.Business;
using TenantManager.DataAccess;
using TenantManager.Repository;

namespace TenantManager.DI
{
    public class DepedencyResolver
    {
        public static void ConigureService(IServiceCollection services)
        {
            services.AddScoped<IBusinessManager, BusinessManager>();
            services.AddScoped<IDataAccessManager, DataAccessManager>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
