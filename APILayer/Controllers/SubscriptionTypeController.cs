using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.SubscriptionTypeDTOs;
using CoreLayer.Interfaces.ISubscriptionType;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/subscription-types")]
    [ApiController]
    [ValidateModelAttribute]
    public class SubscriptionTypeController : BaseApiController
    {
        private readonly ISubscriptionTypeService _subscriptionTypeService;

        public SubscriptionTypeController(ISubscriptionTypeService subscriptionTypeService)
        {
            _subscriptionTypeService = subscriptionTypeService;
        }

        [HttpGet(Name = "GetAllSubscriptionTypesAsync")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionTypeListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SubscriptionTypeListDTO>>> GetAllAsync()
        {
            var types = (await _subscriptionTypeService.GetAllAsync()).Data;

            if (types == null || !types.Any())
                return NoContent();

            return Ok(types);
        }




        [HttpGet("{Id}", Name = "GetSubscriptionTypeByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(SubscriptionTypeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SubscriptionTypeDTO>> GetByIdAsync(int Id)
        {
            var operationResult = await _subscriptionTypeService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }



        [HttpPost(Name = "AddSubscriptionTypeAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddSubscriptionTypeDTO typeToAdd)
        {
            var operationResult = await _subscriptionTypeService.AddAsync(typeToAdd);

            return HandleOperationResult(operationResult);
        }



        [HttpPut("{Id}", Name = "UpdateSubscriptionTypeAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(int Id, [FromBody] UpdateSubscriptionTypeDTO typeToUpdate)
        {

            var operationResult = await _subscriptionTypeService.UpdateAsync(Id, typeToUpdate);

            return HandleOperationResult(operationResult);
        }



        [HttpDelete("{Id}", Name = "DeleteSubscriptionTypeAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(int Id)
        {
            var operationResult = await _subscriptionTypeService.DeleteAsync(Id);

            return HandleOperationResult(operationResult);
        }
    }
}
