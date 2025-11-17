

using CoreLayer.Common;
using CoreLayer.DTOs.TrainerDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface ITrainerRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(int trainerId);
        Task<BusinessRuleResult> ValidateAddAsync(AddTrainerDTO model);
        Task<BusinessRuleResult> ValidateUpdateAsync(int trainerId, UpdateTrainerDTO model);
        Task<BusinessRuleResult> ValidateDeleteAsync(int trainerId);
        Task<BusinessRuleResult> ValidateRestoreAsync(int employeeId);

    }
}
