

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IUser;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonMustNotHaveUserRule : IPersonMustNotHaveUserRule
    {
        private readonly IUserRepository _userRepository;

        public PersonMustNotHaveUserRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int personId)
        {
            if (await _userRepository.ExistsByPersonIdAsync(personId))
            {
                return BusinessRuleResult.Failure(
                    OperationResultStatus.Conflict,
                    "This person is already linked to an existed user account."
                );
            }

            if (await _userRepository.PersonHasDeletedUserAccount(personId))
            {
                return BusinessRuleResult.Failure(
                    OperationResultStatus.Conflict,
                    "This person is already linked to a deleted user account. Use the restore functionality to reactivate the account."
                );
            }

            return BusinessRuleResult.Success();
        }
    }
}
