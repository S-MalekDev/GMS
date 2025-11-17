using CoreLayer.Enums.OperationResult;
using System.Buffers;

namespace APILayer.Extentions
{
    public static class OperationResultExtensions
    {
        public static int ToHttpStatusCode(this OperationResultStatus status)
        {
            return status switch
            {
                OperationResultStatus.Ok => StatusCodes.Status200OK,
                OperationResultStatus.NoContent => StatusCodes.Status204NoContent,
                OperationResultStatus.BadRequest => StatusCodes.Status400BadRequest,
                OperationResultStatus.NotFound => StatusCodes.Status404NotFound,
                OperationResultStatus.Conflict => StatusCodes.Status409Conflict,
                OperationResultStatus.UnprocessableEntity => StatusCodes.Status422UnprocessableEntity,
                
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
