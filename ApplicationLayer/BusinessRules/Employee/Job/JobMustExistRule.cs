

using CoreLayer.Common;
using CoreLayer.Enums.OperationResult;
using CoreLayer.Interfaces.IBusinessRule.Employee.Job;
using CoreLayer.Interfaces.IJob;


namespace ApplicationLayer.BusinessRules.Employee.Job
{
    public class JobMustExistRule : IJobMustExistRule
    {
        private readonly IJobRepository _jobRepository;
        public JobMustExistRule(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<BusinessRuleResult> ValidateAsync(short jobId)
        {
            if (! await _jobRepository.Exists(jobId))
                return BusinessRuleResult.Failure(OperationResultStatus.NotFound,
                    $"No job was found with ID [{jobId}]. Please verify the ID and try again.");

            return BusinessRuleResult.Success();
        }
    }
}
