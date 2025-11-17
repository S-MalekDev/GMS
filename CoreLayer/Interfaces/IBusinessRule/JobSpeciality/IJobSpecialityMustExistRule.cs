

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.JobSpeciality
{
    public interface IJobSpecialityMustExistRule : IBusinessRule<short>
    {
        new Task<BusinessRuleResult> ValidateAsync(short specialityId);
    }
}
