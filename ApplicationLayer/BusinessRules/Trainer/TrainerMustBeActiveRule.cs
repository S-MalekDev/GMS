

using CoreLayer.Common;
using CoreLayer.Entities;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Trainer;
using CoreLayer.Interfaces.ITrainer;

namespace ApplicationLayer.BusinessRules.Trainer
{
    public class TrainerMustBeActiveRule : ITrainerMustBeActiveRule
    {
        private readonly ITrainerRepository _trainerRepository;
        public TrainerMustBeActiveRule(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int trainerId)
        {
            if (! await _trainerRepository.IsActiveAcync(trainerId))
                return BusinessRuleResult.Failure(OperationResultStatus.UnprocessableEntity,
                    $"The member (ID: {trainerId}) is currently inactive.");

            return BusinessRuleResult.Success();
        }
        
    }
}
