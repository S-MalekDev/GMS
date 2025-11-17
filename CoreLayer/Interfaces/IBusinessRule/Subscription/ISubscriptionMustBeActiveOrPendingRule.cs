

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Subscription
{
    public interface ISubscriptionMustBeActiveOrPendingRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int subscriptionId);
    }
}
