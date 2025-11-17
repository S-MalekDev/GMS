

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Employee.Job
{
    public interface IJobMustExistRule : IBusinessRule<short>
    {
        new Task<BusinessRuleResult> ValidateAsync(short jobId);
    }
}
