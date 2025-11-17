

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.ProgramType
{
    public interface IProgramTypeMustExistRule : IBusinessRule<short>
    {
        new Task<BusinessRuleResult> ValidateAsync(short programTypeId);
    }
}
