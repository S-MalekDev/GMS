using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Mapping;

namespace WinFormsClient.Configurations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFormServices();
            services.AddFactoryServices();
            services.AddViewModelServices();
            services.AddLoggingServices();

            services.AddHttpClientConfigs();
            services.AddAutoMapperConfigs();
            services.AddAppSettingConfigs(configuration);
             
            return services;
        }
    }
}
