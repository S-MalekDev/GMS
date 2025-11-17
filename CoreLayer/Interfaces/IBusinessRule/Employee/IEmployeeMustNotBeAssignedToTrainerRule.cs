

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Employee
{
    public interface IEmployeeMustNotBeAssignedToTrainerRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int employeeId);
    }
}
