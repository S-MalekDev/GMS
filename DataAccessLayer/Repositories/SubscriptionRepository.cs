using AutoMapper.Execution;
using CoreLayer.CommandModel;
using CoreLayer.Configurations;
using CoreLayer.Entities;
using CoreLayer.Enums.SubscriptionStatus;
using CoreLayer.Interfaces.ISubscription;
using DataAccessLayer.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public SubscriptionRepository(AppDbContext context, IOptions<DatabaseSettings> options)
        {
            _context = context;
            _connectionString = options.Value.ConnectionString;
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            var subscriptions = await _context.Subscriptions
                .AsNoTracking()
                .Include(s => s.Member)
                .ThenInclude(m => m.Person)
                .ToListAsync();

            return subscriptions;
        }

        public async Task<Subscription?> GetByIdAsync(int subscriptionId)
        {
            var subscription = await _context.Subscriptions.AsNoTracking()
                .Include(s => s.subscriptionDetails)
                .ThenInclude(sd => sd.SubscriptionType)
                .FirstOrDefaultAsync(s => s.SubscriptionId == subscriptionId);
                

            return subscription;
        }

        public async Task<IEnumerable<Subscription>> GetPendingSubscriptionByMemberIdAsync(int memberId)
        {
            var pendingSubscriptions = await _context.Subscriptions.AsNoTracking()
                .Where(s => s.MemberId == memberId && s.Status == (byte)(SubscriptionStatus.Pending)).ToListAsync();

            return pendingSubscriptions;
        }

        public async Task<Subscription?> GetActiveSubscriptionByMemberIdAsync(int memberId)
        {
            var subscription = await _context.Subscriptions.AsNoTracking()
                .FirstOrDefaultAsync(s => s.MemberId == memberId && s.Status == (byte)SubscriptionStatus.Active);

            return subscription;
        }

        public async Task<SubscriptionStatus> GetStatusAsync(int subscriptionId)
        {
            var subscription = await _context.Subscriptions.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SubscriptionId == subscriptionId);

            return (SubscriptionStatus)subscription!.Status;
        }

        public async Task<int> AddAsync(AddSubscriptionCommandModel subscriptionToAdd)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_CreateSubscription", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MemberID", subscriptionToAdd.MemberID);
                    command.Parameters.AddWithValue("@SubscriptionTypeID", subscriptionToAdd.SubscriptionTypeID);
                    command.Parameters.AddWithValue("@SubscriptionOfferID", (object?)subscriptionToAdd.SubscriptionOfferID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedByUserID", subscriptionToAdd.CreatedByUserID);
                    command.Parameters.AddWithValue("@StartDate", subscriptionToAdd.StartDate);


                    // باراميتر الإخراج
                    SqlParameter outPutIdParam = new SqlParameter("@SubscriptionID", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    command.Parameters.Add(outPutIdParam);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    return (int)outPutIdParam.Value;
                }
            }

        }

        public async Task<bool> IsHasActiveSubscriptionByMemberIdAsync(int memberId)
        {
            var subscription = await _context.Subscriptions.AsNoTracking()
                .FirstOrDefaultAsync(s => s.MemberId == memberId && s.Status == (byte)SubscriptionStatus.Active);

            return subscription is not null;
        }
  
        public async Task<bool> ExistsAsync(int subscriptionId)
        {
            var exists = await _context.Subscriptions.AnyAsync(s => s.SubscriptionId == subscriptionId);

            return exists;
        }

        public async Task<bool> UpdateStatusAsync(int subscriptionId, SubscriptionStatus newStatus)
        {
            var subscription = await _context.Subscriptions.FindAsync(subscriptionId);

            if (subscription is null) return false;

            subscription.Status = (byte)newStatus;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePendingSubsPeriodAsync(int subscriptionId, DateOnly startDate)
        {
            var subscription = await _context.Subscriptions.FindAsync(subscriptionId);

            if (subscription is null) return false;

            subscription.StartDate = startDate;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
