using CoreLayer.Enums.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class SystemLog
    {
        public required int LogID { get; set; }
        public DateTime LogDate { get; set; }
        public required enLogEntryType LogLevel { get; set; }
        public required string Message { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? StackTrace { get; set; }
        public string? Source { get; set; }
    }
}
