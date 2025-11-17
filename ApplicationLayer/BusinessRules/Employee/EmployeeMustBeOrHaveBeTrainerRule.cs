

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Employee;
using CoreLayer.Interfaces.IMember;
using CoreLayer.Interfaces.ITrainer;

namespace ApplicationLayer.BusinessRules.Employee
{
    public class EmployeeMustBeOrHaveBeTrainerRule : IEmployeeMustBeOrHaveBeTrainerRule
    {
        private readonly ITrainerRepository _trainerRepository;
        public EmployeeMustBeOrHaveBeTrainerRule(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int employeeId)
        {
            if (!await _trainerRepository.EmployeeBeOrHaveBeTrainerAsync(employeeId))
            {
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"The employee with ID [{employeeId}] has never been a trainer.");

            }

            return BusinessRuleResult.Success();
        }
    }
}
