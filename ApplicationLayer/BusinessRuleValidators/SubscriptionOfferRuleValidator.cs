

using ApplicationLayer.BusinessRules;
using ApplicationLayer.BusinessRules.SubsciptionOffer;
using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionOfferDTOs;
using CoreLayer.Entities;
using CoreLayer.IBusinessRules.Parameters;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionOffer;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionType;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class SubscriptionOfferRuleValidator : BaseBusinessRuleValidator, ISubscriptionOfferRuleValidator
    {
        private readonly ISubscriptionOfferMustExistRule _subscriptionOfferMustExistRule;
        private readonly ISubscriptionTypeMustExistRule _subscriptionTypeMustExistRule;
        private readonly ISubscriptionTypeMustBeActiveRule _subscriptionTypeMustBeActiveRule;

        public SubscriptionOfferRuleValidator(ISubscriptionOfferMustExistRule subscriptionOfferMustExistRule,
            ISubscriptionTypeMustExistRule subscriptionTypeMustExistRule,
            ISubscriptionTypeMustBeActiveRule subscriptionTypeMustBeActiveRule)
        {
            _subscriptionOfferMustExistRule = subscriptionOfferMustExistRule;
            _subscriptionTypeMustExistRule = subscriptionTypeMustExistRule;
            _subscriptionTypeMustBeActiveRule = subscriptionTypeMustBeActiveRule;
        }
        public async Task<BusinessRuleResult> ValidateGetByIdAsync(int subscriptionOfferId)
        {
            var validationResult = await _subscriptionOfferMustExistRule.ValidateAsync(subscriptionOfferId);

            return validationResult;
        }
        public async Task<BusinessRuleResult> ValidateDeleteAsync(int subscriptionOfferId)
        {
            var validationResult = await _subscriptionOfferMustExistRule.ValidateAsync(subscriptionOfferId);

            return validationResult;
        }
        public async Task<BusinessRuleResult> ValidateAddAsync(AddSubscriptionOfferDTO addModel)
        {
            var rules = new List<Func<Task<BusinessRuleResult>>>()
            {
                () => _subscriptionTypeMustExistRule.ValidateAsync(addModel.SubscriptionTypeId),
                () => _subscriptionTypeMustBeActiveRule.ValidateAsync(addModel.SubscriptionTypeId),
            };


            return await ValidateRulesAsync(rules);
        }
        
        public async Task<BusinessRuleResult> ValidateUpdateAsync(int subscriptionOfferId, UpdateSubscriptionOfferDTO updateModel)
        {
            var rules = new List<Func<Task<BusinessRuleResult>>>()
            {
                () => _subscriptionOfferMustExistRule.ValidateAsync(subscriptionOfferId),
                () => _subscriptionTypeMustExistRule.ValidateAsync(updateModel.SubscriptionTypeId),
                () => _subscriptionTypeMustBeActiveRule.ValidateAsync(updateModel.SubscriptionTypeId),
            };


            return await ValidateRulesAsync(rules);
        }
    }
}
