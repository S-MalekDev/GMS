using CoreLayer.BusinessRules.Parameters;
using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IPerson;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonEmailMustBeUniqueForUpdateRule : IPersonEmailMustBeUniqueForUpdateRule
    {
        private readonly IPersonRepository _personRepository;
        public PersonEmailMustBeUniqueForUpdateRule(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(PersonEmailMustBeUniqueForUpdateRuleParams model)
        {
            if (model.Email is null) return BusinessRuleResult.Success();

            var people = await _personRepository.GetAllAsync();

            if (people.Where(p => p.PersonID != model.PersonId).Any(p => p.Email == model.Email))
                return BusinessRuleResult.Failure(OperationResultStatus.Conflict, "The provided email address is already in use.");


            return BusinessRuleResult.Success();
        }
    }
}
