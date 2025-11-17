

using CoreLayer.Entities;

namespace CoreLayer.Interfaces.ISubscriptionType
{
    public interface ISubscriptionTypeRepository
    {
        Task<IEnumerable<SubscriptionType>> GetAllAsync();
        Task<SubscriptionType?> GetByIdAsync(int subscriptionTypeId);
        Task<int> AddAsync(SubscriptionType subscriptionTypeToAdd);
        Task<bool> UpdateAsync(SubscriptionType subscriptionTypeToUpdate);
        Task<bool> ExistsAsync(int subscriptionTypeId);
        Task<bool> DeleteAsync(int subscriptionTypeId);
        Task<bool> IsActiveAsync(int subscriptionTypeId);

    }
}
