using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Interfaces.IPerson;
using WinFormsClient.Services;

namespace WinFormsClient.Configurations.Extensions
{
    public static class HttpClientExtensions
    {
        public static IServiceCollection AddHttpClientConfigs(this IServiceCollection services)
        {
            services.AddHttpClient<IPersonService, PersonService>((sp, client) =>
            {
                var settings = sp.GetRequiredService<IOptions<ApiSettings>>().Value;
                client.BaseAddress = new Uri(settings.BaseAddress + "people/");
            });
            services.AddHttpClient<IPhoneNumberService, PhoneNumberService>((sp, client) =>
            {
                var settings = sp.GetRequiredService<IOptions<ApiSettings>>().Value;
                client.BaseAddress = new Uri(settings.BaseAddress + "people/phone-numbers/");
            });

            return services;
        }
    }
}
