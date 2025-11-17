using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionTypeDTOs;

namespace CoreLayer.Interfaces.ISubscriptionType
{
    public interface ISubscriptionTypeService
    {
        Task<OperationResult<IEnumerable<SubscriptionTypeListDTO>>> GetAllAsync();
        Task<OperationResult<SubscriptionTypeDTO>> GetByIdAsync(int subscriptionTypeId);
        Task<OperationResult<int>> AddAsync(AddSubscriptionTypeDTO addModel);
        Task<OperationResult<bool>> UpdateAsync(int subscriptionTypeId, UpdateSubscriptionTypeDTO updateModel);
        Task<OperationResult<bool>> DeleteAsync(int subscriptionTypeId);
    }
}
