

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Member
{
    public interface IMemberMustHasNotActiveSubscriptionRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int memberId);
    }
}
