using CoreLayer.Common;


namespace CoreLayer.Interfaces.IBusinessRule.Person
{
    public interface IPersonMustHaveDeletedUserAccountRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int personId);
    }
}
