

using CoreLayer.Common;
using CoreLayer.DTOs.PersonDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface IPersonRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(int personId);
        Task<BusinessRuleResult> ValidateAddAsync(CreatePersonDTO model);
        Task<BusinessRuleResult> ValidateUpdateAsync(int personId, UpdatePersonDTO model);
        Task<BusinessRuleResult> ValidateDeleteAsync(int personId);
        Task<BusinessRuleResult> ValidateGetImageNameByIdAsync(int personId);
    }
}
