

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Employee
{
    public interface IEmployeeMustBeOrHaveBeTrainerRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int employeeId);
    }
}
