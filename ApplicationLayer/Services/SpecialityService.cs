using AutoMapper;
using CoreLayer.DTOs.TrainerSpecialityDTO;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.ITranierSpeciality;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Common;
using CoreLayer.Interfaces.ITrainerSpeciality;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IJobSpecialityRuleValidator _jobSpecialityRuleValidator;

        public SpecialityService(ISpecialityRepository specialityRepository, IMapper mapper, ILoggerManager loggerManager,
            IJobSpecialityRuleValidator jobSpecialityRuleValidator)
        {
            _specialityRepository = specialityRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _jobSpecialityRuleValidator = jobSpecialityRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<SpecialityListDTO>>> GetAllAsync()
        {
            try
            {
                var specialities = await _specialityRepository.GetAllAsync();
                return OperationResult<IEnumerable<SpecialityListDTO>>.Success(data: _mapper.Map<List<SpecialityListDTO>>(specialities));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<SpecialityDTO>> GetByIdAsync(short specialityId)
        {
            try
            {
                var validationResult = await _jobSpecialityRuleValidator.ValidateGetByIdAsync(specialityId);
                if (!validationResult.IsSuccess) return OperationResult<SpecialityDTO>.MapFrom(validationResult);

                var speciality = await _specialityRepository.GetByIdAsync(specialityId);
                return OperationResult<SpecialityDTO>.Success(data: _mapper.Map<SpecialityDTO>(speciality));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<short>> AddAsync(AddSpecialityDTO specialityToAdd)
        {
            try
            {
                var speciality = _mapper.Map<Speciality>(specialityToAdd);
                return OperationResult<short>.Success(data: await _specialityRepository.AddAsync(speciality));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> UpdateAsync(short specialityId, UpdateSpecialityDTO specialityToUpdate)
        {
            try
            {
                var validationResult = await _jobSpecialityRuleValidator.ValidateUpdateAsync(specialityId, specialityToUpdate);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var updatedSpeciality = _mapper.Map<Speciality>(specialityToUpdate);
                updatedSpeciality.SpecialityId = specialityId;

                return OperationResult<bool>.Success(data: await _specialityRepository.UpdateAsync(updatedSpeciality));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> DeleteAsync(short specialityId)
        {
            try
            {
                var validationResult = await _jobSpecialityRuleValidator.ValidateDeleteAsync(specialityId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _specialityRepository.DeleteAsync(specialityId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);
                throw;
            }
        }
    }
}
