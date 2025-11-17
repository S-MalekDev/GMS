

using CoreLayer.Common;
using CoreLayer.Entities;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.ProgramType;
using CoreLayer.Interfaces.IProgramType;

namespace ApplicationLayer.BusinessRules.ProgramType
{
    public class ProgramTypeMustExistRule : IProgramTypeMustExistRule
    {
        private readonly IProgramTypeRepository _programTypeRepository;
        public ProgramTypeMustExistRule(IProgramTypeRepository programTypeRepository)
        {
            _programTypeRepository = programTypeRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(short programTypeId)
        {
            if (!await _programTypeRepository.ExistsAsync(programTypeId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound, 
                    $"No program type was found with ID [{programTypeId}]. Please verify the ID and try again.");


            return BusinessRuleResult.Success();
        }
    }
}
