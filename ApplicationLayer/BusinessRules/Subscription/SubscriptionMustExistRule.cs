
using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Subscription;
using CoreLayer.Interfaces.ISubscription;

namespace ApplicationLayer.BusinessRules.Subscription
{
    public class SubscriptionMustExistRule : ISubscriptionMustExistRule
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionMustExistRule(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int subscriptionId)
        {
            if (!await _subscriptionRepository.ExistsAsync(subscriptionId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound, $"No subscription was found with ID [{subscriptionId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
