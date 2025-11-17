

using CoreLayer.Common;
using CoreLayer.Interfaces.IBusinessRule.PhoneNumber;
using CoreLayer.Interfaces.IPerson.Phone;
using CoreLayer.Enums.OperationResult;

namespace ApplicationLayer.BusinessRules.PhoneNumber
{
    public class PhoneNumberMustBeUniqueRule : IPhoneNumberMustBeUniqueRule
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;

        public PhoneNumberMustBeUniqueRule(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(string phoneNumber)
        {
            if (await _phoneNumberRepository.ExistsByPhoneNumberAsync(phoneNumber))
                return BusinessRuleResult.Failure(OperationResultStatus.Conflict,
                    "The phone number is already in use.");

            return BusinessRuleResult.Success();
        }
    }
}
