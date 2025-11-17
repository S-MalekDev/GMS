using ApplicationLayer.BusinessRules;
using CoreLayer.Common;
using CoreLayer.DTOs.MemberDTOs;
using CoreLayer.Interfaces.IBusinessRule.Member;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IBusinessRule.Trainer;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class MemberRuleValidator : BaseBusinessRuleValidator, IMemberRuleValidator
    {
        private readonly IMemberMustExistRule _memberMustExistRule;
        private readonly IPersonMustExistRule _personMustExistRule;
        private readonly IPersonMustNotBeMemberRule _personMustNotBeMemberRule;
        private readonly ITrainerMustExistRule _trainerMustExistRule;
        private readonly ITrainerMustBeActiveRule _trainerMustBeActiveRule;
        private readonly IUserMustExistByIdRule _userMustExistByIdRule;
        private readonly IUserMustBeActiveRule _userMustBeActiveRule;
        private readonly IPersonMustBeOrHaveBeMemberRule _personMustBeOrHaveBeMember;


        public MemberRuleValidator(IMemberMustExistRule memberMustExistRule,
            IPersonMustExistRule personMustExistRule,
            IPersonMustNotBeMemberRule personMustNotBeMemberRule,
            ITrainerMustExistRule trainerMustExistRule,
            ITrainerMustBeActiveRule trainerMustBeActiveRule,
            IUserMustExistByIdRule userMustExistByIdRule,
            IUserMustBeActiveRule userMustBeActiveRule,
            IPersonMustBeOrHaveBeMemberRule personMustBeOrHaveBeMember)
        {
            _memberMustExistRule = memberMustExistRule;
            _personMustExistRule = personMustExistRule;
            _personMustNotBeMemberRule = personMustNotBeMemberRule;
            _trainerMustExistRule = trainerMustExistRule;
            _trainerMustBeActiveRule = trainerMustBeActiveRule;
            _userMustExistByIdRule = userMustExistByIdRule;
            _userMustBeActiveRule = userMustBeActiveRule;
            _personMustBeOrHaveBeMember = personMustBeOrHaveBeMember;
        }

        public async Task<BusinessRuleResult> ValidateAddAsync(AddMemberDTO model)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _personMustExistRule.ValidateAsync(model.PersonId),
                () => _personMustNotBeMemberRule.ValidateAsync(model.PersonId),
                () => _userMustExistByIdRule.ValidateAsync(model.CreatedByUserId),
                () => _userMustBeActiveRule.ValidateAsync(model.CreatedByUserId),
            };

            if(model.PersonalTrainerId.HasValue)
            {
                rules.AddRange
                    (
                        new List<Func<Task<BusinessRuleResult>>>
                        {
                            () => _trainerMustExistRule.ValidateAsync(model.PersonalTrainerId.Value),
                            () => _trainerMustBeActiveRule.ValidateAsync(model.PersonalTrainerId.Value),
                        }
                    );
            }

            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateDeleteAsync(int memberId)
        {
            var ruleResult = await _memberMustExistRule.ValidateAsync(memberId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(int memberId)
        {
            var ruleResult = await _memberMustExistRule.ValidateAsync(memberId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateRestoreAsync(int personId)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _personMustExistRule.ValidateAsync(personId),
                () => _personMustBeOrHaveBeMember.ValidateAsync(personId)
            };


            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateUpdateAsync(int memberId, UpdateMemberDTO model)
        {
            
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _memberMustExistRule.ValidateAsync(memberId),
            };

            if (model.PersonalTrainerId.HasValue)
            {
                rules.AddRange
                    (
                        new List<Func<Task<BusinessRuleResult>>>
                        {
                            () => _trainerMustExistRule.ValidateAsync(model.PersonalTrainerId.Value),
                            () => _trainerMustBeActiveRule.ValidateAsync(model.PersonalTrainerId.Value),
                        }
                    );
            }

            return await ValidateRulesAsync(rules);
        }
    }
}
