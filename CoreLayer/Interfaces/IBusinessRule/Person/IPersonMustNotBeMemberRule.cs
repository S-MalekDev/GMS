

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Person
{
    public interface IPersonMustNotBeMemberRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int personId);
    }
}
