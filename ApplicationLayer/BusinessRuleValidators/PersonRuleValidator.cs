

using CoreLayer.Common;
using CoreLayer.DTOs.PersonDTOs;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.BusinessRules.Parameters;
using ApplicationLayer.BusinessRules;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class PersonRuleValidator :BaseBusinessRuleValidator, IPersonRuleValidator
    {
        private readonly IPersonMustExistRule _personMustExistRule;
        private readonly IPersonEmailMustBeUniqueRule _personEmailMustBeUniqueRule;
        private readonly IPersonEmailMustBeUniqueForUpdateRule _personEmailMustBeUniqueForUpdateRule;


        public PersonRuleValidator(IPersonMustExistRule personMustExistRule, 
            IPersonEmailMustBeUniqueRule personEmailMustBeUniqueRule,
            IPersonEmailMustBeUniqueForUpdateRule personEmailMustBeUniqueForUpdateRule)
        {
            _personMustExistRule = personMustExistRule;
            _personEmailMustBeUniqueRule = personEmailMustBeUniqueRule;
            _personEmailMustBeUniqueForUpdateRule = personEmailMustBeUniqueForUpdateRule;
        }

        public async Task<BusinessRuleResult> ValidateAddAsync(CreatePersonDTO personToCreate)
        {
            if (personToCreate.Email is null) return BusinessRuleResult.Success();

            var ruleResult = await _personEmailMustBeUniqueRule.ValidateAsync(personToCreate.Email);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateDeleteAsync(int personId)
        {
            var ruleResult = await _personMustExistRule.ValidateAsync(personId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(int personId)
        {
            var ruleResult = await _personMustExistRule.ValidateAsync(personId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateGetImageNameByIdAsync(int personId)
        {
            var ruleResult = await _personMustExistRule.ValidateAsync(personId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateUpdateAsync(int personId, UpdatePersonDTO model)
        {
            var ruleResult = await _personEmailMustBeUniqueForUpdateRule.ValidateAsync
                (
                new PersonEmailMustBeUniqueForUpdateRuleParams
                {
                    PersonId = personId,
                    Email = model.Email
                }
                );

            return ruleResult;
        }
    }
}
