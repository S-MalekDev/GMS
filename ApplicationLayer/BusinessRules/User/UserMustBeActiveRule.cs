

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IUser;

namespace ApplicationLayer.BusinessRules.User
{
    public class UserMustBeActiveRule : IUserMustBeActiveRule
    {
        private readonly IUserRepository _userRepository;
        public UserMustBeActiveRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int userId)
        {
            if (!await _userRepository.IsActiveAsync(userId))
                return BusinessRuleResult.Failure(OperationResultStatus.UnprocessableEntity,
                    $"The user account (ID: {userId}) is currently inactive.");

            return BusinessRuleResult.Success();
        }
    }
}
