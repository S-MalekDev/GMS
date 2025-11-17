using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionOffer;
using CoreLayer.Interfaces.ISubscriptionOffer;


namespace ApplicationLayer.BusinessRules.SubsciptionOffer
{
    public class SubscriptionOfferMustBeActiveRule : ISubscriptionOfferMustBeActiveRule
    {
        private readonly ISubscriptionOfferRepository _subscriptionOfferRepository;
        public SubscriptionOfferMustBeActiveRule(ISubscriptionOfferRepository subscriptionOfferRepository)
        {
            _subscriptionOfferRepository = subscriptionOfferRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int subscriptionOfferId)
        {
            if (!await _subscriptionOfferRepository.IsActiveAsync(subscriptionOfferId))
                return BusinessRuleResult.Failure(OperationResultStatus.UnprocessableEntity, "The selected subscription offer is not active and cannot be used for registration.");


            return BusinessRuleResult.Success();
        }
    }
}
