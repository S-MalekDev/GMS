using CoreLayer.Common;
using CoreLayer.DTOs.MemberDTOs;


namespace CoreLayer.Interfaces.IMember
{
    public interface IMemberService
    {
        Task<OperationResult<IEnumerable<MemberListDTO>>> GetAllAsync();
        Task<OperationResult<MemberDTO>> GetByIdAsync(int memberId);
        Task<OperationResult<int>> AddAsync(AddMemberDTO memberToAdd);
        Task<OperationResult<bool>> UpdateAsync(int employeeId, UpdateMemberDTO memberToUpdate);
        Task<OperationResult<bool>> DeleteAsync(int memberId);
        Task<OperationResult<bool>> RestoreAsync(int personId);
        Task<OperationResult<bool>> ExistsAsync(int memberId);
    }
}
