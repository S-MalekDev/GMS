

using CoreLayer.Common;
using CoreLayer.DTOs.PersonDTOs.PhoneNumber;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface IPhoneNumberRuleValidator
    {
        Task<BusinessRuleResult> ValidateAddAsync(AddPhoneNumberDTO model);
        Task<BusinessRuleResult> ValidateUpdateAsync(int phoneNumberId, UpdatePhoneNumberDTO model);
        Task<BusinessRuleResult> ValidateGetByIdAsync(int phoneNumberId);
        Task<BusinessRuleResult> ValidateDeleteAsync(int phoneNumberId);
        Task<BusinessRuleResult> ValidateGetByPersonIdAsync(int personId);
        
    }
}
