

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.Trainer
{
    public interface ITrainerMustExistRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int trainerId);
    }
}
