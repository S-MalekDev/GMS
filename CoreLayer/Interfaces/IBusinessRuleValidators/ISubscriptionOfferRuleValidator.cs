

using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionOfferDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface ISubscriptionOfferRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(int subscriptionOfferId);
        Task<BusinessRuleResult> ValidateDeleteAsync(int subscriptionOfferId);
        Task<BusinessRuleResult> ValidateAddAsync(AddSubscriptionOfferDTO addModel);
        Task<BusinessRuleResult> ValidateUpdateAsync(int subscriptionOfferId, UpdateSubscriptionOfferDTO updateModel);
        
    }
}
