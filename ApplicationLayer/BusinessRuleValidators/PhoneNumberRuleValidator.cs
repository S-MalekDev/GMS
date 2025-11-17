

using ApplicationLayer.BusinessRules;
using CoreLayer.BusinessRules.Parameters;
using CoreLayer.Common;
using CoreLayer.DTOs.PersonDTOs.PhoneNumber;
using CoreLayer.Entities;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IBusinessRule.PhoneNumber;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class PhoneNumberRuleValidator : BaseBusinessRuleValidator, IPhoneNumberRuleValidator
    {
        private readonly IPersonMustExistRule _personMustExistRule;
        private readonly IPhoneNumberMustBeUniqueRule _phoneNumberMustBeUniqueRule;
        private readonly IPhoneNumberMustBeUniqueFoUpdateRule _phoneNumberMustBeUniqueFoUpdateRule;
        private readonly IPhoneNumberMustExistRule _phoneNumberMustExistRule;

        public PhoneNumberRuleValidator(IPersonMustExistRule personMustExistRule, 
            IPhoneNumberMustBeUniqueRule phoneNumberMustBeUniqueRule,
            IPhoneNumberMustExistRule phoneNumberMustExistRule,
            IPhoneNumberMustBeUniqueFoUpdateRule phoneNumberMustBeUniqueFoUpdateRule)
        {
            _personMustExistRule = personMustExistRule;
            _phoneNumberMustBeUniqueRule = phoneNumberMustBeUniqueRule;
            _phoneNumberMustExistRule = phoneNumberMustExistRule;
            _phoneNumberMustBeUniqueFoUpdateRule = phoneNumberMustBeUniqueFoUpdateRule;
        }

        public async Task<BusinessRuleResult> ValidateAddAsync(AddPhoneNumberDTO model)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () =>  _personMustExistRule.ValidateAsync(model.PersonID),
                () => _phoneNumberMustBeUniqueRule.ValidateAsync(model.PhoneNumber),
            };

            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateDeleteAsync(int phoneNumberId)
        {
            var ruleResult = await _phoneNumberMustExistRule.ValidateAsync(phoneNumberId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(int phoneNumberId)
        {
            var ruleResult = await _phoneNumberMustExistRule.ValidateAsync(phoneNumberId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateGetByPersonIdAsync(int personId)
        {
            var ruleResult = await _personMustExistRule.ValidateAsync(personId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateUpdateAsync(int phoneNumberId, UpdatePhoneNumberDTO model)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () =>  _phoneNumberMustExistRule.ValidateAsync(phoneNumberId),
                () => _phoneNumberMustBeUniqueFoUpdateRule.ValidateAsync
                    (
                        new PhoneNumberMustBeUniqueFoUpdateRuleParams
                    {
                            PhoneNumberId = phoneNumberId,
                            PhoneNumber = model.PhoneNumber
                    }
                    ),
            };

            return await ValidateRulesAsync(rules);
        }
    }
}
