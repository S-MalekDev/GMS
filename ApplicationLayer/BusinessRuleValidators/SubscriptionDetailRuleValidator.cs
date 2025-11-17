

using ApplicationLayer.BusinessRules;
using ApplicationLayer.BusinessRules.Subscription;
using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionDetailDTOs;
using CoreLayer.IBusinessRules.Parameters;
using CoreLayer.Interfaces.IBusinessRule.Subscription;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionDetail;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionOffer;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionType;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class SubscriptionDetailRuleValidator : BaseBusinessRuleValidator, ISubscriptionDetailRuleValidator
    {
        private readonly ISubscriptionDetailMustExistRule _subscriptionDetailMustExistRule;
        private readonly ISubscriptionMustExistRule _subscriptionMustExistRule;
        private readonly ISubscriptionMustBeActiveOrPendingRule _subscriptionMustBeActiveOrPendingRule;
        private readonly ISubscriptionTypeMustExistRule _subscriptionTypeMustExistRule;
        private readonly ISubscriptionTypeMustBeActiveRule _subscriptionTypeMustBeActiveRule;
        private readonly IOfferMustMatchSubscriptionTypeRule _offerMustMatchSubscriptionTypeRule;
        private readonly ISubscriptionOfferMustExistRule _subscriptionOfferMustExistRule;
        private readonly ISubscriptionOfferMustBeActiveRule _subscriptionOfferMustBeActiveRule;

        public SubscriptionDetailRuleValidator(ISubscriptionDetailMustExistRule subscriptionDetailMustExistRule,
            ISubscriptionMustExistRule subscriptionMustExistRule,
            ISubscriptionMustBeActiveOrPendingRule subscriptionMustBeActiveOrPendingRule,
            ISubscriptionTypeMustExistRule subscriptionTypeMustExistRule,
            ISubscriptionTypeMustBeActiveRule subscriptionTypeMustBeActiveRule,
            IOfferMustMatchSubscriptionTypeRule offerMustMatchSubscriptionTypeRule,
            ISubscriptionOfferMustExistRule subscriptionOfferMustExistRule,
            ISubscriptionOfferMustBeActiveRule subscriptionOfferMustBeActiveRule)
        {
            _subscriptionDetailMustExistRule = subscriptionDetailMustExistRule;
            _subscriptionMustExistRule = subscriptionMustExistRule;
            _subscriptionMustBeActiveOrPendingRule = subscriptionMustBeActiveOrPendingRule;
            _subscriptionTypeMustExistRule = subscriptionTypeMustExistRule;
            _subscriptionTypeMustBeActiveRule = subscriptionTypeMustBeActiveRule;
            _offerMustMatchSubscriptionTypeRule = offerMustMatchSubscriptionTypeRule;
            _subscriptionOfferMustExistRule = subscriptionOfferMustExistRule;
            _subscriptionOfferMustBeActiveRule = subscriptionOfferMustBeActiveRule;
        }
        public async Task<BusinessRuleResult> ValidateAddAsync(AddSubscriptionDetailDTO addModel)
        {
            var rules = new List<Func<Task<BusinessRuleResult>>>()
            {
                () => _subscriptionMustExistRule.ValidateAsync(addModel.SubscriptionID),
                () => _subscriptionMustBeActiveOrPendingRule.ValidateAsync(addModel.SubscriptionID),
                () => _subscriptionTypeMustExistRule.ValidateAsync(addModel.SubscriptionTypeID),
                () => _subscriptionTypeMustBeActiveRule.ValidateAsync(addModel.SubscriptionTypeID),
            };

            if (addModel.SubscriptionOfferID.HasValue)
            {
                var offerId = addModel.SubscriptionOfferID.Value;

                rules.AddRange
                    (
                    new List<Func<Task<BusinessRuleResult>>>
                    {
                        () => _subscriptionOfferMustExistRule.ValidateAsync(offerId),
                        () => _subscriptionOfferMustBeActiveRule.ValidateAsync(offerId),
                        () => _offerMustMatchSubscriptionTypeRule
                         .ValidateAsync(new OfferSubscriptionTypeParams
                         {
                             OfferId = offerId,
                             SubscriptionTypeId = addModel.SubscriptionTypeID
                         }
                         )
                    }
                    );
            }

            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(int subscriptionDetailId)
        {
            var ruleResult = await _subscriptionDetailMustExistRule.ValidateAsync(subscriptionDetailId);

            return ruleResult;
        }
    }
}
