using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.ProgramTypeDTOs;
using CoreLayer.Interfaces.IProgramType;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/program-types")]
    [ApiController]
    [ValidateModelAttribute]
    public class ProgramTypeController : BaseApiController
    {
        private readonly IProgramTypeService _programTypeService;

        public ProgramTypeController(IProgramTypeService programTypeService)
        {
            _programTypeService = programTypeService;
        }

        [HttpGet(Name = "GetAllProgramTypesAsync")]
        [ProducesResponseType(typeof(IEnumerable<ProgramTypeListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProgramTypeListDTO>>> GetAllAsync()
        {
            var programTypes = (await _programTypeService.GetAllAsync()).Data;

            if (programTypes == null || !programTypes.Any())
                return NoContent();

            return Ok(programTypes);
        }




        [HttpGet("{Id}", Name = "GetProgramTypeByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(ProgramTypeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProgramTypeDTO>> GetByIdAsync(short Id)
        {
            var operationResult = await _programTypeService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }



        [HttpPost(Name = "AddProgramTypeAsync")]
        [ProducesResponseType(typeof(short), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<short>> AddAsync([FromBody] AddProgramTypeDTO programTypeToAdd)
        {
            var operationResult = await _programTypeService.AddAsync(programTypeToAdd);

            return HandleOperationResult(operationResult);
        }



        [HttpPut("{Id}", Name = "UpdateProgramTypeAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(short Id, [FromBody] UpdateProgramTypeDTO programTypeToUpdate)
        {
            var operationResult = await _programTypeService.UpdateAsync(Id, programTypeToUpdate);

            return HandleOperationResult(operationResult);
        }



        [HttpDelete("{Id}", Name = "DeleteProgramTypeAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(short Id)
        {
            var operationResult = await _programTypeService.DeleteAsync(Id);

            return HandleOperationResult(operationResult);
        }
    }
}
