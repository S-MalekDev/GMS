using Microsoft.Extensions.DependencyInjection;
using WinFormsClient.LogginStrategies;
using System.Threading.Tasks;
using WinFormsClient.Enums.EnLogging;
using WinFormsClient.Interfaces.ILogging;

namespace WinFormsClient.Logging
{
    public class LogStrategySelector : ILogStrategySelector
    {
        private readonly IServiceProvider _ServiceProvider;
        public LogStrategySelector(IServiceProvider ServiceProvider)
        {
            _ServiceProvider = ServiceProvider;
        }
        public ILogStrategy SelectLogStrategy(enLogStrategyType LogStrategyType)
        {
            return LogStrategyType switch
            {
                enLogStrategyType.File => _ServiceProvider.GetRequiredService<FileLogStrategy>(),
                enLogStrategyType.EventViewer => _ServiceProvider.GetRequiredService<EventViewerLogStrategy>(),
                _ => _ServiceProvider.GetRequiredService<FileLogStrategy>()
            };
        }
    }
}
