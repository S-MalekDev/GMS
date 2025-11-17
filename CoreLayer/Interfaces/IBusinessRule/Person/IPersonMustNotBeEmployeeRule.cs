

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Person
{
    public interface IPersonMustNotBeEmployeeRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int personId );
    }
}
