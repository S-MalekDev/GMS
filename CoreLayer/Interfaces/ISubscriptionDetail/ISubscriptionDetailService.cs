using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionDetailDTOs;

namespace CoreLayer.Interfaces.ISubscriptionDetail
{
    public interface ISubscriptionDetailService
    {
        Task<OperationResult<IEnumerable<SubscriptionDetailListDTO>>> GetAllAsync();
        Task<OperationResult<SubscriptionDetailDTO>> GetByIdAsync(int subscriptionDetailId);
        Task<OperationResult<int>> AddAsync(AddSubscriptionDetailDTO subscriptionDetailToAdd);
    }
}
