

using CoreLayer.Common;
using CoreLayer.DTOs.TrainerSpecialityDTO;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface IJobSpecialityRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(short specialityId);
        Task<BusinessRuleResult> ValidateUpdateAsync(short specialityId, UpdateSpecialityDTO model);
        Task<BusinessRuleResult> ValidateDeleteAsync(short specialityId);
    }
}
