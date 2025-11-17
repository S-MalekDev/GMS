using CoreLayer.DTOs.LoggingDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.ILogging
{
    public interface IDatabaseLogService
    {
        Task<bool> TryLogToDataBaseAsync(AddLogDTO addLogDTO);
    }
}
