using ApplicationLayer.Helpers;
using ApplicationLayer.Services;
using CoreLayer.Interfaces.Helpers;
using CoreLayer.Interfaces.IEmployee;
using CoreLayer.Interfaces.IJob;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.IMember;
using CoreLayer.Interfaces.IPerson;
using CoreLayer.Interfaces.IPerson.Phone;
using CoreLayer.Interfaces.IProgramType;
using CoreLayer.Interfaces.ISubscription;
using CoreLayer.Interfaces.ISubscriptionDetail;
using CoreLayer.Interfaces.ISubscriptionOffer;
using CoreLayer.Interfaces.ISubscriptionType;
using CoreLayer.Interfaces.ITrainer;
using CoreLayer.Interfaces.ITrainerSpeciality;
using CoreLayer.Interfaces.IUser;

namespace APILayer.Extentions
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPhoneNumberService, PhoneNumberService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<ISpecialityService, SpecialityService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ISubscriptionTypeService, SubscriptionTypeService>();
            services.AddScoped<ISubscriptionDetailService, SubscriptionDetailService>();
            services.AddScoped<ISubscriptionOfferService, SubscriptionOfferService>();
            services.AddScoped<IProgramTypeService, ProgramTypeService>();

            services.AddScoped<IDatabaseLogService, DatabaseLogService>();

            services.AddSingleton<IPasswordHasher, BcryptPasswordHasher>();

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IUrlBuilder, UrlBuilder>();


            services.AddTransient<ImageUrlResolver>();
        }
    }
}
