

using CoreLayer.Common;
using CoreLayer.DTOs.JobDTOs;

namespace CoreLayer.Interfaces.IBusinessRuleValidators
{
    public interface IJobRuleValidator
    {
        Task<BusinessRuleResult> ValidateGetByIdAsync(short jobId);
        Task<BusinessRuleResult> ValidateUpdateAsync(short jobId, UpdateJobDTO model);
        Task<BusinessRuleResult> ValidateDeleteAsync(short jobId);
    }
}
