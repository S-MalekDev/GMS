

using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionDetailDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface ISubscriptionDetailRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(int subscriptionDetailId);
        Task<BusinessRuleResult> ValidateAddAsync(AddSubscriptionDetailDTO addModel);

    }
}
