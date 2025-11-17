

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Person
{
    public interface IPersonMustBeOrHaveBeMemberRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int personId);
    }
}
