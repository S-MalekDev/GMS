using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Factories;
using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.Configurations.Extensions
{
    public static class FactoryExtensionsExtensions
    {
        public static IServiceCollection AddFactoryServices (this IServiceCollection services)
        {
            services.AddSingleton<IPersonDetailsFormFactory, PersonDetailsFormFactory>();
            services.AddSingleton<ICreateUpdatePersonFormFactory, CreateUpdatePersonFormFactory>();

            return services;
        }
    }
}
