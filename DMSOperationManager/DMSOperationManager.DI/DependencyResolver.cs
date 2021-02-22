using DMSOperationManager.Abstraction.Business;
using DMSOperationManager.Abstraction.DataAccess;
using DMSOperationManager.Abstraction.Repository;
using DMSOperationManager.Business;
using DMSOperationManager.DataAccess;
using DMSOperationManager.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMSOperationManager.DI
{
    public class DependencyResolver
    {
        public static void ConfigureService(IServiceCollection service)
        {
            service.AddScoped<ICopyHandler, CopyHandler>();
            service.AddScoped<IDataHandler, DataHandler>();
            service.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
