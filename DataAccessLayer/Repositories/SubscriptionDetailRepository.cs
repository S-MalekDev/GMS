using CoreLayer.CommandModel;
using CoreLayer.Configurations;
using CoreLayer.Entities;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.ISubscriptionDetail;
using DataAccessLayer.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.Repositories
{
    public class SubscriptionDetailRepository : ISubscriptionDetailRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public SubscriptionDetailRepository(AppDbContext context, IOptions<DatabaseSettings> options)
        {
            _context = context;
            _connectionString = options.Value.ConnectionString;
        }

        public async Task<IEnumerable<SubscriptionDetail>> GetAllAsync()
        {
            var details = await _context.SubscriptionDetails
                .AsNoTracking()
                .ToListAsync();

            return details;
        }

        public async Task<SubscriptionDetail?> GetByIdAsync(int subscriptionDetailId)
        {
            var detail = await _context.SubscriptionDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(sd => sd.Id == subscriptionDetailId);

            return detail;
        }

        public async Task<int?> AddAsync(AddSubscriptionDetailCommandModel subscriptionDetailToAdd)
        {
            int? SubscriptionDetailID = null;


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddSubscriptionDetail", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SubscriptionID", subscriptionDetailToAdd.SubscriptionID);
                    command.Parameters.AddWithValue("@SubscriptionTypeID", subscriptionDetailToAdd.SubscriptionTypeID);
                    command.Parameters.AddWithValue("@SubscriptionOfferID", (object?)subscriptionDetailToAdd.SubscriptionOfferID ?? DBNull.Value);



                    // باراميتر الإخراج
                    SqlParameter outPutIdParam = new SqlParameter("@SubscriptionDetailID", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    command.Parameters.Add(outPutIdParam);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    SubscriptionDetailID = (int?)outPutIdParam.Value;
                }
            }


            return SubscriptionDetailID;
        }

        public async Task<bool> ExistsAsync(int subscriptionDetailId)
        {
            var exists = await _context.SubscriptionDetails.AsNoTracking().AnyAsync(sd => sd.Id == subscriptionDetailId);

            return exists;
        }
    }
}
