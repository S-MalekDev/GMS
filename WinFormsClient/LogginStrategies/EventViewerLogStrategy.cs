using System.Diagnostics;
using WinFormsClient.Enums.EnLogging;
using WinFormsClient.Interfaces.ILogging;
using Microsoft.Extensions.Options;
using WinFormsClient.Configurations;


namespace WinFormsClient.LogginStrategies
{
    public class EventViewerLogStrategy : ILogStrategy
    {
        private string _SourceName = "WinFormsClientApp";
        private string _LogName = "Application";
        
        public EventViewerLogStrategy(IOptions<EventViewerLogSettings> options)
        {
            _SourceName = options.Value.SourceName;
            _LogName = options.Value.LogName;


            if (!EventLog.SourceExists(_SourceName))
            {
                try
                {
                    EventLog.CreateEventSource(_SourceName, _LogName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to create event source: {ex.Message}");
                }
            }
        }

        private EventLogEntryType MapEventLogEntryType(enLogEntryType logEntryType)
        {
            return logEntryType switch
            {
                enLogEntryType.Info => EventLogEntryType.Information,
                enLogEntryType.Warning => EventLogEntryType.Warning,
                _ => EventLogEntryType.Error
            };
        }

        public Task<bool> LogAsync(enLogEntryType LogEntryType, string message, Exception? exception)
        {
            if (LogEntryType != enLogEntryType.Error)
                exception = null;

            string exceptionContent = exception != null ? Environment.NewLine + exception.ToString() : string.Empty;

            string logMessageContent = $"""
                [{LogEntryType}]
                {DateTime.Now:HH:mm:ss}: {message} {exceptionContent}
            """;

            return Task.Run(() =>
            {
                try
                {
                    
                    EventLog.WriteEntry(_SourceName, logMessageContent, MapEventLogEntryType(LogEntryType));
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Logging to Event Viewer failed: {ex.Message}");
                    return false;
                }
            });
        }
    }
}
