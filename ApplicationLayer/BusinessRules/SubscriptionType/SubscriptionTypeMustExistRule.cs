
using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionType;
using CoreLayer.Interfaces.ISubscriptionType;

namespace ApplicationLayer.BusinessRules.SubscriptionType
{
    public class SubscriptionTypeMustExistRule : ISubscriptionTypeMustExistRule
    {
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
        public SubscriptionTypeMustExistRule(ISubscriptionTypeRepository subscriptionTypeRepository)
        {
            _subscriptionTypeRepository = subscriptionTypeRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int subscriptionTypeId)
        {
            if (!await _subscriptionTypeRepository.ExistsAsync(subscriptionTypeId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound, $"No subscription type was found with ID [{subscriptionTypeId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
