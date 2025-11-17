

using CoreLayer.Entities;

namespace CoreLayer.Interfaces.ISubscriptionOffer
{
    public interface ISubscriptionOfferRepository
    {
        Task<IEnumerable<SubscriptionOffer>> GetAllAsync();
        Task<SubscriptionOffer?> GetByIdAsync(int subscriptionOfferId);
        Task<int> AddAsync(SubscriptionOffer subscriptionOfferToAdd);
        Task<bool> UpdateAsync(SubscriptionOffer subscriptionOfferToUpdate);
        Task<bool> ExistsAsync(int subscriptionOfferId);
        Task<bool> IsActiveAsync(int subscriptionOfferId);
        Task<bool> IsOfferForSubscriptionTypeAsync(int subscriptionOfferId, int subscriptionTypeId);
        Task<bool> DeleteAsync(int subscriptionOfferId);
    }
}
