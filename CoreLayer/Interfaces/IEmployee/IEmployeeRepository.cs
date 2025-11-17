using CoreLayer.Entities;


namespace CoreLayer.Interfaces.IEmployee
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int employeeId);
        Task<int> AddAsync(Employee employeeToAdd);
        Task<bool> UpdateAsync(Employee employeeToUpdate);
        Task<bool> DeleteAsync(int employeeId);
        Task<bool> RestoreAsync(int personId);
        Task<bool> ExistsByPersonIdAsync(int personId);
        Task<bool> PersonHasDeletedEmployeeAsync(int personId);
        Task<bool> PersonBeOrHaveBeEmployeeAsync(int personId);
        Task<bool> HasEmployeesLinkedToJobAsync(short jobId);
        Task<bool> ExistsAsync(int employeeId);
    }
}
