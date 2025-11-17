using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Interfaces.ILogging;
using WinFormsClient.Logging;
using WinFormsClient.LogginStrategies;

namespace WinFormsClient.Configurations.Extensions
{
    public static class LoggingExtensions
    {
        public static IServiceCollection AddLoggingServices (this IServiceCollection services)
        {

            services.AddSingleton<FileLogStrategy>();
            services.AddSingleton<EventViewerLogStrategy>();
            services.AddSingleton<ILogStrategySelector, LogStrategySelector>();
            services.AddSingleton<ILoggerManager, LoggerManager>();

            return services;
        }
    }
}
