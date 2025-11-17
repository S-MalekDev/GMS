using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.EmployeeDTOs;
using CoreLayer.Interfaces.IEmployee;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/employees")]
    [ApiController]
    [ValidateModelAttribute]
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetAllEmployeesAsync")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EmployeeListDTO>>> GetAllAsync()
        {
            var employees = (await _employeeService.GetAllAsync()).Data;

            if (employees == null || !employees.Any())
                return NoContent();

            return Ok(employees);
        }




        [HttpGet("{Id}", Name = "GetEmployeeByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDTO>> GetByIdAsync(int Id)
        {
            var operationResult = await _employeeService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }




        [HttpPost(Name = "AddEmployeeAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddEmployeeDTO employeeToAdd)
        {
            var operationResult = await _employeeService.AddAsync(employeeToAdd);

            return HandleOperationResult(operationResult);
        }



        [HttpPut("{Id}", Name = "UpdateEmployeeAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(int Id, [FromBody] UpdateEmployeeDTO employeeToUpdate)
        {
            var operationResult = await _employeeService.UpdateAsync(Id, employeeToUpdate);

            return HandleOperationResult(operationResult);
        }





        [HttpDelete("{Id}", Name = "DeleteEmployeeAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(int Id)
        {

            var operationResult = await _employeeService.DeleteAsync(Id);

            return HandleOperationResult(operationResult);
        }




        [HttpPut("by-person/{personId}/restore", Name = "RestoreEmployeeAsync")]
        [ValidateIdAttribute(parameterName: "personId")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> RestoreAsync(int personId)
        {
            var operationResult = await _employeeService.RestoreAsync(personId);

            return HandleOperationResult(operationResult);
        }




        [HttpGet("{Id}/exists", Name = "ExistsEmployeeAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ExistsAsync(int Id)
        {
            var operationResult = await _employeeService.ExistsAsync(Id);

            return HandleOperationResult(operationResult);
        }
    }
}