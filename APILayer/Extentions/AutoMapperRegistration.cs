using ApplicationLayer.Mapping;

namespace APILayer.Extentions
{
    public static class AutoMapperRegistration
    {
        public static void AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PersonProfile).Assembly);
            services.AddAutoMapper(typeof(PhoneNumberProfile).Assembly);
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddAutoMapper(typeof(JobProfile).Assembly);
            services.AddAutoMapper(typeof(EmployeeProfile).Assembly);
            services.AddAutoMapper(typeof(MemberProfile).Assembly);
            services.AddAutoMapper(typeof(TrainerProfile).Assembly);
            services.AddAutoMapper(typeof(SpecialityProfile).Assembly);
            services.AddAutoMapper(typeof(SubscriptionProfile).Assembly);
            services.AddAutoMapper(typeof(SubscriptionTypeProfile).Assembly);
            services.AddAutoMapper(typeof(SubscriptionDetailProfile).Assembly);
            services.AddAutoMapper(typeof(SubscriptionOfferProfile).Assembly);
            services.AddAutoMapper(typeof(ProgramTypeProfile).Assembly);


        }
    }
}
