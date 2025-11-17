using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Member;
using CoreLayer.Interfaces.IMember;


namespace ApplicationLayer.BusinessRules.Member
{
    public class MemberMustBeActiveRule : IMemberMustBeActiveRule
    {
        private readonly IMemberRepository _memberRepository;
        public MemberMustBeActiveRule(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }


        public async Task<BusinessRuleResult> ValidateAsync(int memberId)
        {
            if (!await _memberRepository.IsActiveAsync(memberId))
                return BusinessRuleResult.Failure(OperationResultStatus.UnprocessableEntity,
                    $"The member account (ID: {memberId}) is currently inactive.");

            return BusinessRuleResult.Success();
        }
    }
}
