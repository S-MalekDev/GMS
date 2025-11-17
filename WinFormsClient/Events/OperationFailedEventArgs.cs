using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Enums.Operations;

namespace WinFormsClient.Events
{
    public class OperationFailedEventArgs:EventArgs
    {
        public enOperationType OperationType { get; set; }
        public string Message { get; set; }

        public OperationFailedEventArgs(enOperationType operationType, string message)
        {
            OperationType = operationType;
            Message = message;
        }
    }
}
