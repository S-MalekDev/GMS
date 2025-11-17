using Microsoft.Extensions.DependencyInjection;
using WinFormsClient.Mapping;

namespace WinFormsClient.Configurations.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperConfigs(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PersonProfile).Assembly);

            return services;
        }
    }
}
