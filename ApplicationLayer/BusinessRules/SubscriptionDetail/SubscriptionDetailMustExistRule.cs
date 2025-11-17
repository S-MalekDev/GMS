

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.SubscriptionDetail;
using CoreLayer.Interfaces.ISubscriptionDetail;

namespace ApplicationLayer.BusinessRules.SubscriptionDetail
{
    public class SubscriptionDetailMustExistRule : ISubscriptionDetailMustExistRule
    {
        private readonly ISubscriptionDetailRepository _subscriptionDetailRepository;
        public SubscriptionDetailMustExistRule(ISubscriptionDetailRepository subscriptionDetailRepository) 
        { 
            _subscriptionDetailRepository = subscriptionDetailRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int subscriptionDetailId)
        {
            if (!await _subscriptionDetailRepository.ExistsAsync(subscriptionDetailId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound, 
                    $"No subscription detail was found with ID [{subscriptionDetailId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
