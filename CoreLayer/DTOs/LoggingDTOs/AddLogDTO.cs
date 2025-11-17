using CoreLayer.Enums.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.LoggingDTOs
{
    public class AddLogDTO
    {
        public enLogEntryType LogLevel { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? ExceptionMessage { get; set; } = null;
        public string? StackTrace { get; set; } = null;
        public string? Source { get; set; } = null;
    }
}
