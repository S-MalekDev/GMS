

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionType;
using CoreLayer.Interfaces.ISubscriptionType;

namespace ApplicationLayer.BusinessRules.SubscriptionType
{
    public class SubscriptionTypeMustBeActiveRule : ISubscriptionTypeMustBeActiveRule
    {
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
        public SubscriptionTypeMustBeActiveRule(ISubscriptionTypeRepository subscriptionTypeRepository)
        {
            _subscriptionTypeRepository = subscriptionTypeRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int subscriptionTypeId)
        {
            if (!await _subscriptionTypeRepository.IsActiveAsync(subscriptionTypeId))
                return BusinessRuleResult.Failure(OperationResultStatus.UnprocessableEntity, 
                    "The selected subscription type is not active.");


            return BusinessRuleResult.Success();
        }
    }
}
