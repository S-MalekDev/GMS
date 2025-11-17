using WinFormsClient.Enums.EnLogging;

namespace WinFormsClient.Interfaces.ILogging
{
    public interface ILoggerManager
    {
        Task<bool> LogAsync(enLogStrategyType LogStrategyType, enLogEntryType LogEntryType, string message, Exception? exception = null);
        Task LogWithFallbackAsync(enLogEntryType entryType, string message, Exception? ex = null);
    }
}
