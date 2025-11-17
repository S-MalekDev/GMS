

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.SubscriptionType
{
    public interface ISubscriptionTypeMustExistRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int subscriptionTypeId);
    }
}
