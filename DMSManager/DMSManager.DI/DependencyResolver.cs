using DMSManager.Abstraction.Business;
using DMSManager.Abstraction.DataAccess;
using DMSManager.Abstraction.Repository;
using DMSManager.Business;
using DMSManager.DataAccess;
using DMSManager.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMSManager.DI
{
    public class DependencyResolver
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IBusinessManager, BusinessManager>();
            services.AddScoped<IDataAccessManager, DataAccessManager>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
