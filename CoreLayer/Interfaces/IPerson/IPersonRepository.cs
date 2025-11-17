using CoreLayer.Entities;


namespace CoreLayer.Interfaces.IPerson
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(int personID);
        Task<int> AddAsync(Person person);
        Task<bool> UpdateAsync(Person person);
        Task<bool> DeleteAsync(int personID);
        Task<bool> ExistsAsync(int personID);
        Task<bool> EmailExistsAsync(string email);
        public Task<string?> GetImageNameByIdAsync(int personID);
    }
}
