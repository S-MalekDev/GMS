

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Employee;
using CoreLayer.Interfaces.ITrainer;

namespace ApplicationLayer.BusinessRules.Employee
{
    public class EmployeeMustNotBeAssignedToTrainerRule : IEmployeeMustNotBeAssignedToTrainerRule
    {
        private readonly ITrainerRepository _trainerRepository;
        public EmployeeMustNotBeAssignedToTrainerRule(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int employeeId)
        {
            if (await _trainerRepository.EmployeeBeOrHaveBeTrainerAsync(employeeId))
            {
                return BusinessRuleResult.Failure(
                    OperationResultStatus.Conflict,
                    "This employee is already linked to an existed trainer."
                );
            }

            if (await _trainerRepository.EmployeeHasDeletedTrainerAsync(employeeId))
            {
                return BusinessRuleResult.Failure(
                    OperationResultStatus.Conflict,
                    "This employee is already linked to a deleted trainer. Use the restore functionality to reactivate the account."
                );
            }

            return BusinessRuleResult.Success();
        }
    }
}
