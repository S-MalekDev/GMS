using CoreLayer.Enums.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.ILogging
{
    public interface ILoggerManager
    {
        Task<bool> LogAsync(enLogStrategyType LogStrategyType, enLogEntryType LogEntryType, string message, Exception? exception = null);
        Task LogWithFallbackAsync(enLogEntryType entryType, string message, Exception ex);
    }
}
