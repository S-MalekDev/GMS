using CoreLayer.Enums.OperationResult;


namespace CoreLayer.Common
{
    public class BusinessRuleResult
    {
        public bool IsSuccess { get;private set; }
        public string Message { get; private set; }
        public OperationResultStatus Status { get; private set; }

        private BusinessRuleResult(bool isSuccess, OperationResultStatus status, string message)
        {
            IsSuccess = isSuccess; 
            Status = status;
            Message = message;
        }

        public static BusinessRuleResult Success(string message = "Business rule passed successfully.") 
            =>  new BusinessRuleResult(true,OperationResultStatus.Ok, message);


        public static BusinessRuleResult Failure(OperationResultStatus status, string message = "Business rule failed.")
            => new BusinessRuleResult(false,status, message);
    }
}
