using CoreLayer.Common;


namespace CoreLayer.Interfaces.IBusinessRule.PhoneNumber
{
    public interface IPhoneNumberMustExistRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int phoneNumberId);
    }
}
