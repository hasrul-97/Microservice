using DMSAPI.ServiceWrapper;
using DMSAPI.ServiceWrapper.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMSAPI.DI
{
    public class DependencyResolver
    {
        public static IConfiguration Configuration { get; set; }
        public DependencyResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static void ConfigureService(IServiceCollection service)
        {
            service.AddScoped<TenantServiceWrapper>();
            service.AddScoped<FolderServiceWrapper>();
            service.AddScoped<WrapperUtility>();
            service.AddScoped<FolderCopyMoveServiceWrapper>();
        }
    }
}
