

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.PhoneNumber
{
    public interface IPhoneNumberMustBeUniqueRule : IBusinessRule<string>
    {
        new Task<BusinessRuleResult> ValidateAsync(string phoneNumber);
    }
}
