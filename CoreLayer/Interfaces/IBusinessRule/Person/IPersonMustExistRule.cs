
using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Person
{
    public interface IPersonMustExistRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int personId);
    }
}
