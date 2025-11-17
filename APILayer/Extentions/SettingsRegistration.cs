using CoreLayer.Configurations;
using System.Runtime.CompilerServices;

namespace APILayer.Extentions
{
    public static class SettingsRegistration
    {
        public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<LogSettings>(configuration.GetSection("LogSettings"));
            services.Configure<GeneralSettings>(configuration.GetSection("GeneralSettings"));
          
        }
    }
}
