using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IPerson;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonMustExistRule : IPersonMustExistRule
    {
        private readonly IPersonRepository _personRepository;

        public PersonMustExistRule(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int personId)
        {
            if (!await _personRepository.ExistsAsync(personId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"No person was found with ID [{personId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
