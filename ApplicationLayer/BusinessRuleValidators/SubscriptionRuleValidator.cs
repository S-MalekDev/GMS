using ApplicationLayer.BusinessRules;
using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionDTOs;
using CoreLayer.IBusinessRules.Parameters;
using CoreLayer.Interfaces.IBusinessRule.Member;
using CoreLayer.Interfaces.IBusinessRule.Subscription;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionOffer;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionType;
using CoreLayer.Interfaces.IBusinessRule.User;
using CoreLayer.Interfaces.IBusinessRuleValidators;


namespace ApplicationLayer.BusinessRuleValidators
{
    public class SubscriptionRuleValidator : BaseBusinessRuleValidator, ISubscriptionRuleValidator
    {
        private readonly IMemberMustExistRule _memberMustExistRule;
        private readonly IMemberMustHasNotActiveSubscriptionRule _memberMustHasNotActiveSubscriptionRule;
        private readonly IUserMustExistByIdRule _userMustExistRule;
        private readonly IOfferMustMatchSubscriptionTypeRule _offerMustMatchSubscriptionTypeRule;
        private readonly ISubscriptionMustExistRule _subscriptionMustExistRule;
        private readonly ISubscriptionOfferMustExistRule _subscriptionOfferMustExistRule;
        private readonly ISubscriptionOfferMustBeActiveRule _subscriptionOfferMustBeActiveRule;
        private readonly ISubscriptionTypeMustBeActiveRule _subscriptionTypeMustBeActiveRule;
        private readonly ISubscriptionTypeMustExistRule _subscriptionTypeMustExistRule;
        private readonly IUserMustBeActiveRule _userMustBeActiveRule;
        private readonly IMemberMustBeActiveRule _memberMustBeActiveRule;
        private readonly ISubscriptionPreventOverlapRule _subscriptionPreventOverlapRule;
        private readonly ISubscriptionMustBePendingRule _subscriptionMustBePendingRule;
        private readonly ISubscriptionPreventOverlapUpdateRule _subscriptionPreventOverlapUpdateRule;


        public SubscriptionRuleValidator(
            IMemberMustExistRule memberMustExistRule, 
            IMemberMustHasNotActiveSubscriptionRule memberMustHasNotActiveSubscriptionRule,
            IUserMustExistByIdRule userMustExistRule, 
            IOfferMustMatchSubscriptionTypeRule offerMustMatchSubscriptionTypeRule,
            ISubscriptionMustExistRule subscriptionMustExistRule,
            ISubscriptionOfferMustExistRule subscriptionOfferMustExistRule,
            ISubscriptionOfferMustBeActiveRule subscriptionOfferMustBeActiveRule, 
            ISubscriptionTypeMustBeActiveRule subscriptionTypeMustBeActiveRule,
            ISubscriptionTypeMustExistRule subscriptionTypeMustExistRule, 
            IUserMustBeActiveRule userMustBeActiveRule, 
            IMemberMustBeActiveRule memberMustBeActiveRule,
            ISubscriptionPreventOverlapRule subscriptionPreventOverlapRule,
            ISubscriptionMustBePendingRule subscriptionMustBePendingRule,
            ISubscriptionPreventOverlapUpdateRule subscriptionPreventOverlapUpdateRule)
        {
            _memberMustExistRule = memberMustExistRule;
            _memberMustHasNotActiveSubscriptionRule = memberMustHasNotActiveSubscriptionRule;
            _userMustExistRule = userMustExistRule;
            _offerMustMatchSubscriptionTypeRule = offerMustMatchSubscriptionTypeRule;
            _subscriptionOfferMustBeActiveRule = subscriptionOfferMustBeActiveRule;
            _subscriptionOfferMustExistRule = subscriptionOfferMustExistRule;
            _subscriptionTypeMustBeActiveRule = subscriptionTypeMustBeActiveRule;
            _subscriptionTypeMustExistRule = subscriptionTypeMustExistRule;
            _userMustBeActiveRule = userMustBeActiveRule;
            _memberMustBeActiveRule = memberMustBeActiveRule;
            _subscriptionPreventOverlapRule = subscriptionPreventOverlapRule;
            _subscriptionMustExistRule = subscriptionMustExistRule;
            _subscriptionMustBePendingRule = subscriptionMustBePendingRule;
            _subscriptionPreventOverlapUpdateRule = subscriptionPreventOverlapUpdateRule;
        }



        public async Task<BusinessRuleResult> ValidateAddAsync(AddSubscriptionDTO subscriptionToAdd)
        {
            // Add the list of rules we need to validate after add a new subscription.
            var rules = new List<Func<Task<BusinessRuleResult>>>()
            {
                () => _memberMustExistRule.ValidateAsync(subscriptionToAdd.MemberID),
                () => _memberMustBeActiveRule.ValidateAsync(subscriptionToAdd.MemberID),
                () => _userMustExistRule.ValidateAsync(subscriptionToAdd.CreatedByUserID),
                () => _userMustBeActiveRule.ValidateAsync(subscriptionToAdd.CreatedByUserID),
                () => _subscriptionTypeMustExistRule.ValidateAsync(subscriptionToAdd.SubscriptionTypeID),
                () => _subscriptionTypeMustBeActiveRule.ValidateAsync(subscriptionToAdd.SubscriptionTypeID),
                () => _subscriptionPreventOverlapRule.ValidateAsync(
                    new SubNoOverlapRuleParams
                    {
                        memberId = subscriptionToAdd.MemberID,
                        SubscriptionTypeId = subscriptionToAdd.SubscriptionTypeID,
                        StartDate = subscriptionToAdd.StartDate
                    }
                    )

            };

            // If subscription offer id has value will add list of rules to validate it.
            if(subscriptionToAdd.SubscriptionOfferID.HasValue)
            {
                var offerId = subscriptionToAdd.SubscriptionOfferID.Value;

                rules.AddRange
                    (
                    new List<Func<Task<BusinessRuleResult>>>
                    {
                        () => _subscriptionOfferMustExistRule.ValidateAsync(offerId),
                        () => _subscriptionOfferMustBeActiveRule.ValidateAsync(offerId),
                        () => _offerMustMatchSubscriptionTypeRule
                         .ValidateAsync(new OfferSubscriptionTypeParams
                         {
                             OfferId = offerId,
                             SubscriptionTypeId = subscriptionToAdd.SubscriptionTypeID
                         }
                         )
                    }
                    );
            }

            return await ValidateRulesAsync( rules );

        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(int subscriptionId)
        {
            var validationResult = await _subscriptionMustExistRule.ValidateAsync(subscriptionId);

            return validationResult;
        }

        public async Task<BusinessRuleResult> ValidateCancelateAsync(int subscriptionId)
        {
            var validationResult = await _subscriptionMustExistRule.ValidateAsync(subscriptionId);

            return validationResult;
        }

        public async Task<BusinessRuleResult> ValidateUpdatePendingSubsPeriodAsync(int subscriptionId, DateOnly startDate)
        {
            var rules = new List<Func<Task<BusinessRuleResult>>>()
            {
                () => _subscriptionMustExistRule.ValidateAsync(subscriptionId),
                () => _subscriptionMustBePendingRule.ValidateAsync(subscriptionId),
                () => _subscriptionPreventOverlapUpdateRule.ValidateAsync
                (
                    new SubNoOverlapUpdateRuleParams
                    {
                        SubscriptionId = subscriptionId,
                        StartDate = startDate
                    }

                )
            };

            return await ValidateRulesAsync(rules);
        }
    }
}
