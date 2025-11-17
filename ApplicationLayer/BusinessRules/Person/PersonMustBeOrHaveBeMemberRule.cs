
using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IMember;

namespace ApplicationLayer.BusinessRules.Person
{
    public class PersonMustBeOrHaveBeMemberRule : IPersonMustBeOrHaveBeMemberRule
    {
        private readonly IMemberRepository _memberRepository;
        public PersonMustBeOrHaveBeMemberRule(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int personId)
        {
            if (! await _memberRepository.PersonBeOrHaveBeMemberAsync(personId))
            {
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"The person with ID [{personId}] has never been a member.");

            }

            return BusinessRuleResult.Success();
        }
    }
}
