

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Trainer
{
    public interface ITrainerMustBeActiveRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int trainerId);
    }
}
