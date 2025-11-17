using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.ILogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Logging
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogStrategySelector _logStrategySelector;

        public LoggerManager(ILogStrategySelector logStrategySelector)
        {
            _logStrategySelector = logStrategySelector;
        }

        public  Task<bool> LogAsync(enLogStrategyType logStrategyType, enLogEntryType logEntryType, string message, Exception? exception = null)
        {
            var LogStrategy = _logStrategySelector.SelectLogStrategy(logStrategyType);

            return LogStrategy.LogAsync(logEntryType, message, exception);
        }

        public async Task LogWithFallbackAsync(enLogEntryType entryType, string message, Exception ex)
        {

            if (!await LogAsync(enLogStrategyType.Database, entryType, message, ex))
                _ = LogAsync(enLogStrategyType.File, entryType, message, ex);
        }

    }
}
