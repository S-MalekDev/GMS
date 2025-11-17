

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IUser;

namespace ApplicationLayer.BusinessRules.User
{
    public class UserMustExistByUsernameRule : IUserMustExistByUsernameRule
    {
        private readonly IUserRepository _userRepository;
        public UserMustExistByUsernameRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(string username)
        {
            if (!await _userRepository.ExistsByUsernameAsync(username))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"No user was found with username: [{username}]. Please verify the username and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
