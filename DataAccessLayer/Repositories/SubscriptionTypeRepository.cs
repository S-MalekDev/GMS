using CoreLayer.Entities;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.ISubscriptionType;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class SubscriptionTypeRepository : ISubscriptionTypeRepository
    {
        private readonly AppDbContext _context;

        public SubscriptionTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubscriptionType>> GetAllAsync()
        {
            var types = await _context.SubscriptionTypes
                .AsNoTracking()
                .Include(st => st.ProgramType)
                .ToListAsync();

            return types;
        }

        public async Task<SubscriptionType?> GetByIdAsync(int subscriptionTypeId)
        {
            var type = await _context.SubscriptionTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(st => st.SubscriptionTypeID == subscriptionTypeId);

            return type;
        }

        public async Task<int> AddAsync(SubscriptionType subscriptionTypeToAdd)
        {
            await _context.SubscriptionTypes.AddAsync(subscriptionTypeToAdd);
            await _context.SaveChangesAsync();
            return subscriptionTypeToAdd.SubscriptionTypeID;
        }

        public async Task<bool> UpdateAsync(SubscriptionType subscriptionTypeToUpdate)
        {
            var typeFound = await _context.SubscriptionTypes
                .FirstOrDefaultAsync(st => st.SubscriptionTypeID == subscriptionTypeToUpdate.SubscriptionTypeID);

            if (typeFound != null)
            {
                typeFound.UpdateFrom(subscriptionTypeToUpdate);

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int subscriptionTypeId)
        {
            var typeFound = await _context.SubscriptionTypes.FindAsync(subscriptionTypeId);

            if (typeFound != null)
            {
                _context.SubscriptionTypes.Remove(typeFound);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ExistsAsync(int subscriptionTypeId)
        {
            var subscriptionType = await _context.SubscriptionTypes.AsNoTracking()
                .FirstOrDefaultAsync(st => st.SubscriptionTypeID == subscriptionTypeId);

            return subscriptionType != null;
        }

        public async Task<bool> IsActiveAsync(int subscriptionTypeId)
        {
            var subscriptionType = await _context.SubscriptionTypes.AsNoTracking().FirstOrDefaultAsync(st => st.SubscriptionTypeID == subscriptionTypeId && st.IsActive);

            return subscriptionType != null;
        }
    }
}
