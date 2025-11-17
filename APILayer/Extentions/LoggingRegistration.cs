using CoreLayer.Interfaces.ILogging;
using CoreLayer.Logging;
using CoreLayer.LoggingStrategies;

namespace APILayer.Extentions
{
    public static class LoggingRegistration
    {
        public static void AddLoggingServices(this IServiceCollection services)
        {
            services.AddScoped<FileLogStrategy>();
            services.AddScoped<DatabaseLogStrategy>();
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<ILogStrategySelector, LogStrategySelector>();
        }
    }
}
