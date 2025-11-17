using APILayer.Extentions;
using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.SubscriptionDTOs;
using CoreLayer.Interfaces.ISubscription;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    [ValidateModelAttribute]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet(Name = "GetAllSubscriptionsAsync")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SubscriptionListDTO>>> GetAllAsync()
        {
            var subscriptions = (await _subscriptionService.GetAllAsync()).Data;

            if (subscriptions == null || !subscriptions.Any())
                return NoContent();

            return Ok(subscriptions);
        }





        [HttpGet("{Id}", Name = "GetSubscriptionByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(SubscriptionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SubscriptionDTO>> GetByIdAsync(int Id)
        {
            var operationResult = await _subscriptionService.GetByIdAsync(Id);

            if (!operationResult.IsSuccess)
                return StatusCode(operationResult.StatusCode.ToHttpStatusCode(), new { message = operationResult.Message });

            return Ok(operationResult.Data);
        }




        [HttpPost(Name = "AddSubscriptionAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddSubscriptionDTO subscriptionToAdd)
        {

            var result = await _subscriptionService.AddAsync(subscriptionToAdd);


            if (result.IsSuccess) return Ok(result.Data);


            return StatusCode(result.StatusCode.ToHttpStatusCode(), new { message = result.Message });
        }



        [HttpPut("{Id}/cancelate",Name = "CancelateSubscriptionAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> CancelateAsync(int Id)
        {

            var operationResult = await _subscriptionService.CancelateAsync(Id);


            if (operationResult.IsSuccess) return Ok(operationResult.Data);


            return StatusCode(operationResult.StatusCode.ToHttpStatusCode(), new { message = operationResult.Message });
        }


        [HttpPut("{Id}/pending-period", Name = "UpdatePendingSubsPeriodAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdatePendingSubsPeriodAsync(int Id,[FromBody] UpdatePendingSubsPeriodDTO model)
        {

            var operationResult = await _subscriptionService.UpdatePendingSubsPeriodAsync(Id, model);


            if (operationResult.IsSuccess) return Ok(operationResult.Data);


            return StatusCode(operationResult.StatusCode.ToHttpStatusCode(), new { message = operationResult.Message });
        }
    }
}
