using AutoMapper;
using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionTypeDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.ISubscriptionType;

namespace ApplicationLayer.Services
{
    public class SubscriptionTypeService : ISubscriptionTypeService
    {
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ISubscriptionTypeRuleValidator _subscriptionTypeRuleValidator;


        public SubscriptionTypeService(ISubscriptionTypeRepository subscriptionTypeRepository, IMapper mapper, ILoggerManager loggerManager,
            ISubscriptionTypeRuleValidator subscriptionTypeRuleValidator)
        {
            _subscriptionTypeRepository = subscriptionTypeRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _subscriptionTypeRuleValidator = subscriptionTypeRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<SubscriptionTypeListDTO>>> GetAllAsync()
        {
            try
            {
                var types = await _subscriptionTypeRepository.GetAllAsync();
                return OperationResult<IEnumerable<SubscriptionTypeListDTO>>.Success(data: _mapper.Map<List<SubscriptionTypeListDTO>>(types));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<SubscriptionTypeDTO>> GetByIdAsync(int subscriptionTypeId)
        {
            try
            {
                var validationResult = await _subscriptionTypeRuleValidator.ValidateGetByIdAsync(subscriptionTypeId);
                if (!validationResult.IsSuccess) return OperationResult<SubscriptionTypeDTO>.MapFrom(validationResult);

                var type = await _subscriptionTypeRepository.GetByIdAsync(subscriptionTypeId);
                return OperationResult<SubscriptionTypeDTO>.Success(data: _mapper.Map<SubscriptionTypeDTO>(type));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<int>> AddAsync(AddSubscriptionTypeDTO addModel)
        {
            try
            {
                var validationResult = await _subscriptionTypeRuleValidator.ValidateAddAsync(addModel);
                if (!validationResult.IsSuccess) return OperationResult<int>.MapFrom(validationResult);

                var type = _mapper.Map<SubscriptionType>(addModel);
                return OperationResult<int>.Success(data: await _subscriptionTypeRepository.AddAsync(type));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<bool>> UpdateAsync(int subscriptionTypeId, UpdateSubscriptionTypeDTO updateModel)
        {
            try
            {
                var validationResult = await _subscriptionTypeRuleValidator.ValidateUpdateAsync(subscriptionTypeId, updateModel);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var updatedType = _mapper.Map<SubscriptionType>(updateModel);
                updatedType.SubscriptionTypeID = subscriptionTypeId;

                return OperationResult<bool>.Success(data: await _subscriptionTypeRepository.UpdateAsync(updatedType));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> DeleteAsync(int subscriptionTypeId)
        {
            try
            {
                var validationResult = await _subscriptionTypeRuleValidator.ValidateDeleteAsync(subscriptionTypeId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _subscriptionTypeRepository.DeleteAsync(subscriptionTypeId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);
                throw;
            }
        }
    }
}
