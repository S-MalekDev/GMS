
using CoreLayer.Common;
using CoreLayer.DTOs.EmployeeDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface IEmployeeRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(int employeeId);
        Task<BusinessRuleResult> ValidateDeleteAsync(int employeeId);
        Task<BusinessRuleResult> ValidateRestoreAsync(int personId);
        Task<BusinessRuleResult> ValidateAddAsync(AddEmployeeDTO model);
        Task<BusinessRuleResult> ValidateUpdateAsync(int employeeId, UpdateEmployeeDTO model);

    }
}
