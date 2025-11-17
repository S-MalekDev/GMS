using AutoMapper;
using AutoMapper.Execution;
using CoreLayer.Common;
using CoreLayer.DTOs.MemberDTOs;
using CoreLayer.DTOs.TrainerDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.ITrainer;
using System.Collections.Generic;

namespace ApplicationLayer.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ITrainerRuleValidator _trainerRuleValidator;


        public TrainerService(ITrainerRepository trainerRepository, IMapper mapper, ILoggerManager loggerManager,
            ITrainerRuleValidator trainerRuleValidator)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _trainerRuleValidator = trainerRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<TrainerListDTO>>> GetAllAsync()
        {
            try
            {
                var trainers = await _trainerRepository.GetAllAsync();
                return OperationResult<IEnumerable<TrainerListDTO>>.Success(data: _mapper.Map<List<TrainerListDTO>>(trainers));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<TrainerDTO>> GetByIdAsync(int trainerId)
        {
            try
            {
                var validationResult = await _trainerRuleValidator.ValidateGetByIdAsync(trainerId);
                if (!validationResult.IsSuccess) return OperationResult<TrainerDTO>.MapFrom(validationResult);

                var trainer = await _trainerRepository.GetByIdAsync(trainerId);
                return OperationResult<TrainerDTO>.Success(data: _mapper.Map<TrainerDTO>(trainer));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<int>> AddAsync(AddTrainerDTO trainerToAdd)
        {
            try
            {
                var validationResult = await _trainerRuleValidator.ValidateAddAsync(trainerToAdd);
                if (!validationResult.IsSuccess) return OperationResult<int>.MapFrom(validationResult);

                var trainer = _mapper.Map<Trainer>(trainerToAdd);
                return OperationResult<int>.Success(data: await _trainerRepository.AddAsync(trainer));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> UpdateAsync(int trainerId, UpdateTrainerDTO model)
        {
            try
            {
                var validationResult = await _trainerRuleValidator.ValidateUpdateAsync(trainerId, model);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var trainerToUpdate = await _trainerRepository.GetByIdAsync(trainerId);
                if (trainerToUpdate == null) throw new Exception($"Trainer with ID {trainerId} not found.");

                _mapper.Map(model, trainerToUpdate);
                return OperationResult<bool>.Success(data: await _trainerRepository.UpdateAsync(trainerToUpdate));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> DeleteAsync(int trainerId)
        {
            try
            {
                var validationResult = await _trainerRuleValidator.ValidateDeleteAsync(trainerId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _trainerRepository.DeleteAsync(trainerId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> RestoreAsync(int employeeId)
        {
            try
            {
                var validationResult = await _trainerRuleValidator.ValidateRestoreAsync(employeeId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _trainerRepository.RestoreAsync(employeeId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(RestoreAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> ExistsAsync(int trainerId)
        {
            try
            {
                return OperationResult<bool>.Success(data: await _trainerRepository.ExistsAsync(trainerId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(ExistsAsync)}", ex);
                throw;
            }
        }
    }
}
