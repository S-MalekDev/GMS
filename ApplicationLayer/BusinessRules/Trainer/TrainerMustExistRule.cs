

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Trainer;
using CoreLayer.Interfaces.ITrainer;

namespace ApplicationLayer.BusinessRules.Trainer
{
    public class TrainerMustExistRule : ITrainerMustExistRule
    {
        private readonly ITrainerRepository _trainerRepository;
        public TrainerMustExistRule(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(int trainerId)
        {
            if(!await _trainerRepository.ExistsAsync(trainerId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"No trainer was found with ID [{trainerId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
