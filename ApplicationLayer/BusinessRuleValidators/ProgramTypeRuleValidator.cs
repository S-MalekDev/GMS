

using ApplicationLayer.BusinessRules;
using CoreLayer.Common;
using CoreLayer.DTOs.ProgramTypeDTOs;
using CoreLayer.Interfaces.IBusinessRule.ProgramType;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.BusinessRuleValidators
{
    public class ProgramTypeRuleValidator : BaseBusinessRuleValidator, IProgramTypeRuleValidator
    {
        private readonly IProgramTypeMustExistRule _programTypeMustExistRule;
        public ProgramTypeRuleValidator(IProgramTypeMustExistRule programTypeMustExistRule)
        {
            _programTypeMustExistRule = programTypeMustExistRule;
        }

        private async Task<BusinessRuleResult> ValidateExists(short programTypeId)
        {
            return await _programTypeMustExistRule.ValidateAsync(programTypeId);
        }
        public Task<BusinessRuleResult> ValidateDeleteAsync(short programTypeId)
        {
            return ValidateExists(programTypeId);
        }

        public Task<BusinessRuleResult> ValidateGetByIdAsync(short programTypeId)
        {
            return ValidateExists(programTypeId);
        }

        public Task<BusinessRuleResult> ValidateUpdateAsync(short programTypeId, UpdateProgramTypeDTO programTypeToUpdate)
        {
            return ValidateExists(programTypeId);
        }
    }
}
