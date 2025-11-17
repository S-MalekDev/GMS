using WinFormsClient.Enums.EnLogging;

namespace WinFormsClient.Interfaces.ILogging
{
    public interface ILogStrategy
    {
        Task<bool> LogAsync(enLogEntryType LogEntryType, string message, Exception? exception = null);
    }
}
