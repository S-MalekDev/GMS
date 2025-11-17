using CoreLayer.IBusinessRules.Parameters;
using CoreLayer.Common;


namespace CoreLayer.Interfaces.IBusinessRule.Subscription
{
    public interface ISubscriptionPreventOverlapUpdateRule : IBusinessRule<SubNoOverlapUpdateRuleParams>
    {
        new Task<BusinessRuleResult> ValidateAsync(SubNoOverlapUpdateRuleParams subNoOverlapUpdateRuleParams);
    }
}
