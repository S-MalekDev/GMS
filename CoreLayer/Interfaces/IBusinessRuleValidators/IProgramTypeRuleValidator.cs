

using CoreLayer.Common;
using CoreLayer.DTOs.ProgramTypeDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface IProgramTypeRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(short programTypeId);
        Task<BusinessRuleResult> ValidateDeleteAsync(short programTypeId);
        Task<BusinessRuleResult> ValidateUpdateAsync(short programTypeId, UpdateProgramTypeDTO programTypeToUpdate);
    }
}
