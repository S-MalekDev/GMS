using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.JobDTOs;
using CoreLayer.Interfaces.IJob;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    [ValidateModelAttribute]
    public class JobController : BaseApiController
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet(Name = "GetAllJobsAsync")]
        [ProducesResponseType(typeof(IEnumerable<JobListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<JobListDTO>>> GetAllAsync()
        {
            var jobs = (await _jobService.GetAllAsync()).Data;

            if (jobs == null || !jobs.Any())
                return NoContent();

            return Ok(jobs);
        }

        [HttpGet("{Id}", Name = "GetJobByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(JobDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JobDTO>> GetByIdAsync(short Id)
        {
            var operationResult = await _jobService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }

        [HttpPost(Name = "AddJobAsync")]
        [ProducesResponseType(typeof(short), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<short>> AddAsync([FromBody] AddJobDTO jobToAdd)
        {
            var operationResult = await _jobService.AddAsync(jobToAdd);

            return HandleOperationResult(operationResult);
        }

        [HttpPut("{Id}", Name = "UpdateJobAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(short Id, [FromBody] UpdateJobDTO jobToUpdate)
        {
            var operationResult = await _jobService.UpdateAsync(Id, jobToUpdate);

            return HandleOperationResult(operationResult);
        }

        [HttpDelete("{Id}", Name = "DeleteJobAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(short Id)
        {
            var operationResult = await _jobService.DeleteAsync(Id);

            return HandleOperationResult(operationResult);
        }
    }
}
