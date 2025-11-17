

using CoreLayer.Common;
using CoreLayer.Entities;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Employee;
using CoreLayer.Interfaces.IEmployee;

namespace ApplicationLayer.BusinessRules.Employee
{
    public class EmployeeMustExistRule : IEmployeeMustExistRule
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeMustExistRule(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int employeeId)
        {
            if(! await  _employeeRepository.ExistsAsync(employeeId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"No employee was found with ID [{employeeId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
