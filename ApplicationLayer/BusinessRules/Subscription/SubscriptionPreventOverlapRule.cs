
using CoreLayer.IBusinessRules.Parameters;
using CoreLayer.Common;
using CoreLayer.Entities;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.IBusinessRule.Subscription;
using CoreLayer.Interfaces.ISubscription;
using CoreLayer.Interfaces.ISubscriptionType;

namespace ApplicationLayer.BusinessRules.Subscription
{
    public class SubscriptionPreventOverlapRule : ISubscriptionPreventOverlapRule
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;

        public SubscriptionPreventOverlapRule(ISubscriptionRepository subscriptionRepository, ISubscriptionTypeRepository subscriptionTypeRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _subscriptionTypeRepository = subscriptionTypeRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(SubNoOverlapRuleParams subNoOverlapRuleParams)
        {
            // Get all member's active and pending subscriptions.
            var memberPendingSubscriptions = await _subscriptionRepository.GetPendingSubscriptionByMemberIdAsync(subNoOverlapRuleParams.memberId);
            var memberActiveSubscription = await _subscriptionRepository.GetActiveSubscriptionByMemberIdAsync(subNoOverlapRuleParams.memberId);

            // Get subscription type information to infer the current subscription end date.
            var subscriptionType = await _subscriptionTypeRepository.GetByIdAsync(subNoOverlapRuleParams.SubscriptionTypeId);
            if(subscriptionType is null) 
                throw new KeyNotFoundException($"The subscription with Id {subNoOverlapRuleParams.SubscriptionTypeId} no longer exists.");

            // Calculate end date.
            var startDate = subNoOverlapRuleParams.StartDate;
            var endDate = subscriptionType.CalculateEndDate(startDate);

            // Collect subscriptions pariods we need to check throw them.
            List<(DateOnly StartDate, DateOnly EndDate)> subscriptionPeriods = new();

            if(memberPendingSubscriptions.Any())
            {
                foreach (var subscription in memberPendingSubscriptions)
                {
                    subscriptionPeriods.Add((subscription.StartDate, subscription.EndDate));
                }
            }

            if (memberActiveSubscription is not null) subscriptionPeriods.Add((memberActiveSubscription.StartDate, memberActiveSubscription.EndDate));

            // Check that the durations do not conflict.
            if(subscriptionPeriods.Any(s => startDate <= s.EndDate && endDate >= s.StartDate))
            {
               return BusinessRuleResult.Failure(OperationResultStatus.Conflict,
                   "The subscription cannot be saved because it overlaps with an active or pending subscription.");
                
            }

            return BusinessRuleResult.Success();
        }
    }
}
