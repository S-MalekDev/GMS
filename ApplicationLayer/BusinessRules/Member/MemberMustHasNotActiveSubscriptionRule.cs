
using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Member;
using CoreLayer.Interfaces.ISubscription;

namespace ApplicationLayer.BusinessRules.Member
{
    public class MemberMustHasNotActiveSubscriptionRule : IMemberMustHasNotActiveSubscriptionRule
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public MemberMustHasNotActiveSubscriptionRule(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int memberId)
        {
            if (await _subscriptionRepository.IsHasActiveSubscriptionByMemberIdAsync(memberId))
                return BusinessRuleResult.
                    Failure(OperationResultStatus.Conflict,
                    $"The member with Id {memberId} already has an active subscription. Please cancel or wait for it to expire before creating a new one.");

            else return BusinessRuleResult.Success();
        }
    }
}
