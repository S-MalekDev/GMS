using WinFormsClient.Interfaces.ILogging;
using WinFormsClient.Enums.EnLogging;

namespace WinFormsClient.Logging
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogStrategySelector _logStrategySelector;

        public LoggerManager(ILogStrategySelector logStrategySelector)
        {
            _logStrategySelector = logStrategySelector;
        }

        public Task<bool> LogAsync(enLogStrategyType logStrategyType, enLogEntryType logEntryType, string message, Exception? exception = null)
        {
            var LogStrategy = _logStrategySelector.SelectLogStrategy(logStrategyType);

            return LogStrategy.LogAsync(logEntryType, message, exception);
        }

        public async Task LogWithFallbackAsync(enLogEntryType entryType, string message, Exception? ex = null)
        {

            if (!await LogAsync(enLogStrategyType.EventViewer, entryType, message, ex))
                _ = LogAsync(enLogStrategyType.File, entryType, message, ex);
        }

    }
}
