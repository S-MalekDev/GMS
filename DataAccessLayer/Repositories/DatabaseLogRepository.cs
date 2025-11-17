using CoreLayer.Configurations;
using CoreLayer.DTOs.LoggingDTOs;
using CoreLayer.Interfaces.ILogging;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DatabaseLogRepository:IDatabaseLogRepository
    {
        private readonly string _connectionString;

        public DatabaseLogRepository(IOptions<DatabaseSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
          
        }
        public async Task<bool> TryLogToDataBaseAsync(AddLogDTO addLogDTO)
        {
            int? newLogID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddLog", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LogLevel", (byte)addLogDTO.LogLevel);
                        command.Parameters.AddWithValue("@Message", addLogDTO.Message);
                        command.Parameters.AddWithValue("@ExceptionMessage", (object?)addLogDTO.ExceptionMessage ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StackTrace", (object?)addLogDTO.StackTrace ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Source", (object?)addLogDTO.Source ?? DBNull.Value);

                        // باراميتر الإخراج
                        SqlParameter outPutIdParam = new SqlParameter("@LogID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(outPutIdParam);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        newLogID = (int?)outPutIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging to database failed: {ex.Message}");
                newLogID = null;
            }

            return newLogID != null;
        }
    }
}
