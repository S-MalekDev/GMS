

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Member
{
    public interface IMemberMustBeActiveRule : IBusinessRule<int>
    {
       new Task<BusinessRuleResult> ValidateAsync(int memberId);
    }
}
