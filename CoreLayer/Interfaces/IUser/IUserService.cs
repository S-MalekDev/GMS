using CoreLayer.Common;
using CoreLayer.DTOs.UserDTOs;
using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.IUser
{
    public interface IUserService
    {
        Task<OperationResult<IEnumerable<UserListDTO>>> GetAllAsync();
        Task<OperationResult<UserDTO>> GetByIdAsync(int userId);
        Task<OperationResult<UserDTO>> GetByUsernameAsync(string username);
        Task<OperationResult<int>> AddAsync(AddUserDTO userToAdd);
        Task<OperationResult<bool>> UpdateAsync(int userId, UpdateUserDTO userToUpdate);
        Task<OperationResult<bool>> DeleteAsync(int userId);
        Task<OperationResult<bool>> RestoreAsync(int personId);
        Task<OperationResult<bool>> ExistsAsync(int UserId);
        Task<OperationResult<bool>> HasActiveUserAsync(int personId);
        Task<OperationResult<bool>> PersonHasOrHadUserAsync(int personId);
        Task<OperationResult<bool>> IsUserCredentialsValidAsync(UserCredentialsDTO credentials);
        Task<OperationResult<bool>> ChangeUserActivationAsync(int userId,bool IsActive);
        Task<OperationResult<bool>> UpdateUserPasswordAsync(int userId, UpdatePasswordDTO dto);
        Task<OperationResult<bool>> IsUsernameTakenAsync(string username);
    }
}
