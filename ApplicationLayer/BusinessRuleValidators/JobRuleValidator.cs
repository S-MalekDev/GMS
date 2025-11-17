

using ApplicationLayer.BusinessRules;
using CoreLayer.Common;
using CoreLayer.DTOs.JobDTOs;
using CoreLayer.Interfaces.IBusinessRule.Employee.Job;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class JobRuleValidator : BaseBusinessRuleValidator, IJobRuleValidator
    {
        private readonly IJobMustExistRule _jobMustExistRule;
        private readonly IJobMustNotBeLinkedToEmployeesRule _jobMustNotBeLinkedToEmployeesRule;

        public JobRuleValidator(IJobMustExistRule jobMustExistRule,
            IJobMustNotBeLinkedToEmployeesRule jobMustNotBeLinkedToEmployeesRule)
        {
            _jobMustExistRule = jobMustExistRule;
            _jobMustNotBeLinkedToEmployeesRule = jobMustNotBeLinkedToEmployeesRule;
        }
        
        public async Task<BusinessRuleResult> ValidateDeleteAsync(short jobId)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _jobMustExistRule.ValidateAsync(jobId),
                () => _jobMustNotBeLinkedToEmployeesRule.ValidateAsync(jobId),
            };

            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(short jobId)
        {
            var ruleResult = await _jobMustExistRule.ValidateAsync(jobId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateUpdateAsync(short jobId, UpdateJobDTO model)
        {
            var ruleResult = await _jobMustExistRule.ValidateAsync(jobId);

            return ruleResult;
        }
    }
}
