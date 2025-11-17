

using ApplicationLayer.BusinessRules;
using ApplicationLayer.BusinessRules.Trainer;
using CoreLayer.Common;
using CoreLayer.DTOs.TrainerDTOs;
using CoreLayer.Entities;
using CoreLayer.Interfaces.IBusinessRule.Employee;
using CoreLayer.Interfaces.IBusinessRule.JobSpeciality;
using CoreLayer.Interfaces.IBusinessRule.Trainer;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class TrainerRuleValidator : BaseBusinessRuleValidator, ITrainerRuleValidator
    {
        private readonly ITrainerMustExistRule _trainerMustExistRule;
        private readonly IEmployeeMustExistRule _employeeMustExistRule;
        private readonly IEmployeeMustBeOrHaveBeTrainerRule _employeeMustBeOrHaveBeTrainerRule;
        private readonly IEmployeeMustNotBeAssignedToTrainerRule _employeeMustNotBeAssignedToTrainerRule;
        private readonly IJobSpecialityMustExistRule _jobSpecialityMustExistRule;
        private readonly IUserMustExistByIdRule _userMustExistByIdRule;
        private readonly IUserMustBeActiveRule _userMustBeActiveRule;

        public TrainerRuleValidator(ITrainerMustExistRule trainerMustExistRule,
            IEmployeeMustExistRule employeeMustExistRule,
            IEmployeeMustNotBeAssignedToTrainerRule employeeMustNotBeAssignedToTrainerRule,
            IJobSpecialityMustExistRule jobSpecialityMustExistRule,
            IUserMustExistByIdRule userMustExistByIdRule,
            IUserMustBeActiveRule userMustBeActiveRule,
            IEmployeeMustBeOrHaveBeTrainerRule employeeMustBeOrHaveBeTrainerRule)
        {
            _trainerMustExistRule = trainerMustExistRule;
            _employeeMustExistRule = employeeMustExistRule;
            _jobSpecialityMustExistRule = jobSpecialityMustExistRule;
            _userMustExistByIdRule = userMustExistByIdRule;
            _userMustBeActiveRule = userMustBeActiveRule;
            _employeeMustNotBeAssignedToTrainerRule = employeeMustNotBeAssignedToTrainerRule;
            _employeeMustBeOrHaveBeTrainerRule = employeeMustBeOrHaveBeTrainerRule;
        }

        public async Task<BusinessRuleResult> ValidateAddAsync(AddTrainerDTO model)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _employeeMustExistRule.ValidateAsync(model.EmployeeId),
                () => _employeeMustNotBeAssignedToTrainerRule.ValidateAsync(model.EmployeeId),
                () => _jobSpecialityMustExistRule.ValidateAsync(model.SpecialityId),
                () => _userMustExistByIdRule.ValidateAsync(model.CreatedByUserId),
                () => _userMustBeActiveRule.ValidateAsync(model.CreatedByUserId),
            };

            //if (model.PersonalTrainerId.HasValue)
            //{
            //    rules.AddRange
            //        (
            //            new List<Func<Task<BusinessRuleResult>>>
            //            {
            //                () => _trainerMustExistRule.ValidateAsync(model.PersonalTrainerId.Value),
            //                () => _trainerMustBeActiveRule.ValidateAsync(model.PersonalTrainerId.Value),
            //            }
            //        );
            //}

            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateDeleteAsync(int trainerId)
        {
            var ruleResult = await _trainerMustExistRule.ValidateAsync(trainerId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(int trainerId)
        {
            var ruleResult = await _trainerMustExistRule.ValidateAsync(trainerId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateRestoreAsync(int employeeId)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _employeeMustExistRule.ValidateAsync(employeeId),
                () => _employeeMustBeOrHaveBeTrainerRule.ValidateAsync(employeeId),
            };

            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateUpdateAsync(int trainerId, UpdateTrainerDTO model)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _trainerMustExistRule.ValidateAsync(trainerId),
                () => _jobSpecialityMustExistRule.ValidateAsync(model.SpecialityId),
            };

            return await ValidateRulesAsync(rules);
        }
    }
}
