

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IUser;

namespace ApplicationLayer.BusinessRules.User
{
    public class UsernameMustBeUniqueRule : IUsernameMustBeUniqueRule
    {
        private readonly IUserRepository _userRepository;

        public UsernameMustBeUniqueRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(string username)
        {
            if (await _userRepository.IsUsernameTakenAsync(username))
                return BusinessRuleResult.Failure(OperationResultStatus.Conflict,
                    "Username is already taken. Please choose a different one.");

            return BusinessRuleResult.Success();
        }
    }
}
