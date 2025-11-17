

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Person
{
    public interface IPersonMustBeOrHaveBeEmpoyeeRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int personId);
    }
}
