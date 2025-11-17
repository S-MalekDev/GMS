

using CoreLayer.BusinessRules.Parameters;
using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.User
{
    public interface IUsernameMustBeUniqueForUpdateRule : IBusinessRule<UsernameMustBeUniqueForUpdateRuleParams>
    {
        new Task<BusinessRuleResult> ValidateAsync(UsernameMustBeUniqueForUpdateRuleParams model);
    }
}
