using CoreLayer.Configurations;
using CoreLayer.DTOs.PersonDTOs;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.DTOs.LoggingDTOs;
using Microsoft.Extensions.Options;


namespace CoreLayer.LoggingStrategies
{
    public class DatabaseLogStrategy : ILogStrategy
    {
        private readonly string _connectionString;
        private readonly IDatabaseLogService _databaseLogService;
        public DatabaseLogStrategy(IOptions<DatabaseSettings>options, IDatabaseLogService databaseLogService)
        {
            _connectionString = options.Value.ConnectionString;
            _databaseLogService = databaseLogService;
        }
     
        public Task<bool> LogAsync(enLogEntryType LogEntryType, string message, Exception? exception = null)
        {
            if (LogEntryType != enLogEntryType.Error)
                exception = null;

            var logInfo = new AddLogDTO
            {
                LogLevel = LogEntryType,
                Message = message,
                ExceptionMessage = exception?.Message,
                StackTrace = exception?.StackTrace,
                Source = exception?.Source
            };

            return _databaseLogService.TryLogToDataBaseAsync(logInfo);               
        }
    }
}
