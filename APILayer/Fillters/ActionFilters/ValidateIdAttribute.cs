using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection.Metadata;

namespace APILayer.Fillters.ActionFilters
{
    public class ValidateIdAttribute : ActionFilterAttribute
    {
        private readonly string _parameterName;
        public ValidateIdAttribute(string parameterName = "Id")
        {
            _parameterName = parameterName;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ActionArguments.TryGetValue(_parameterName, out var value))
            {
                if(value is int Id && Id <1)
                {
                    context.Result = new BadRequestObjectResult(new {message = $"The parameter '{_parameterName}' must be greater than 0." });
                }
            }
        }
    }
}
