using CoreLayer.Entities;



namespace CoreLayer.Interfaces.IPerson.Phone
{
    public interface IPhoneNumberRepository
    {
        Task<IEnumerable<PhoneNumber>> GetAllAsync();
        Task<PhoneNumber?> GetByIdAsync(int phoneNumberId);
        Task<IEnumerable<PhoneNumber>> GetByPersonIdAsync(int personId);
        Task<int> AddAsync(PhoneNumber phoneNumber);
        Task<bool> UpdateAsync(PhoneNumber phoneNumber);
        Task<bool> DeleteAsync(int phoneNumberId);
        Task<bool> ExistsByIdAsync(int phoneNumberId);
        Task<bool> ExistsByPhoneNumberAsync(string phoneNumber);
    }
}
