using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.Configurations.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddAppSettingConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
            services.Configure<LogSettings>(configuration.GetSection("LogSettings"));
            services.Configure<EventViewerLogSettings>(configuration.GetSection("Logging:EventViewer"));

            return services;
        }
    }
}
