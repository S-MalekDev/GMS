using CoreLayer.Common;
using CoreLayer.DTOs.JobDTOs;


namespace CoreLayer.Interfaces.IJob
{
    public interface IJobService
    {
        Task<OperationResult<IEnumerable<JobListDTO>>> GetAllAsync();
        Task<OperationResult<JobDTO>> GetByIdAsync(short jobId);
        Task<OperationResult<short>> AddAsync(AddJobDTO jobToAdd);
        Task<OperationResult<bool>> UpdateAsync(short jobId, UpdateJobDTO jobToUpdate);
        Task<OperationResult<bool>> DeleteAsync(short jobId);
    }
}
