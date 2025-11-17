

using CoreLayer.IBusinessRules.Parameters;
using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Subscription
{
    public interface ISubscriptionPreventOverlapRule : IBusinessRule<SubNoOverlapRuleParams>
    {
        new Task<BusinessRuleResult> ValidateAsync(SubNoOverlapRuleParams subNoOverLapRuleParams);
    }
}
