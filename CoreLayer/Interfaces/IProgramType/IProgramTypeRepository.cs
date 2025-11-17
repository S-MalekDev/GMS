

using CoreLayer.Entities;

namespace CoreLayer.Interfaces.IProgramType
{
    public interface IProgramTypeRepository
    {
        Task<IEnumerable<ProgramType>> GetAllAsync();
        Task<ProgramType?> GetByIdAsync(short programTypeId);
        Task<short> AddAsync(ProgramType programTypeToAdd);
        Task<bool> UpdateAsync(ProgramType programTypeToUpdate);
        Task<bool> DeleteAsync(short programTypeId);
        Task<bool> ExistsAsync(short programTypeId);

    }
}
