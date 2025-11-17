using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Forms;
using WinFormsClient.Forms.Person;
using WinFormsClient.Forms.Theme;

namespace WinFormsClient.Configurations.Extensions
{
    public static class FormExtensions
    {
        public static IServiceCollection AddFormServices(this IServiceCollection services)
        {
            services.AddTransient<DashboardForm>();

            services.AddTransient<ThemeSelectorForm>();

            services.AddTransient<ManagePeopleForm>();
            services.AddTransient<ShowPersonDetailsForm>();
            services.AddTransient<AddAndUpdatePersonForm>();

            return services;
        }
    }
}
