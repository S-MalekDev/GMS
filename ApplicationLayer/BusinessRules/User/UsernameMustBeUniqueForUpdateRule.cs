

using CoreLayer.BusinessRules.Parameters;
using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IUser;

namespace ApplicationLayer.BusinessRules.User
{
    public class UsernameMustBeUniqueForUpdateRule : IUsernameMustBeUniqueForUpdateRule
    {
        private readonly IUserRepository _userRepository;

        public UsernameMustBeUniqueForUpdateRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<BusinessRuleResult> ValidateAsync(UsernameMustBeUniqueForUpdateRuleParams model)
        {
            var users = await _userRepository.GetAllAsync();

            if( users.Where(u => u.UserID != model.UserId).Any(u => u.Username == model.UserName))
                return BusinessRuleResult.Failure(OperationResultStatus.Conflict,
                    "Username is already taken. Please choose a different one.");

            return BusinessRuleResult.Success();
        }
    }
}
