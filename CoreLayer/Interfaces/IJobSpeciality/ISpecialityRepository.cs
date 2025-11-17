using CoreLayer.Entities;


namespace CoreLayer.Interfaces.ITranierSpeciality
{
    public interface ISpecialityRepository
    {
        Task<IEnumerable<Speciality>> GetAllAsync();
        Task<Speciality?> GetByIdAsync(short specialityId);
        Task<short> AddAsync(Speciality specialityToAdd);
        Task<bool> UpdateAsync(Speciality specialityToUpdate);
        Task<bool> DeleteAsync(short specialityId);
        Task<bool> ExistsAsync(short specialityId);

    }
}
