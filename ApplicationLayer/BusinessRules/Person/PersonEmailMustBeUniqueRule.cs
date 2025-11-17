using CoreLayer.Common;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IPerson;
using CoreLayer.Enums.OperationResult;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonEmailMustBeUniqueRule : IPersonEmailMustBeUniqueRule
    {
        private readonly IPersonRepository _personRepository;
        public PersonEmailMustBeUniqueRule(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(string? email)
        {
            if (email == null) return BusinessRuleResult.Success();

            if (await _personRepository.EmailExistsAsync(email))
                return BusinessRuleResult.Failure(OperationResultStatus.Conflict, "The provided email address is already in use.");

            return BusinessRuleResult.Success();
        }
    }
}
