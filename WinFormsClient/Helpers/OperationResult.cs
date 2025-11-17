using System.Net;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using WinFormsClient.Enums.EnLogging;
using WinFormsClient.Interfaces.ILogging;


namespace WinFormsClient.Helpers
{
    public class OperationResult<T>
    {
        private static readonly Dictionary<HttpStatusCode, string> StatusMessages = new()
        {
            { HttpStatusCode.OK, "Data retrieved successfully." },
            { HttpStatusCode.Created, "The item was created successfully." },
            { HttpStatusCode.NoContent, "The request was successful, but there is no data to display at the moment." },
            { HttpStatusCode.BadRequest, "Invalid request. Please verify the submitted data." },
            { HttpStatusCode.Unauthorized, "Unauthorized access. Please log in to continue." },
            { HttpStatusCode.Forbidden, "Access denied. You do not have permission to access this resource." },
            { HttpStatusCode.NotFound, "The requested resource was not found." },
            { HttpStatusCode.InternalServerError, "A server error occurred. Please try again later." }
            
        };
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        private OperationResult(HttpStatusCode statusCode,bool isSuccess,string message, T? data = default)
        { 
            StatusCode = statusCode;
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        private static OperationResult<T> Success(HttpStatusCode statusCode,T data, string message)
        {
            return new OperationResult<T>(statusCode, true, message, data);
        }

        private static OperationResult<T> Failure(HttpStatusCode statusCode, string message)
        {
            return new OperationResult<T>(statusCode, false, message, default);
        }

        private static async Task<T?> TryReadContentAsync(HttpResponseMessage response, ILoggerManager logger)
        {
            try
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch(Exception ex) 
            {
                // Fire-and-forget logging to avoid blocking the UI thread
                _ = logger?.LogWithFallbackAsync(enLogEntryType.Error, $"Error deserializing response content: {ex.Message}", ex);

                throw;
            }
        }

        private static string GetHttpStatusMessage(HttpResponseMessage response, ILoggerManager logger)
        {
            if (StatusMessages.TryGetValue(response.StatusCode, out string? statusMessage))
            {
                return statusMessage;
            }
            else
            {
                // Fire-and-forget logging to avoid blocking the UI thread
                _ = logger.LogWithFallbackAsync(enLogEntryType.Warning, $"Unhandled HTTP status code: {response.StatusCode}");
                return $"Unexpected status code: {response.StatusCode}";
            }
        }

        public static async Task<OperationResult<T>> FromHttpResponseAsync(HttpResponseMessage response, ILoggerManager logger)
        {
            string message = GetHttpStatusMessage(response, logger);


            switch(response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:               
                {
                    try
                    {
                        var data = await TryReadContentAsync(response, logger!);

                        if (data == null)
                        {
                            _ = logger.LogWithFallbackAsync(enLogEntryType.Warning, "Deserialization returned null although request was successful.");
                            return Success(response.StatusCode, Utils.GetEmptyOrDefault<T>(), "Request completed successfully, but no data was returned.");
                        }

                        return Success(response.StatusCode, data, message);
                    }
                    catch(Exception ex)
                    {
                            return Failure(response.StatusCode, $"Deserialization failed: {ex.Message}");
                    }
                }
                case HttpStatusCode.NoContent:
                {
                        return Success(HttpStatusCode.NoContent, Utils.GetEmptyOrDefault<T>(), message);
                }
                default:
                {
                    return Failure(response.StatusCode, message);
                }
            }
    }

}
}
