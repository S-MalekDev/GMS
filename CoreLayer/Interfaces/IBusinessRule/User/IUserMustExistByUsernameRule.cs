

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.User
{
    public interface IUserMustExistByUsernameRule : IBusinessRule<string>
    {
        new Task<BusinessRuleResult> ValidateAsync(string username);
    }
}
