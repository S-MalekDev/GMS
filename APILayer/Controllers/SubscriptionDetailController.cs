using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.SubscriptionDetailDTOs;
using CoreLayer.Entities;
using CoreLayer.Interfaces.ISubscriptionDetail;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/subscription-details")]
    [ApiController]
    [ValidateModelAttribute]
    public class SubscriptionDetailController : BaseApiController
    {
        private readonly ISubscriptionDetailService _subscriptionDetailService;

        public SubscriptionDetailController(ISubscriptionDetailService subscriptionDetailService)
        {
            _subscriptionDetailService = subscriptionDetailService;
        }

        [HttpGet(Name = "GetAllSubscriptionDetailsAsync")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionDetailListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SubscriptionDetailListDTO>>> GetAllAsync()
        {
            var details = (await _subscriptionDetailService.GetAllAsync()).Data;

            if (details == null || !details.Any())
                return NoContent();

            return Ok(details);
        }




        [HttpGet("{Id}", Name = "GetSubscriptionDetailByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(SubscriptionDetailDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SubscriptionDetailDTO>> GetByIdAsync(int Id)
        {
            var operationResult = await _subscriptionDetailService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }




        [HttpPost(Name = "AddSubscriptionDetailAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddSubscriptionDetailDTO detailToAdd)
        {
            var operationResult = await _subscriptionDetailService.AddAsync(detailToAdd);

            return HandleOperationResult(operationResult);
        }
    }
}
