

using CoreLayer.Common;
using CoreLayer.DTOs.TrainerSpecialityDTO;
using CoreLayer.Interfaces.IBusinessRule.JobSpeciality;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class JobSpecialityRuleValidator : IJobSpecialityRuleValidator
    {
        private readonly IJobSpecialityMustExistRule _jobSpecialityMustExistRule;
        public JobSpecialityRuleValidator(IJobSpecialityMustExistRule jobSpecialityMustExistRule)
        {
            _jobSpecialityMustExistRule = jobSpecialityMustExistRule;
        }

        private async Task<BusinessRuleResult> GetSpecialityExistRuleResultAsync(short specialityId)
        {
            var ruleResult =  await _jobSpecialityMustExistRule.ValidateAsync(specialityId);

            return ruleResult;
        }

        public async Task<BusinessRuleResult> ValidateDeleteAsync(short specialityId)
        {
            return await GetSpecialityExistRuleResultAsync(specialityId);
        }

        public async Task<BusinessRuleResult> ValidateGetByIdAsync(short specialityId)
        {
            return await GetSpecialityExistRuleResultAsync(specialityId);
        }

        public async Task<BusinessRuleResult> ValidateUpdateAsync(short specialityId, UpdateSpecialityDTO model)
        {
            return await GetSpecialityExistRuleResultAsync(specialityId);
        }
    }
}
