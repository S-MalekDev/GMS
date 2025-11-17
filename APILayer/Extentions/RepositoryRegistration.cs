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
using CoreLayer.Interfaces.ITranierSpeciality;
using CoreLayer.Interfaces.IUser;
using DataAccessLayer.Repositories;

namespace APILayer.Extentions
{
    public static class RepositoryRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ISubscriptionTypeRepository, SubscriptionTypeRepository>();
            services.AddScoped<ISubscriptionDetailRepository, SubscriptionDetailRepository>();
            services.AddScoped<ISubscriptionOfferRepository, SubscriptionOfferRepository>();
            services.AddScoped<IProgramTypeRepository, ProgramTypeRepository>();


            services.AddScoped<IDatabaseLogRepository, DatabaseLogRepository>();
        }
    }
}
