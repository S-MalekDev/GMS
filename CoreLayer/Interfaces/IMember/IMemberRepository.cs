using CoreLayer.Entities;


namespace CoreLayer.Interfaces.IMember
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int memberId);
        Task<int> AddAsync(Member memberToAdd);
        Task<bool> UpdateAsync(Member memberToUpdate);
        Task<bool> DeleteAsync(int memberId);
        Task<bool> RestoreAsync(int personId);
        Task<bool> ExistsByIdAsync(int memberId);
        Task<bool> ExistsByPersonIdAsync(int personId);
        Task<bool> PersonHasDeletedMemberAsync(int personId);
        Task<bool> PersonBeOrHaveBeMemberAsync(int personId);
        Task<bool> IsActiveAsync(int memberId);
    }
}
