using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.LoggingStrategies;
using Microsoft.Extensions.DependencyInjection;


namespace CoreLayer.Logging
{
    public class LogStrategySelector : ILogStrategySelector
    {
        private readonly IServiceProvider _ServiceProvider;
        public LogStrategySelector(IServiceProvider ServiceProvider)
        {
            _ServiceProvider = ServiceProvider;
        }
        public ILogStrategy GetLogFileStrategy()
        {
            return _ServiceProvider.GetRequiredService<FileLogStrategy>();
        }
        public ILogStrategy SelectLogStrategy(enLogStrategyType LogStrategyType)
        {
            return LogStrategyType switch
            {
                enLogStrategyType.File => _ServiceProvider.GetRequiredService<FileLogStrategy>(),
                enLogStrategyType.Database => _ServiceProvider.GetRequiredService<DatabaseLogStrategy>(),
                _ => GetLogFileStrategy()
            };
        }
    }
}
