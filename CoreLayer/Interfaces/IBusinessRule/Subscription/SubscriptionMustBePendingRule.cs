
using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Subscription
{
    public interface ISubscriptionMustBePendingRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int subscriptionId);
    }
}
