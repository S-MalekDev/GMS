using CoreLayer.Entities;


namespace CoreLayer.Interfaces.IJob
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllAsync();
        Task<Job?> GetByIdAsync(short jobId);
        Task<short> AddAsync(Job jobToAdd);
        Task<bool> UpdateAsync(Job jobToUpdate);
        Task<bool> DeleteAsync(short jobId);
        Task<bool> Exists(short jobId);
    }
}
