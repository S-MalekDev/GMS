using CoreLayer.Common;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IUser;
using CoreLayer.Enums.OperationResult;

namespace ApplicationLayer.BusinessRules.User
{
    public class UserMustExistByIdRule : IUserMustExistByIdRule
    {
        private readonly IUserRepository _userRepository;
        public UserMustExistByIdRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int userId)
        {
            if (!await _userRepository.ExistsByIdAsync(userId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound, 
                    $"No user was found with ID [{userId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
