using CoreLayer.Common;
using CoreLayer.DTOs.TrainerDTOs;

namespace CoreLayer.Interfaces.ITrainer
{
    public interface ITrainerService
    {
        Task<OperationResult<IEnumerable<TrainerListDTO>>> GetAllAsync();
        Task<OperationResult<TrainerDTO>> GetByIdAsync(int trainerId);
        Task<OperationResult<int>> AddAsync(AddTrainerDTO trainerToAdd);
        Task<OperationResult<bool>> UpdateAsync(int trainerId, UpdateTrainerDTO model);
        Task<OperationResult<bool>> DeleteAsync(int trainerId);
        Task<OperationResult<bool>> RestoreAsync(int employeeId);
        Task<OperationResult<bool>> ExistsAsync(int trainerId);
    }
}
