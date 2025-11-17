using Microsoft.Extensions.DependencyInjection;

namespace APILayer.Extentions
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices();
            services.AddRepositories();
            services.AddMappingProfiles();
            services.AddLoggingServices();
            services.AddMappingProfiles();
            services.AddBusinessRuleServices();
            services.AddDatabase(configuration); 
            services.AddAppSettings(configuration);
        }
    }
}
