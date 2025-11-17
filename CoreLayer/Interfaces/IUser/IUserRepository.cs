using CoreLayer.DTOs.UserDTOs;
using CoreLayer.Entities;

namespace CoreLayer.Interfaces.IUser
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>>GetAllAsync();
        Task<User?> GetByIdAsync(int userId);
        Task<User?> GetByUsernameAsync(string username);
        Task<int> AddAsync(User userToAdd);
        Task<bool> UpdateAsync(int userId, string username, int parmissions, bool isActive);
        Task<bool> DeleteAsync(int userId);
        Task<bool> RestoreAsync(int personId);
        Task<bool> ExistsByIdAsync(int userId);
        Task<bool> ExistsByPersonIdAsync(int personId);
        Task<bool> ExistsByUsernameAsync(string username);
        Task<bool> IsActiveAsync(int userId);
        Task<bool> HasActiveUserAsync(int personId);
        Task<bool> PersonHasOrHadUserAsync(int personId);
        Task<bool> PersonHasDeletedUserAccount(int personId);
        Task<string> GetUserPasswordHashByUsernameAsync(string username);
        Task<bool> ChangeUserActivationAsync(int userId, bool isActive);
        Task<bool> UpdateUserPasswordAsync(int userId, string newPasswordHash);
        Task<bool> IsUsernameTakenAsync(string username);
    }
}

