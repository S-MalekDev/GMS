


using CoreLayer.Enums.OperationResult;

namespace CoreLayer.Common
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; private set; }
        public OperationResultStatus StatusCode { get; private set; }
        public string? Message { get; private set; } = null;
        public T? Data { get; private set; }

        private OperationResult(bool isSuccess, OperationResultStatus statusCode, string? message, T? data)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }


        public static OperationResult<T> Success(
            T? data = default,
            string? message = null,
            OperationResultStatus statusCode = OperationResultStatus.Ok)
        {
            return new OperationResult<T>(true, statusCode, message, data);
        }

        // ✅ إنشاء فشل (Fail)
        public static OperationResult<T> Fail(
            string message,
            OperationResultStatus statusCode)
        {
            return new OperationResult<T>(false, statusCode, message, default);
        }

        public static OperationResult<T> MapFrom(BusinessRuleResult ruleResult)
        {
            return new OperationResult<T>(ruleResult.IsSuccess, ruleResult.Status, ruleResult.Message, default);
        }
    }
}
