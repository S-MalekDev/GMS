using CoreLayer.Common;
using CoreLayer.DTOs.ProgramTypeDTOs;

namespace CoreLayer.Interfaces.IProgramType
{
    public interface IProgramTypeService
    {
        Task<OperationResult<IEnumerable<ProgramTypeListDTO>>> GetAllAsync();
        Task<OperationResult<ProgramTypeDTO>> GetByIdAsync(short programTypeId);
        Task<OperationResult<short>> AddAsync(AddProgramTypeDTO programTypeToAdd);
        Task<OperationResult<bool>> UpdateAsync(short programTypeId, UpdateProgramTypeDTO updateModel);
        Task<OperationResult<bool>> DeleteAsync(short programTypeId);
    }
}
