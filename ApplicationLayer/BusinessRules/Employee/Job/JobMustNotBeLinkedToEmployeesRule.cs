

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Employee.Job;
using CoreLayer.Interfaces.IEmployee;

namespace ApplicationLayer.BusinessRules.Employee.Job
{
    public class JobMustNotBeLinkedToEmployeesRule : IJobMustNotBeLinkedToEmployeesRule
    {
        private readonly IEmployeeRepository _employeeRepository;
        public JobMustNotBeLinkedToEmployeesRule(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(short jobId)
        {
            if(await _employeeRepository.HasEmployeesLinkedToJobAsync(jobId))
            {
                return BusinessRuleResult.Failure(OperationResultStatus.UnprocessableEntity,
                    $"This job is currently linked to one or more employees and cannot be deleted.");
            }

            return BusinessRuleResult.Success();
        }
    }
}
