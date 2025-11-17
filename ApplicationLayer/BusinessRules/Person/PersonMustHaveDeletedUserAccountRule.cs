
using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IUser;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonMustHaveDeletedUserAccountRule : IPersonMustHaveDeletedUserAccountRule
    {
        private readonly IUserRepository _userRepository;
        public PersonMustHaveDeletedUserAccountRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int personId)
        {
            if (! await _userRepository.PersonHasDeletedUserAccount(personId))

                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"No deleted user account found for the specified person. Please ensure that the person had a deleted user account before attempting to restore it.");

            return BusinessRuleResult.Success();
        }
    }
}
