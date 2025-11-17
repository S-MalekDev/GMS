

using ApplicationLayer.BusinessRules;
using ApplicationLayer.BusinessRules.Person;
using CoreLayer.BusinessRules.Parameters;
using CoreLayer.Common;
using CoreLayer.DTOs.UserDTOs;
using CoreLayer.Interfaces.IBusinessRule.Person;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class UserRuleValidator : BaseBusinessRuleValidator, IUserRuleValidator
    {
        private readonly IUserMustBeActiveRule _userMustBeActiveRule;
        private readonly IUserMustExistByIdRule _userMustExistByIdRule;
        private readonly IUserMustExistByUsernameRule _userMustExistByUsernameRule;
        private readonly IUsernameMustBeUniqueForUpdateRule _usernameMustBeUniqueForUpdateRule;
        private readonly IPersonMustExistRule _personMustExistRule;
        private readonly IUsernameMustBeUniqueRule _usernameMustBeUniqueRule;
        private readonly IPersonMustNotHaveUserRule _personMustNotHaveUserRule;
        private readonly IPersonMustHaveDeletedUserAccountRule _personMustHaveDeletedUserAccountRule;
        private readonly IPersonMustHasOrHadUserRule _personMustHasOrHadUserRule;



        public UserRuleValidator(IUserMustBeActiveRule userMustBeActiveRule,
            IUserMustExistByIdRule userMustExistByIdRule,
            IUserMustExistByUsernameRule userMustExistByUsernameRule,
            IPersonMustExistRule personMustExistRule,
            IUsernameMustBeUniqueRule usernameMustBeUniqueRule,
            IPersonMustNotHaveUserRule personMustNotHaveUserRule,
            IUsernameMustBeUniqueForUpdateRule usernameMustBeUniqueForUpdateRule,
            IPersonMustHaveDeletedUserAccountRule personMustHaveDeletedUserAccountRule,
            IPersonMustHasOrHadUserRule personMustHasOrHadUserRule)
        {
            _userMustBeActiveRule = userMustBeActiveRule;
            _userMustExistByIdRule = userMustExistByIdRule;
            _userMustExistByUsernameRule = userMustExistByUsernameRule;
            _personMustExistRule = personMustExistRule;
            _usernameMustBeUniqueRule = usernameMustBeUniqueRule;
            _personMustNotHaveUserRule = personMustNotHaveUserRule;
            _usernameMustBeUniqueForUpdateRule = usernameMustBeUniqueForUpdateRule;
            _personMustHaveDeletedUserAccountRule = personMustHaveDeletedUserAccountRule;
            _personMustHasOrHadUserRule = personMustHasOrHadUserRule;
        }

        public async Task<BusinessRuleResult> ValidateAddAsync(AddUserDTO model)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _personMustExistRule.ValidateAsync(model.PersonID),
                () => _personMustNotHaveUserRule.ValidateAsync(model.PersonID),
                () => _usernameMustBeUniqueRule.ValidateAsync(model.Username)
            };

            if(model.CreatedByUserID.HasValue)
            {
                rules.AddRange
                (
                    new List<Func<Task<BusinessRuleResult>>>
                    {
                        () => _userMustExistByIdRule.ValidateAsync(model.CreatedByUserID.Value),
                        () => _userMustBeActiveRule.ValidateAsync(model.CreatedByUserID.Value)
                    }
                );
            }

            return await ValidateRulesAsync( rules );


        }

        public async Task<BusinessRuleResult> ValidateChangeUserActivationAsync(int userId)
        {
            var ruleResult = await _userMustExistByIdRule.ValidateAsync(userId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateDeleteAsync(int userId)
        {
            var ruleResult = await _userMustExistByIdRule.ValidateAsync(userId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(int userId)
        {
            var ruleResult = await _userMustExistByIdRule.ValidateAsync(userId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateGetByUsernameAsync(string username)
        {
            var ruleResult = await _userMustExistByUsernameRule.ValidateAsync(username);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateHasActiveUserAsync(int personId)
        {
            var ruleResult = await _personMustExistRule.ValidateAsync(personId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidatePersonHasOrHadUserAsync(int personId)
        {
            var ruleResult = await _personMustExistRule.ValidateAsync(personId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateRestoreAsync(int personId)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _personMustExistRule.ValidateAsync(personId),
                () => _personMustHasOrHadUserRule.ValidateAsync (personId),
                () => _personMustHaveDeletedUserAccountRule.ValidateAsync(personId)
            };

            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateUpdateAsync(int userId, UpdateUserDTO model)
        {
            List<Func<Task<BusinessRuleResult>>> rules = new()
            {
                () => _userMustExistByIdRule.ValidateAsync(userId),
                () => _usernameMustBeUniqueForUpdateRule.ValidateAsync
                    (
                        new UsernameMustBeUniqueForUpdateRuleParams
                        {
                            UserId = userId,
                            UserName = model.Username,
                        }
                    )
            };

            return await ValidateRulesAsync(rules);
        }

        public async Task<BusinessRuleResult> ValidateUpdateUserPasswordAsync(int userId)
        {
            var ruleResult = await _userMustExistByIdRule.ValidateAsync(userId);

            return ruleResult;
        }
    }
}
