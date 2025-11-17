using Microsoft.Extensions.Options;
using WinFormsClient.Enums.EnLogging;
using WinFormsClient.Interfaces.ILogging;
using WinFormsClient.Configurations;

namespace WinFormsClient.LogginStrategies
{
    public class FileLogStrategy : ILogStrategy
    {
        private readonly string _LogFolderDirectory;

        public FileLogStrategy(IOptions<LogSettings> options)
        {
            _LogFolderDirectory = options.Value.LogFolderDirectory;

            if (!Directory.Exists(_LogFolderDirectory))
                Directory.CreateDirectory(_LogFolderDirectory);
        }

        private async Task<bool> TryLogToFileAsync(string logMessage)
        {
            string LogFileName = DateTime.Now.ToString("yyyyMMdd") + ".log";

            string LogFilePath = Path.Combine(_LogFolderDirectory, LogFileName);

            try
            {
                using var stream = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 4096, useAsync: true);
                using var writer = new StreamWriter(stream);
                await writer.WriteLineAsync(logMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging to file failed: {ex.Message}");
                return false;
            }


        }

        public Task<bool> LogAsync(enLogEntryType LogEntryType, string message, Exception? exception)
        {
            if (LogEntryType != enLogEntryType.Error)
                exception = null;

            string exceptionContent = (exception != null) ? Environment.NewLine + exception.ToString() : string.Empty;
            string logMessageContent = $"""
                -----------------------------------------------------------------------------------------------------------------
                [{LogEntryType}]
                {DateTime.Now:HH:mm:ss}: {message} {exceptionContent}
                ----------------------------------------------------------------------------------------------------------------- 
            
                """
            ;

            return TryLogToFileAsync(logMessageContent);
        }
    }
}
