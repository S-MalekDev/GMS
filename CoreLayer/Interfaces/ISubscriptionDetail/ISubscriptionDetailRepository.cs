

using CoreLayer.CommandModel;
using CoreLayer.Entities;

namespace CoreLayer.Interfaces.ISubscriptionDetail
{
    public interface ISubscriptionDetailRepository
    {
        Task<IEnumerable<SubscriptionDetail>> GetAllAsync();
        Task<SubscriptionDetail?> GetByIdAsync(int subscriptionDetailId);
        Task<int?> AddAsync(AddSubscriptionDetailCommandModel subscriptionDetailToAdd);
        Task<bool> ExistsAsync(int subscriptionDetailId);

    }
}
