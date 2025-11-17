

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Employee
{
    public interface IEmployeeMustExistRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int employeeId);
    }
}
