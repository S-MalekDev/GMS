using APILayer.Extentions;
using CoreLayer.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{

    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected ActionResult<T> HandleOperationResult<T>(OperationResult<T> operationResult)
        {
            if(! operationResult.IsSuccess)
            {
                return StatusCode(operationResult.StatusCode.ToHttpStatusCode(), new {operationResult.Message});
            }

            return Ok(operationResult.Data);
        }
    }
}
