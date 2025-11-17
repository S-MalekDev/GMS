using ApplicationLayer.BusinessRuleValidators;
using AutoMapper;
using AutoMapper.Execution;
using CoreLayer.Common;
using CoreLayer.DTOs.JobDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.IJob;
using CoreLayer.Interfaces.ILogging;


namespace ApplicationLayer.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IJobRuleValidator _jobRuleValidator;

        public JobService(IJobRepository jobRepository, IMapper mapper, ILoggerManager loggerManager, IJobRuleValidator jobRuleValidator)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _jobRuleValidator = jobRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<JobListDTO>>> GetAllAsync()
        {
            try
            {
                var jobs = await _jobRepository.GetAllAsync();
                return OperationResult<IEnumerable<JobListDTO>>.Success(data: _mapper.Map<List<JobListDTO>>(jobs));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<JobDTO>> GetByIdAsync(short jobId)
        {
            try
            {
                var validationResult = await _jobRuleValidator.ValidateGetByIdAsync(jobId);
                if (!validationResult.IsSuccess) return OperationResult<JobDTO>.MapFrom(validationResult);


                var job = await _jobRepository.GetByIdAsync(jobId);
                return OperationResult<JobDTO>.Success(data: _mapper.Map<JobDTO>(job));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<short>> AddAsync(AddJobDTO jobToAdd)
        {
            try
            {
                var job = _mapper.Map<Job>(jobToAdd);
                return OperationResult<short>.Success(data: await _jobRepository.AddAsync(job));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<bool>> UpdateAsync(short jobId, UpdateJobDTO jobToUpdate)
        {
            try
            {
                var validationResult = await _jobRuleValidator.ValidateUpdateAsync(jobId, jobToUpdate);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var updatedJobToSave = _mapper.Map<Job>(jobToUpdate);
                updatedJobToSave.JobId = jobId;
                return OperationResult<bool>.Success(data: await _jobRepository.UpdateAsync(updatedJobToSave));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<bool>> DeleteAsync(short jobId)
        {
            try
            {
                var validationResult = await _jobRuleValidator.ValidateDeleteAsync(jobId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _jobRepository.DeleteAsync(jobId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);
                throw;
            }
        }
    }
}
