using CoreLayer.Common;
using CoreLayer.DTOs.TrainerSpecialityDTO;

namespace CoreLayer.Interfaces.ITrainerSpeciality
{
    public interface ISpecialityService
    {
        Task<OperationResult<IEnumerable<SpecialityListDTO>>> GetAllAsync();
        Task<OperationResult<SpecialityDTO>> GetByIdAsync(short specialityId);
        Task<OperationResult<short>> AddAsync(AddSpecialityDTO specialityToAdd);
        Task<OperationResult<bool>> UpdateAsync(short specialityId, UpdateSpecialityDTO specialityToUpdate);
        Task<OperationResult<bool>> DeleteAsync(short specialityId);
    }
}
