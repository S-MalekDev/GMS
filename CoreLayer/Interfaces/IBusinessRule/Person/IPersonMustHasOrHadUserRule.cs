

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Person
{
    public interface IPersonMustHasOrHadUserRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int personId);

    }
}
