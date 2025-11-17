

using CoreLayer.Common;

namespace ApplicationLayer.BusinessRules
{
    public abstract class BaseBusinessRuleValidator
    {
        protected async Task<BusinessRuleResult> ValidateRulesAsync(List<Func<Task<BusinessRuleResult>>> rules)
        {
            foreach (var rule in rules)
            {
                var failedRuleResult = await rule();
                if (!failedRuleResult.IsSuccess) return failedRuleResult;
            }

            return BusinessRuleResult.Success();
        }
    }
}
