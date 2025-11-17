
using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface ISubscriptionRuleValidator
    {
        Task<BusinessRuleResult> ValidateAddAsync(AddSubscriptionDTO subscriptionToAdd);
        Task<BusinessRuleResult> ValidateGetByIdAsync(int subscriptionId);
        Task<BusinessRuleResult> ValidateCancelateAsync(int subscriptionId);
        Task<BusinessRuleResult> ValidateUpdatePendingSubsPeriodAsync(int subscriptionId, DateOnly startDate);

    }
}
