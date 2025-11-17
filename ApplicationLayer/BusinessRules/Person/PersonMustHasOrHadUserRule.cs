

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IUser;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonMustHasOrHadUserRule : IPersonMustHasOrHadUserRule
    {
        private readonly IUserRepository _userRepository;
        public PersonMustHasOrHadUserRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int personId)
        {
            if (!await _userRepository.PersonHasOrHadUserAsync(personId))

                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"The person with ID [{personId}] has never been associated with a user account.");

            return BusinessRuleResult.Success();
        }
    }
}
