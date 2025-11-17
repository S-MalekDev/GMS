using CoreLayer.Entities;


namespace CoreLayer.Interfaces.ITrainer
{
    public interface ITrainerRepository
    {
        Task<IEnumerable<Trainer>> GetAllAsync();
        Task<Trainer?> GetByIdAsync(int trainerId);
        Task<int> AddAsync(Trainer trainerToAdd);
        Task<bool> UpdateAsync(Trainer trainerToUpdate);
        Task<bool> DeleteAsync(int trainerId);
        Task<bool> IsActiveAcync(int trainerId);
        Task<bool> RestoreAsync(int employeeId);
        Task<bool> ExistsAsync(int trainerId);
        Task<bool> EmployeeBeOrHaveBeTrainerAsync(int employeeId);
        Task<bool> EmployeeHasDeletedTrainerAsync(int employeeId);

    }
}
