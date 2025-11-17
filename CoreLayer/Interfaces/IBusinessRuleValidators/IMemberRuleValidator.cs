

using CoreLayer.Common;
using CoreLayer.DTOs.MemberDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface IMemberRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(int memberId);
        Task<BusinessRuleResult> ValidateDeleteAsync(int memberId);
        Task<BusinessRuleResult> ValidateRestoreAsync(int personId);
        Task<BusinessRuleResult> ValidateAddAsync(AddMemberDTO model);
        Task<BusinessRuleResult> ValidateUpdateAsync(int memberId, UpdateMemberDTO memberToUpdate);
    }
}
