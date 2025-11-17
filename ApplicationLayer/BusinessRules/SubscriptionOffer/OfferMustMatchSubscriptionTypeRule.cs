
using CoreLayer.IBusinessRules.Parameters;
using CoreLayer.Common;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionOffer;
using CoreLayer.Interfaces.ISubscriptionOffer;
using CoreLayer.Enums.OperationResult;

namespace ApplicationLayer.BusinessRules.SubsciptionOffer
{
    public class OfferMustMatchSubscriptionTypeRule : IOfferMustMatchSubscriptionTypeRule
    {
        private readonly ISubscriptionOfferRepository _subscriptionOfferRepository;
        public OfferMustMatchSubscriptionTypeRule(ISubscriptionOfferRepository subscriptionOfferRepository)
        {
            _subscriptionOfferRepository = subscriptionOfferRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(OfferSubscriptionTypeParams param)
        {
            if (! await _subscriptionOfferRepository.IsOfferForSubscriptionTypeAsync(param.OfferId, param.SubscriptionTypeId))
                return BusinessRuleResult.Failure(OperationResultStatus.UnprocessableEntity, "The selected offer is not valid for the specified subscription type.");


            return BusinessRuleResult.Success();
        }
    }
}
