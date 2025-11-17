using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionOffer;
using CoreLayer.Interfaces.ISubscriptionOffer;


namespace ApplicationLayer.BusinessRules.SubsciptionOffer
{
    public class SubscriptionOfferMustExistRule : ISubscriptionOfferMustExistRule
    {
        private readonly ISubscriptionOfferRepository _subscriptionOfferRepository;
        public SubscriptionOfferMustExistRule(ISubscriptionOfferRepository subscriptionOfferRepository)
        {
            _subscriptionOfferRepository = subscriptionOfferRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int subscriptionOfferId)
        {
            if (!await _subscriptionOfferRepository.ExistsAsync(subscriptionOfferId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound, $"No subscription offer was found with ID [{subscriptionOfferId}]. Please verify the ID and try again.");


            return BusinessRuleResult.Success();
        }
    }
}
