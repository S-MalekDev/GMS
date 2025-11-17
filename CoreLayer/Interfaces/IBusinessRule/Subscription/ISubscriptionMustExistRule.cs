

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Subscription
{
    public interface ISubscriptionMustExistRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int subscriptionId);
    }
}
