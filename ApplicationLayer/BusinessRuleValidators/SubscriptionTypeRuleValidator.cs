

using ApplicationLayer.BusinessRules;
using ApplicationLayer.BusinessRules.SubscriptionType;
using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionTypeDTOs;
using CoreLayer.Entities;
using CoreLayer.Interfaces.IBusinessRule.ProgramType;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionType;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class SubscriptionTypeRuleValidator : BaseBusinessRuleValidator, ISubscriptionTypeRuleValidator
    {
        private readonly ISubscriptionTypeMustExistRule _subscriptionTypeMustExistRule;
        private readonly IProgramTypeMustExistRule _programTypeMustExistRule;

        public SubscriptionTypeRuleValidator(ISubscriptionTypeMustExistRule subscriptionTypeMustExistRule,
            IProgramTypeMustExistRule programTypeMustExistRule)
        {
            _subscriptionTypeMustExistRule = subscriptionTypeMustExistRule;
            _programTypeMustExistRule = programTypeMustExistRule;
        }
        public Task<BusinessRuleResult> ValidateGetByIdAsync(int subscriptionTypeId)
        {
            var ruleResult = _subscriptionTypeMustExistRule.ValidateAsync(subscriptionTypeId);

            return ruleResult;
        }
        public async Task<BusinessRuleResult> ValidateDeleteAsync(int subscriptionTypeId)
        {
            var ruleResult = await _subscriptionTypeMustExistRule.ValidateAsync(subscriptionTypeId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateAddAsync(AddSubscriptionTypeDTO addModel)
        {
            var ruleResult = await _programTypeMustExistRule.ValidateAsync(addModel.ProgramTypeId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateUpdateAsync(int subscriptionTypeId, UpdateSubscriptionTypeDTO updateModel)
        {
            var rules = new List<Func<Task<BusinessRuleResult>>>()
            {
                () => _subscriptionTypeMustExistRule.ValidateAsync(subscriptionTypeId),
                () => _programTypeMustExistRule.ValidateAsync(updateModel.ProgramTypeId),

            };


            return await ValidateRulesAsync(rules);
        }
    }
}
