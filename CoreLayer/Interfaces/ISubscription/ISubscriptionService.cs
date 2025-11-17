

using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionDTOs;
using CoreLayer.DTOs.SubscriptionOfferDTOs;

namespace CoreLayer.Interfaces.ISubscription
{
    public interface ISubscriptionService
    {
        Task<OperationResult<IEnumerable<SubscriptionListDTO>>> GetAllAsync();
        Task<OperationResult<SubscriptionDTO>> GetByIdAsync(int subscriptionId);
        Task<OperationResult<int>> AddAsync(AddSubscriptionDTO subscriptionToAdd);
        Task<OperationResult<bool>> CancelateAsync(int subscriptionId);
        Task<OperationResult<bool>> UpdatePendingSubsPeriodAsync(int subscriptionId, UpdatePendingSubsPeriodDTO model);
    }
}
