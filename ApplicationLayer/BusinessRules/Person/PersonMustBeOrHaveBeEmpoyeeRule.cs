

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IEmployee;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonMustBeOrHaveBeEmpoyeeRule : IPersonMustBeOrHaveBeEmpoyeeRule
    {
        private readonly IEmployeeRepository _employeeRepository;
        public PersonMustBeOrHaveBeEmpoyeeRule(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int personId)
        {
            if (!await _employeeRepository.PersonBeOrHaveBeEmployeeAsync(personId))
            {
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"The person with ID [{personId}] has never been an employee.");

            }

            return BusinessRuleResult.Success();
        }
    }
}
