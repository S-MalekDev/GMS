

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.PhoneNumber;
using CoreLayer.Interfaces.IPerson.Phone;

namespace ApplicationLayer.BusinessRules.PhoneNumber
{
    public class PhoneNumberMustExistRule : IPhoneNumberMustExistRule
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;

        public PhoneNumberMustExistRule(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int phoneNumberId)
        {
            if(! await _phoneNumberRepository.ExistsByIdAsync(phoneNumberId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"No phone number was found with ID [{phoneNumberId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
