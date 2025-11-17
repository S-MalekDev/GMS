

using CoreLayer.Common;
using CoreLayer.DTOs.UserDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface IUserRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(int userId);
        Task<BusinessRuleResult> ValidateDeleteAsync(int userId);
        Task<BusinessRuleResult> ValidateRestoreAsync(int userId);
        Task<BusinessRuleResult> ValidateUpdateUserPasswordAsync(int userId);
        Task<BusinessRuleResult> ValidateChangeUserActivationAsync(int userId);
        Task<BusinessRuleResult> ValidateHasActiveUserAsync(int personId);
        Task<BusinessRuleResult> ValidatePersonHasOrHadUserAsync(int personId);
        Task<BusinessRuleResult> ValidateGetByUsernameAsync(string username);
        Task<BusinessRuleResult> ValidateAddAsync(AddUserDTO model);
        Task<BusinessRuleResult> ValidateUpdateAsync(int userId, UpdateUserDTO model);
    }
}
