using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.TrainerDTOs;
using CoreLayer.Interfaces.ITrainer;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/trainers")]
    [ApiController]
    [ValidateModelAttribute]
    public class TrainerController : BaseApiController
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet(Name = "GetAllTrainersAsync")]
        [ProducesResponseType(typeof(IEnumerable<TrainerListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TrainerListDTO>>> GetAllAsync()
        {
            var trainers = (await _trainerService.GetAllAsync()).Data;

            if (trainers == null || !trainers.Any())
                return NoContent();

            return Ok(trainers);
        }

        [HttpGet("{Id}", Name = "GetTrainerByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(TrainerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TrainerDTO>> GetByIdAsync(int Id)
        {
            var operationResult = await _trainerService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }

        [HttpPost(Name = "AddTrainerAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddTrainerDTO trainerToAdd)
        {
            var operationResult = await _trainerService.AddAsync(trainerToAdd);

            return HandleOperationResult(operationResult);
        }

        [HttpPut("{Id}", Name = "UpdateTrainerAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(int Id, [FromBody] UpdateTrainerDTO trainerToUpdate)
        {
            var operationResult = await _trainerService.UpdateAsync(Id, trainerToUpdate);

            return HandleOperationResult(operationResult);
        }

        [HttpDelete("{Id}", Name = "DeleteTrainerAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(int Id)
        {
            var operationResult = await _trainerService.DeleteAsync(Id);

            return HandleOperationResult(operationResult);
        }

        [HttpPut("by-employee/{employeeId}/restore", Name = "RestoreTrainerAsync")]
        [ValidateIdAttribute(parameterName: "employeeId")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> RestoreAsync(int employeeId)
        {
            var operationResult = await _trainerService.RestoreAsync(employeeId);

            return HandleOperationResult(operationResult);
        }

        [HttpGet("{Id}/exists", Name = "ExistsTrainerAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ExistsAsync(int Id)
        {
            var operationResult = await _trainerService.ExistsAsync(Id);

            return HandleOperationResult(operationResult);
        }
    }
}
