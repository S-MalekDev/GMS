

using CoreLayer.BusinessRules.Parameters;
using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Person
{
    public interface IPersonEmailMustBeUniqueForUpdateRule : IBusinessRule<PersonEmailMustBeUniqueForUpdateRuleParams>
    {
        new Task<BusinessRuleResult> ValidateAsync(PersonEmailMustBeUniqueForUpdateRuleParams model);
    }
}
