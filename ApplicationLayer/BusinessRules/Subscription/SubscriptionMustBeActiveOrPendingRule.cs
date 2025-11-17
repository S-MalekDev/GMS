

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Enums.SubscriptionStatus;
using CoreLayer.Interfaces.IBusinessRule.Subscription;
using CoreLayer.Interfaces.ISubscription;

namespace ApplicationLayer.BusinessRules.Subscription
{
    public class SubscriptionMustBeActiveOrPendingRule : ISubscriptionMustBeActiveOrPendingRule
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionMustBeActiveOrPendingRule(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int subscriptionId)
        {
            var subsriptionStatus = await _subscriptionRepository.GetStatusAsync(subscriptionId);

            if (subsriptionStatus != SubscriptionStatus.Pending && subsriptionStatus != SubscriptionStatus.Active)
                return BusinessRuleResult.Failure(OperationResultStatus.Conflict, 
                    $"This action is only allowed for subscriptions that are in a pending or an active state .");

            else return BusinessRuleResult.Success();
        }
    }
}
