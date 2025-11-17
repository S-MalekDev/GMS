using CoreLayer.Common;


namespace CoreLayer.Interfaces.IBusinessRule
{
    public interface IBusinessRule<TParam>
    {
        Task<BusinessRuleResult> ValidateAsync(TParam param);
    }
}
