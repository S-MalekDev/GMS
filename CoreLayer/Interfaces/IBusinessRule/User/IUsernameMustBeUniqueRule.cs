

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.User
{
    public interface IUsernameMustBeUniqueRule : IBusinessRule<string>
    { 
        new Task<BusinessRuleResult> ValidateAsync(string username);
    }
}
