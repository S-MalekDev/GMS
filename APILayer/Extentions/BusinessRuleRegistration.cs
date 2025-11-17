using ApplicationLayer.BusinessRules.Employee;
using ApplicationLayer.BusinessRules.Employee.Job;
using ApplicationLayer.BusinessRules.JobSpeciality;
using ApplicationLayer.BusinessRules.Member;
using ApplicationLayer.BusinessRules.Person;
using ApplicationLayer.BusinessRules.PhoneNumber;
using ApplicationLayer.BusinessRules.ProgramType;
using ApplicationLayer.BusinessRules.SubsciptionOffer;
using ApplicationLayer.BusinessRules.Subscription;
using ApplicationLayer.BusinessRules.SubscriptionDetail;
using ApplicationLayer.BusinessRules.SubscriptionType;
using ApplicationLayer.BusinessRules.Trainer;
using ApplicationLayer.BusinessRules.User;
using ApplicationLayer.BusinessRuleValidators;
using CoreLayer.Interfaces.IBusinessRule.Employee;
using CoreLayer.Interfaces.IBusinessRule.Employee.Job;
using CoreLayer.Interfaces.IBusinessRule.JobSpeciality;
using CoreLayer.Interfaces.IBusinessRule.Member;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IBusinessRule.PhoneNumber;
using CoreLayer.Interfaces.IBusinessRule.ProgramType;
using CoreLayer.Interfaces.IBusinessRule.Subscription;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionDetail;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionOffer;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionType;
using CoreLayer.Interfaces.IBusinessRule.Trainer;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace APILayer.Extentions
{
    public static class BusinessRuleRegistration
    {
        public static IServiceCollection AddBusinessRuleServices(this IServiceCollection services)
        {

            // Rule Validators.
            services.AddScoped<IPersonRuleValidator, PersonRuleValidator>();
            services.AddScoped<IPhoneNumberRuleValidator, PhoneNumberRuleValidator>();
            services.AddScoped<IUserRuleValidator, UserRuleValidator>();
            services.AddScoped<IMemberRuleValidator, MemberRuleValidator>();
            services.AddScoped<ISubscriptionRuleValidator, SubscriptionRuleValidator>();
            services.AddScoped<IEmployeeRuleValidator, EmployeeRuleValidator>();
            services.AddScoped<ITrainerRuleValidator, TrainerRuleValidator>();
            services.AddScoped<IJobRuleValidator, JobRuleValidator>();
            services.AddScoped<IJobSpecialityRuleValidator, JobSpecialityRuleValidator>();
            services.AddScoped<IProgramTypeRuleValidator, ProgramTypeRuleValidator>();
            services.AddScoped<ISubscriptionDetailRuleValidator, SubscriptionDetailRuleValidator>();
            services.AddScoped<ISubscriptionOfferRuleValidator, SubscriptionOfferRuleValidator>();
            services.AddScoped<ISubscriptionTypeRuleValidator, SubscriptionTypeRuleValidator>();



            // Person Rules
            services.AddScoped<IPersonMustExistRule, PersonMustExistRule>();
            services.AddScoped<IPersonEmailMustBeUniqueRule, PersonEmailMustBeUniqueRule>();
            services.AddScoped<IPersonEmailMustBeUniqueForUpdateRule, PersonEmailMustBeUniqueForUpdateRule>();
            services.AddScoped<IPersonMustNotHaveUserRule, PersonMustNotHaveUserRule>();
            services.AddScoped<IPersonMustHaveDeletedUserAccountRule, PersonMustHaveDeletedUserAccountRule>();
            services.AddScoped<IPersonMustHasOrHadUserRule, PersonMustHasOrHadUserRule>();
            services.AddScoped<IPersonMustNotBeMemberRule, PersonMustNotBeMemberRule>();
            services.AddScoped<IPersonMustBeOrHaveBeMemberRule, PersonMustBeOrHaveBeMemberRule>();
            services.AddScoped<IPersonMustNotBeEmployeeRule, PersonMustNotBeEmployeeRule>();
            services.AddScoped<IPersonMustBeOrHaveBeEmpoyeeRule, PersonMustBeOrHaveBeEmpoyeeRule>();

            // Subscription Dtail Rules.
            services.AddScoped<ISubscriptionDetailMustExistRule, SubscriptionDetailMustExistRule>();


            // Phone Number Rules.
            services.AddScoped<IPhoneNumberMustBeUniqueRule, PhoneNumberMustBeUniqueRule>();
            services.AddScoped<IPhoneNumberMustExistRule, PhoneNumberMustExistRule>();
            services.AddScoped<IPhoneNumberMustBeUniqueFoUpdateRule, PhoneNumberMustBeUniqueFoUpdateRule>();


            // Program Type Rules.
            services.AddScoped<IProgramTypeMustExistRule, ProgramTypeMustExistRule>();



            // Employee Rules.
            services.AddScoped<IEmployeeMustExistRule, EmployeeMustExistRule>();
            services.AddScoped<IEmployeeMustNotBeAssignedToTrainerRule, EmployeeMustNotBeAssignedToTrainerRule>();
            services.AddScoped<IEmployeeMustBeOrHaveBeTrainerRule, EmployeeMustBeOrHaveBeTrainerRule>();



            // Job Rules.
            services.AddScoped<IJobMustExistRule, JobMustExistRule>();
            services.AddScoped<IJobMustNotBeLinkedToEmployeesRule, JobMustNotBeLinkedToEmployeesRule>();

            // Job Speciality Rules.
            services.AddScoped<IJobSpecialityMustExistRule, JobSpecialityMustExistRule>();


            // Member Rules.
            services.AddScoped<IMemberMustExistRule, MemberMustExistRule>();
            services.AddScoped<IMemberMustBeActiveRule, MemberMustBeActiveRule>();
            services.AddScoped<IMemberMustHasNotActiveSubscriptionRule, MemberMustHasNotActiveSubscriptionRule>();


            // User Rules.
            services.AddScoped<IUserMustExistByIdRule, UserMustExistByIdRule>();
            services.AddScoped<IUserMustExistByUsernameRule, UserMustExistByUsernameRule>();
            services.AddScoped<IUserMustBeActiveRule, UserMustBeActiveRule>();
            services.AddScoped<IUsernameMustBeUniqueRule, UsernameMustBeUniqueRule>();
            services.AddScoped<IUsernameMustBeUniqueForUpdateRule, UsernameMustBeUniqueForUpdateRule>();


            // Trainer Rules.
            services.AddScoped<ITrainerMustExistRule, TrainerMustExistRule>();
            services.AddScoped<ITrainerMustBeActiveRule, TrainerMustBeActiveRule>();



            // Subscription Type Rules.
            services.AddScoped<ISubscriptionTypeMustExistRule, SubscriptionTypeMustExistRule>();
            services.AddScoped<ISubscriptionTypeMustBeActiveRule, SubscriptionTypeMustBeActiveRule>();


            // Subscription Offer Rules.
            services.AddScoped<IOfferMustMatchSubscriptionTypeRule, OfferMustMatchSubscriptionTypeRule>();
            services.AddScoped<ISubscriptionOfferMustBeActiveRule, SubscriptionOfferMustBeActiveRule>();
            services.AddScoped<ISubscriptionOfferMustExistRule, SubscriptionOfferMustExistRule>();


            // Subscription Rules.
            services.AddScoped<ISubscriptionPreventOverlapRule, SubscriptionPreventOverlapRule>();
            services.AddScoped<ISubscriptionMustExistRule, SubscriptionMustExistRule>();
            services.AddScoped<ISubscriptionMustBePendingRule, SubscriptionMustBePendingRule>();
            services.AddScoped<ISubscriptionPreventOverlapUpdateRule, SubscriptionPreventOverlapUpdateRule>();
            services.AddScoped<ISubscriptionMustBeActiveOrPendingRule, SubscriptionMustBeActiveOrPendingRule>();


            return services;
        }
    }
}
