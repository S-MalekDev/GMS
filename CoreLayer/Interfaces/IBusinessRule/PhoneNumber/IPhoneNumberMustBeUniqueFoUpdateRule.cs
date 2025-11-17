

using CoreLayer.BusinessRules.Parameters;
using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.PhoneNumber
{
    public interface IPhoneNumberMustBeUniqueFoUpdateRule : IBusinessRule<PhoneNumberMustBeUniqueFoUpdateRuleParams>
    {
        new Task<BusinessRuleResult> ValidateAsync(PhoneNumberMustBeUniqueFoUpdateRuleParams model);
    }
}
