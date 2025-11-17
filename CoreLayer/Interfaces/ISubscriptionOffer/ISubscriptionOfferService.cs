using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionOfferDTOs;

namespace CoreLayer.Interfaces.ISubscriptionOffer
{
    public interface ISubscriptionOfferService
    {
        Task<OperationResult<IEnumerable<SubscriptionOfferListDTO>>> GetAllAsync();
        Task<OperationResult<SubscriptionOfferDTO>> GetByIdAsync(int subscriptionOfferId);
        Task<OperationResult<int>> AddAsync(AddSubscriptionOfferDTO addModel);
        Task<OperationResult<bool>> UpdateAsync(int subscriptionOfferId, UpdateSubscriptionOfferDTO updateModel);
        Task<OperationResult<bool>> DeleteAsync(int subscriptionOfferId);
    }
}
