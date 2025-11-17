using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Interfaces.IPerson;
using WinFormsClient.ViewModels;

namespace WinFormsClient.Configurations.Extensions
{
    public static class ViewModelExtensions
    {
        public static IServiceCollection AddViewModelServices(this IServiceCollection services)
        {
            services.AddSingleton<IPersonViewModel, PersonViewModel>();
            services.AddSingleton<IPhoneNumberViewModel, PhoneNumberViewModel>();

            return services;
        }
    }
}
