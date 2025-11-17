

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.User
{
    public interface IUserMustExistByIdRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int userId);
    }
}
