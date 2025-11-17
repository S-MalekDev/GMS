

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IMember;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonMustNotBeMemberRule : IPersonMustNotBeMemberRule
    {
        private readonly IMemberRepository _memberRepository;
        public PersonMustNotBeMemberRule(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int personId)
        {
            if (await _memberRepository.ExistsByPersonIdAsync(personId))
            {
                return BusinessRuleResult.Failure(
                    OperationResultStatus.Conflict,
                    "This person is already linked to an existed member."
                );
            }

            if (await _memberRepository.PersonHasDeletedMemberAsync(personId))
            {
                return BusinessRuleResult.Failure(
                    OperationResultStatus.Conflict,
                    "This person is already linked to a deleted member. Use the restore functionality to reactivate the account."
                );
            }

            return BusinessRuleResult.Success();
        }
    }
}
