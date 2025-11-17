using AutoMapper;
using CoreLayer.Common;
using CoreLayer.DTOs.UserDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.Helpers;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.IUser;
using System.Collections.Generic;


namespace ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRuleValidator _userRuleValidator;


        public UserService(IUserRepository userRepository, IMapper mapper, 
            ILoggerManager loggerManager, IPasswordHasher passwordHasher,
            IUserRuleValidator userRuleValidator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _passwordHasher = passwordHasher;
            _userRuleValidator = userRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<UserListDTO>>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return OperationResult<IEnumerable<UserListDTO>>.Success(data: _mapper.Map<List<UserListDTO>>(users));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<UserDTO>> GetByIdAsync(int userId)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidateGetByIdAsync(userId);
                if (! validationResult.IsSuccess) return OperationResult<UserDTO>.MapFrom(validationResult);

                var user = await _userRepository.GetByIdAsync(userId);
                return OperationResult<UserDTO>.Success(data: _mapper.Map<UserDTO>(user));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<UserDTO>> GetByUsernameAsync(string username)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidateGetByUsernameAsync(username);
                if (!validationResult.IsSuccess) return OperationResult<UserDTO>.MapFrom(validationResult);

                var user = await _userRepository.GetByUsernameAsync(username);
                return OperationResult<UserDTO>.Success(data: _mapper.Map<UserDTO>(user));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<int>> AddAsync(AddUserDTO userToAdd)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidateAddAsync(userToAdd);
                if (!validationResult.IsSuccess) return OperationResult<int>.MapFrom(validationResult);

                var user = _mapper.Map<User>(userToAdd);

                user.PasswordHash = _passwordHasher.Hash(userToAdd.Password);
                user.CreatedAt = DateTime.Now;
                user.IsDeleted = false;

                return OperationResult<int>.Success(data: await _userRepository.AddAsync(user));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> UpdateAsync(int userId, UpdateUserDTO userToUpdate)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidateUpdateAsync(userId, userToUpdate);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var isUpdated =  await _userRepository
                    .UpdateAsync(userId, userToUpdate.Username, userToUpdate.Parmissions, userToUpdate.IsActive);

                return OperationResult<bool>.Success(data: isUpdated);
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> DeleteAsync(int userId)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidateDeleteAsync(userId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _userRepository.DeleteAsync(userId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> RestoreAsync(int personId)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidateRestoreAsync(personId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _userRepository.RestoreAsync(personId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(RestoreAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> ExistsAsync(int userId)
        {
            try
            {
                return OperationResult<bool>.Success(data: await _userRepository.ExistsByIdAsync(userId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(ExistsAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> HasActiveUserAsync(int personId)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidateHasActiveUserAsync(personId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _userRepository.HasActiveUserAsync(personId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(HasActiveUserAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> PersonHasOrHadUserAsync(int personId)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidatePersonHasOrHadUserAsync(personId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _userRepository.PersonHasOrHadUserAsync(personId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(PersonHasOrHadUserAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> IsUserCredentialsValidAsync(UserCredentialsDTO credentials)
        {   
            try
            {
                var oldPasswordHash = await _userRepository.GetUserPasswordHashByUsernameAsync(credentials.Username);
                return OperationResult<bool>.Success(data: _passwordHasher.Verify(credentials.Password, oldPasswordHash));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(IsUserCredentialsValidAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> ChangeUserActivationAsync(int userId, bool isActive)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidateChangeUserActivationAsync(userId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _userRepository.ChangeUserActivationAsync(userId, isActive));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(ChangeUserActivationAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> UpdateUserPasswordAsync(int userId, UpdatePasswordDTO dto)
        {
            try
            {
                var validationResult = await _userRuleValidator.ValidateUpdateUserPasswordAsync(userId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var newPasswordHash = _passwordHasher.Hash(dto.NewPassword);
                return OperationResult<bool>.Success(data: await _userRepository.UpdateUserPasswordAsync(userId, newPasswordHash));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateUserPasswordAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> IsUsernameTakenAsync(string username)
        {
            try
            {
                return OperationResult<bool>.Success(data: await _userRepository.IsUsernameTakenAsync(username));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(IsUsernameTakenAsync)}", ex);
                throw;
            }
        }

        
    }
}

