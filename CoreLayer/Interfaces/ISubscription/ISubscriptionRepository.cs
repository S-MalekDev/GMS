

using CoreLayer.CommandModel;
using CoreLayer.Entities;
using CoreLayer.Enums.SubscriptionStatus;

namespace CoreLayer.Interfaces.ISubscription
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task<IEnumerable<Subscription>> GetPendingSubscriptionByMemberIdAsync(int memberId);
        Task<Subscription?> GetActiveSubscriptionByMemberIdAsync(int memberId);
        Task<Subscription?> GetByIdAsync(int subscriptionId);
        Task<SubscriptionStatus> GetStatusAsync(int subscriptionId);
        Task<int> AddAsync(AddSubscriptionCommandModel subscriptionToAdd);
        Task<bool> IsHasActiveSubscriptionByMemberIdAsync(int memberId);
        Task<bool> ExistsAsync(int subscriptionId);
        Task<bool> UpdatePendingSubsPeriodAsync(int subscriptionId, DateOnly startDate);
        Task<bool> UpdateStatusAsync(int subscriptionId, SubscriptionStatus newStatus);
    }
}
