

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.SubscriptionDetail
{
    public interface ISubscriptionDetailMustExistRule : IBusinessRule<int>
    {
       new  Task<BusinessRuleResult> ValidateAsync(int subscriptionDetailId);
    }
}
