using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.SubscriptionOfferDTOs;
using CoreLayer.Interfaces.ISubscriptionOffer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APILayer.Controllers
{
    [Route("api/subscription-offers")]
    [ApiController]
    [ValidateModelAttribute]
    public class SubscriptionOfferController : BaseApiController
    {
        private readonly ISubscriptionOfferService _subscriptionOfferService;

        public SubscriptionOfferController(ISubscriptionOfferService subscriptionOfferService)
        {
            _subscriptionOfferService = subscriptionOfferService;
        }

        [HttpGet(Name = "GetAllSubscriptionOffersAsync")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionOfferListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SubscriptionOfferListDTO>>> GetAllAsync()
        {
            var offers = (await _subscriptionOfferService.GetAllAsync()).Data;

            if (offers == null || !offers.Any())
                return NoContent();

            return Ok(offers);
        }

        [HttpGet("{Id}", Name = "GetSubscriptionOfferByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(SubscriptionOfferDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SubscriptionOfferDTO>> GetByIdAsync(int Id)
        {
            var operationResult = await _subscriptionOfferService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }

        [HttpPost(Name = "AddSubscriptionOfferAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddSubscriptionOfferDTO offerToAdd)
        {
            var operationResult = await _subscriptionOfferService.AddAsync(offerToAdd);

            return HandleOperationResult(operationResult);
        }

        [HttpPut("{Id}", Name = "UpdateSubscriptionOfferAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(int Id, [FromBody] UpdateSubscriptionOfferDTO offerToUpdate)
        {
            var operationResult = await _subscriptionOfferService.UpdateAsync(Id, offerToUpdate);

            return HandleOperationResult(operationResult);
        }

        [HttpDelete("{Id}", Name = "DeleteSubscriptionOfferAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(int Id)
        {
            var operationResult = await _subscriptionOfferService.DeleteAsync(Id);

            return HandleOperationResult(operationResult);
        }
    }
}
