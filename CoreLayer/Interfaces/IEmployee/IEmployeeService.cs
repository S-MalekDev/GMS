using CoreLayer.Common;
using CoreLayer.DTOs.EmployeeDTOs;


namespace CoreLayer.Interfaces.IEmployee
{
    public interface IEmployeeService
    {
        Task<OperationResult<IEnumerable<EmployeeListDTO>>> GetAllAsync();
        Task<OperationResult<EmployeeDTO>> GetByIdAsync(int employeeId);
        Task<OperationResult<int>> AddAsync(AddEmployeeDTO employeeToAdd);
        Task<OperationResult<bool>> UpdateAsync(int employeeId, UpdateEmployeeDTO employeeToUpdate);
        Task<OperationResult<bool>> DeleteAsync(int employeeId);
        Task<OperationResult<bool>> RestoreAsync(int personId);
        Task<OperationResult<bool>> ExistsAsync(int employeeId);
    }
}
