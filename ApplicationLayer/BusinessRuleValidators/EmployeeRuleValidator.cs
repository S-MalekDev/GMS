

using ApplicationLayer.BusinessRules;
using CoreLayer.Common;
using CoreLayer.DTOs.EmployeeDTOs;
using CoreLayer.Entities;
using CoreLayer.Interfaces.IBusinessRule.Employee;
using CoreLayer.Interfaces.IBusinessRule.Employee.Job;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class EmployeeRuleValidator : BaseBusinessRuleValidator, IEmployeeRuleValidator
    {
        private readonly IEmployeeMustExistRule _employeeMustExistRule;
        private readonly IPersonMustExistRule _personMustExistRule;
        private readonly IPersonMustNotBeEmployeeRule _personMustNotBeEmployeeRule;
        private readonly IJobMustExistRule _jobMustExistRule;
        private readonly IUserMustExistByIdRule _userMustExistByIdRule;
        private readonly IUserMustBeActiveRule _userMustBeActiveRule;
        private readonly IPersonMustBeOrHaveBeEmpoyeeRule _personMustBeOrHaveBeEmpoyeeRule;


        public EmployeeRuleValidator(IEmployeeMustExistRule employeeMustExistRule,
            IPersonMustExistRule personMustExistRule,
            IPersonMustNotBeEmployeeRule personMustNotBeEmployeeRule,
            IJobMustExistRule jobMustExistRule,
            IUserMustExistByIdRule userMustExistByIdRule,
            IUserMustBeActiveRule userMustBeActiveRule,
            IPersonMustBeOrHaveBeEmpoyeeRule personMustBeOrHaveBeEmpoyeeRule)
        {
            _employeeMustExistRule = employeeMustExistRule;
            _personMustExistRule = personMustExistRule;
            _personMustNotBeEmployeeRule = personMustNotBeEmployeeRule;
            _jobMustExistRule = jobMustExistRule;
            _userMustExistByIdRule = userMustExistByIdRule;
            _userMustBeActiveRule = userMustBeActiveRule;
            _personMustBeOrHaveBeEmpoyeeRule = personMustBeOrHaveBeEmpoyeeRule;
        }

        public async Task<BusinessRuleResult> ValidateAddAsync(AddEmployeeDTO model)
        {

            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _personMustExistRule.ValidateAsync(model.PersonId),
                () => _personMustNotBeEmployeeRule.ValidateAsync(model.PersonId),
                () => _jobMustExistRule.ValidateAsync(model.JobId),
                () => _userMustExistByIdRule.ValidateAsync(model.CreatedByUserId),
                () => _userMustBeActiveRule.ValidateAsync(model.CreatedByUserId)
            };


            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateDeleteAsync(int employeeId)
        {
            var ruleResult = await _employeeMustExistRule.ValidateAsync(employeeId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(int employeeId)
        {
            var ruleResult = await _employeeMustExistRule.ValidateAsync(employeeId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateRestoreAsync(int personId)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _personMustExistRule.ValidateAsync(personId),
                () => _personMustBeOrHaveBeEmpoyeeRule.ValidateAsync(personId)
            };


            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateUpdateAsync(int employeeId, UpdateEmployeeDTO model)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _employeeMustExistRule.ValidateAsync(employeeId),
                () => _jobMustExistRule.ValidateAsync(model.JobId)
            };


            return await ValidateRulesAsync(rules);
        }
    }
}
