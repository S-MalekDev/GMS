

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.JobSpeciality;
using CoreLayer.Interfaces.ITranierSpeciality;

namespace ApplicationLayer.BusinessRules.JobSpeciality
{
    public class JobSpecialityMustExistRule : IJobSpecialityMustExistRule
    {
        private readonly ISpecialityRepository _specialityRepository;
        public JobSpecialityMustExistRule(ISpecialityRepository specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(short specialityId)
        {
            if (! await _specialityRepository.ExistsAsync(specialityId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"No job speciality was found with ID [{specialityId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
