

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IEmployee;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonMustNotBeEmployeeRule : IPersonMustNotBeEmployeeRule
    {
        private readonly IEmployeeRepository _employeeRepository;

        public PersonMustNotBeEmployeeRule(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int personId)
        {
            if (await _employeeRepository.ExistsByPersonIdAsync(personId))
            {
                return BusinessRuleResult.Failure(
                    OperationResultStatus.Conflict,
                    "This person is already linked to an existed employee."
                );
            }

            if (await _employeeRepository.PersonHasDeletedEmployeeAsync(personId))
            {
                return BusinessRuleResult.Failure(
                    OperationResultStatus.Conflict,
                    "This person is already linked to a deleted employee. Use the restore functionality to reactivate the account."
                );
            }

            return BusinessRuleResult.Success();
        }
    }
}
