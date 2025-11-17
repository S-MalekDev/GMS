using CoreLayer.Common;
using CoreLayer.Entities;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Member;
using CoreLayer.Interfaces.IMember;

namespace ApplicationLayer.BusinessRules.Member
{
    public class MemberMustExistRule : IMemberMustExistRule
    {
        private readonly IMemberRepository _memberRepository;

        public MemberMustExistRule(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<BusinessRuleResult> ValidateAsync(int memberId)
        {
            if (!await _memberRepository.ExistsByIdAsync(memberId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"No member was found with ID [{memberId}]. Please verify the ID and try again.");

            else return BusinessRuleResult.Success();
        }

    }
}
