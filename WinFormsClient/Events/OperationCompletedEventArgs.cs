using System.Net;
using WinFormsClient.Enums.Operations;

namespace WinFormsClient.Events
{
    public class OperationCompletedEventArgs:EventArgs
    {
        public enOperationType OperationType { get; set; }
        public string Message { get; set; }    
        public bool IsSuccessful { get; set; } 
        public HttpStatusCode StatusCode { get; set; }

        public OperationCompletedEventArgs(enOperationType operationType, string message, bool isSuccessful, HttpStatusCode statusCode)
        {
            OperationType = operationType;
            Message = message;
            IsSuccessful = isSuccessful;
            StatusCode = statusCode;
        }
    }
}
