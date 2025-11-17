using ApplicationLayer.BusinessRuleValidators;
using AutoMapper;
using CoreLayer.Common;
using CoreLayer.DTOs.ProgramTypeDTOs;
using CoreLayer.DTOs.TrainerDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.IProgramType;

namespace ApplicationLayer.Services
{
    public class ProgramTypeService : IProgramTypeService
    {
        private readonly IProgramTypeRepository _programTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IProgramTypeRuleValidator _programTypeRuleValidator;

        public ProgramTypeService(IProgramTypeRepository programTypeRepository, IMapper mapper, ILoggerManager loggerManager,
            IProgramTypeRuleValidator programTypeRuleValidator)
        {
            _programTypeRepository = programTypeRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _programTypeRuleValidator = programTypeRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<ProgramTypeListDTO>>> GetAllAsync()
        {
            try
            {
                var programTypes = await _programTypeRepository.GetAllAsync();
                return OperationResult<IEnumerable<ProgramTypeListDTO>>.Success(data: _mapper.Map<List<ProgramTypeListDTO>>(programTypes));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<ProgramTypeDTO>> GetByIdAsync(short programTypeId)
        {
            try
            {
                var validationResult = await _programTypeRuleValidator.ValidateGetByIdAsync(programTypeId);
                if (!validationResult.IsSuccess) return OperationResult<ProgramTypeDTO>.MapFrom(validationResult);

                var programType = await _programTypeRepository.GetByIdAsync(programTypeId);
                return OperationResult<ProgramTypeDTO>.Success(data: _mapper.Map<ProgramTypeDTO>(programType));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<short>> AddAsync(AddProgramTypeDTO programTypeToAdd)
        {
            try
            {
                var programType = _mapper.Map<ProgramType>(programTypeToAdd);
                return OperationResult<short>.Success(data: await _programTypeRepository.AddAsync(programType));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> UpdateAsync(short programTypeId, UpdateProgramTypeDTO updateModel)
        {
            try
            {
                var validationResult = await _programTypeRuleValidator.ValidateUpdateAsync(programTypeId, updateModel);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var updatedProgramType = _mapper.Map<ProgramType>(updateModel);

                updatedProgramType.ProgramTypeId = programTypeId;

                return OperationResult<bool>.Success(data: await _programTypeRepository.UpdateAsync(updatedProgramType));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> DeleteAsync(short programTypeId)
        {
            try
            {
                var validationResult = await _programTypeRuleValidator.ValidateDeleteAsync(programTypeId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _programTypeRepository.DeleteAsync(programTypeId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);
                throw;
            }
        }
    }
}
