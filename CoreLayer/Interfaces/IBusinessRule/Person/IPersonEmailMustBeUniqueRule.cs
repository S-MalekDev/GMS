

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Person
{
    public interface IPersonEmailMustBeUniqueRule : IBusinessRule<string?>
    {
        new Task<BusinessRuleResult> ValidateAsync(string? email);
    }
}
