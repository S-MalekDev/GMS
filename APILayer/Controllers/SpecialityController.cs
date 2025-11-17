using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.TrainerSpecialityDTO;
using CoreLayer.Interfaces.ITrainerSpeciality;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/specialities")]
    [ApiController]
    [ValidateModelAttribute]
    public class SpecialityController : BaseApiController
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        [HttpGet(Name = "GetAllSpecialitiesAsync")]
        [ProducesResponseType(typeof(IEnumerable<SpecialityListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SpecialityListDTO>>> GetAllAsync()
        {
            var specialities = (await _specialityService.GetAllAsync()).Data;

            if (specialities == null || !specialities.Any())
                return NoContent();

            return Ok(specialities);
        }




        [HttpGet("{Id}", Name = "GetSpecialityByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(SpecialityDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SpecialityDTO>> GetByIdAsync(short Id)
        {
            var operationResult = await _specialityService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }





        [HttpPost(Name = "AddSpecialityAsync")]
        [ProducesResponseType(typeof(short), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<short>> AddAsync([FromBody] AddSpecialityDTO specialityToAdd)
        {
            var operationResult = await _specialityService.AddAsync(specialityToAdd);

            return HandleOperationResult(operationResult);
        }




        [HttpPut("{Id}", Name = "UpdateSpecialityAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(short Id, [FromBody] UpdateSpecialityDTO specialityToUpdate)
        {
            var operationResult = await _specialityService.UpdateAsync(Id, specialityToUpdate);

            return HandleOperationResult(operationResult);
        }




        [HttpDelete("{Id}", Name = "DeleteSpecialityAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(short Id)
        {
            var operationResult = await _specialityService.DeleteAsync(Id);

            return HandleOperationResult(operationResult);
        }
    }
}
