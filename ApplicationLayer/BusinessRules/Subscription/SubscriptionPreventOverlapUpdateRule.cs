using CoreLayer.IBusinessRules.Parameters;
using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.IBusinessRule.Subscription;
using CoreLayer.Interfaces.ISubscription;

namespace ApplicationLayer.BusinessRules.Subscription
{
    public class SubscriptionPreventOverlapUpdateRule : ISubscriptionPreventOverlapUpdateRule
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionPreventOverlapUpdateRule(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(SubNoOverlapUpdateRuleParams subNoOverlapUpdateRuleParams)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(subNoOverlapUpdateRuleParams.SubscriptionId);
            if (subscription == null) throw new KeyNotFoundException($"The subscription with Id {subNoOverlapUpdateRuleParams.SubscriptionId} no longer exists.");

            // Get all member's active and pending subscriptions.
            var memberPendingSubscriptions = (await _subscriptionRepository.GetPendingSubscriptionByMemberIdAsync(subscription.MemberId))
                .Where(s => s.SubscriptionId != subNoOverlapUpdateRuleParams.SubscriptionId);

            var memberActiveSubscription = await _subscriptionRepository.GetActiveSubscriptionByMemberIdAsync(subscription.MemberId);

            // Get subscription type information to infer the current subscription end date.
            var subscriptionType = subscription.subscriptionDetails.First().SubscriptionType;

            // Calculate end date.
            var startDate = subNoOverlapUpdateRuleParams.StartDate;
            var endDate = subscriptionType.CalculateEndDate(startDate);

            // Collect subscriptions pariods we need to check throw them.
            List<(DateOnly StartDate, DateOnly EndDate)> subscriptionPeriods = new();

            if (memberPendingSubscriptions.Any())
            {
                foreach (var sub in memberPendingSubscriptions)
                {
                    subscriptionPeriods.Add((sub.StartDate, sub.EndDate));
                }
            }

            if (memberActiveSubscription is not null) subscriptionPeriods.Add((memberActiveSubscription.StartDate, memberActiveSubscription.EndDate));

            // Check that the durations do not conflict.
            if (subscriptionPeriods.Any(s => startDate <= s.EndDate && endDate >= s.StartDate))
            {
                return BusinessRuleResult.Failure(OperationResultStatus.Conflict,
                    "The subscription cannot be saved because it overlaps with an active or pending subscription.");

            }

            return BusinessRuleResult.Success();
        }
    }
}
