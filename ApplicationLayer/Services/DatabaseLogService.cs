using CoreLayer.DTOs.LoggingDTOs;
using CoreLayer.Interfaces.ILogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class DatabaseLogService : IDatabaseLogService
    {
        private readonly IDatabaseLogRepository _databaseLogRepositroy;
        public DatabaseLogService(IDatabaseLogRepository databaseLogRepositroy)
        {
            _databaseLogRepositroy = databaseLogRepositroy;
        }

        public Task<bool> TryLogToDataBaseAsync(AddLogDTO addLogDTO)
        {
            return _databaseLogRepositroy.TryLogToDataBaseAsync(addLogDTO);
        }
    }
}
