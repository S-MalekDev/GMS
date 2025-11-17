

using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionTypeDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface ISubscriptionTypeRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(int subscriptionTypeId);
        Task<BusinessRuleResult> ValidateDeleteAsync(int subscriptionTypeId);
        Task<BusinessRuleResult> ValidateAddAsync(AddSubscriptionTypeDTO addModel);
        Task<BusinessRuleResult> ValidateUpdateAsync(int subscriptionTypeId, UpdateSubscriptionTypeDTO updateModel);
    }
}
