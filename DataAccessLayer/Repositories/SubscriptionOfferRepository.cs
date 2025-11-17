using CoreLayer.Entities;
using CoreLayer.Enums.SubscriptionOffer;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.ISubscriptionOffer;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class SubscriptionOfferRepository : ISubscriptionOfferRepository
    {
        private readonly AppDbContext _context;

        public SubscriptionOfferRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubscriptionOffer>> GetAllAsync()
        {
            var offers = await _context.SubscriptionOffers
                .AsNoTracking()
                .Include(o => o.SubscriptionType)
                .ToListAsync();

            return offers;
        }

        public async Task<SubscriptionOffer?> GetByIdAsync(int subscriptionOfferId)
        {
            var offer = await _context.SubscriptionOffers
                .AsNoTracking()
                .FirstOrDefaultAsync(so => so.OfferId == subscriptionOfferId);

            return offer;
        }

        public async Task<int> AddAsync(SubscriptionOffer subscriptionOfferToAdd)
        {
            await _context.SubscriptionOffers.AddAsync(subscriptionOfferToAdd);
            await _context.SaveChangesAsync();
            return subscriptionOfferToAdd.OfferId;
        }

        public async Task<bool> UpdateAsync(SubscriptionOffer subscriptionOfferToUpdate)
        {
            var offerFound = await _context.SubscriptionOffers
                .FirstOrDefaultAsync(so => so.OfferId == subscriptionOfferToUpdate.OfferId);

            if (offerFound != null)
            {
                offerFound.UpdateFrom(subscriptionOfferToUpdate);

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int subscriptionOfferId)
        {
            var offerFound = await _context.SubscriptionOffers.FindAsync(subscriptionOfferId);

            if (offerFound != null)
            {
                
                _context.SubscriptionOffers.Remove(offerFound);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ExistsAsync(int subscriptionOfferId)
        {
            var subscriptionOffer = await _context.SubscriptionOffers.AsNoTracking().FirstOrDefaultAsync(so => so.OfferId == subscriptionOfferId);
            return subscriptionOffer != null;
        }

        public async Task<bool> IsActiveAsync(int subscriptionOfferId)
        {
            var subscriptionOffer = await _context.SubscriptionOffers.AsNoTracking()
                .FirstOrDefaultAsync(so => so.OfferId == subscriptionOfferId && so.Status == (byte)SubscriptionOfferStatus.Active);

            return subscriptionOffer != null;
        }

        public async Task<bool> IsOfferForSubscriptionTypeAsync(int subscriptionOfferId, int subscriptionTypeId)
        {
            var subscriptionOffer = await _context.SubscriptionOffers.AsNoTracking()
                .FirstOrDefaultAsync(so => so.OfferId == subscriptionOfferId && so.SubscriptionTypeId == subscriptionTypeId);

            return subscriptionOffer != null;
        }
    }
}
