using CoreLayer.Enums;
using CoreLayer.Enums.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.ILogging
{
    public interface ILogStrategy
    {
        Task<bool> LogAsync(enLogEntryType LogEntryType,string message, Exception? exception = null);
    }
}
