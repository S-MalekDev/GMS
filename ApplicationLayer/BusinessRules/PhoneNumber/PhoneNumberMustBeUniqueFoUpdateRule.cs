
using CoreLayer.BusinessRules.Parameters;
using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.PhoneNumber;
using CoreLayer.Interfaces.IPerson.Phone;

namespace ApplicationLayer.BusinessRules.PhoneNumber
{
    public class PhoneNumberMustBeUniqueFoUpdateRule : IPhoneNumberMustBeUniqueFoUpdateRule
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        public PhoneNumberMustBeUniqueFoUpdateRule(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(PhoneNumberMustBeUniqueFoUpdateRuleParams model)
        {
            var phoneNumbers = await _phoneNumberRepository.GetAllAsync();

            if(phoneNumbers.Where(p => p.PhoneNumberID != model.PhoneNumberId).Any(p => p.Number == model.PhoneNumber))
                return BusinessRuleResult.Failure(OperationResultStatus.Conflict,
                    "The phone number is already in use.");


            return BusinessRuleResult.Success();
        }

    }
}
