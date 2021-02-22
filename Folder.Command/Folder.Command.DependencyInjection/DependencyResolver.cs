using Folder.ServiceWrapper;
using Folder.ServiceWrapper.Utlities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Common.LoadBalancer;

namespace Folder.Command.DependencyInjection
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
            service.AddScoped<UserServiceWrapper>();
            service.AddScoped<DMSServiceWrapper>();
            service.AddScoped<WrapperUtility>();
            service.AddScoped<RoundRobinLoadBalancer>();
        }
    }
}
