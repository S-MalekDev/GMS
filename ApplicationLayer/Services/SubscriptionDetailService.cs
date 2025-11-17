using AutoMapper;
using CoreLayer.CommandModel;
using CoreLayer.Common;
using CoreLayer.DTOs.SubscriptionDetailDTOs;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.ISubscriptionDetail;

namespace ApplicationLayer.Services
{
    public class SubscriptionDetailService : ISubscriptionDetailService
    {
        private readonly ISubscriptionDetailRepository _subscriptionDetailRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ISubscriptionDetailRuleValidator _subscriptionDetailRuleValidator;

        public SubscriptionDetailService(ISubscriptionDetailRepository subscriptionDetailRepository, IMapper mapper, ILoggerManager loggerManager,
            ISubscriptionDetailRuleValidator subscriptionDetailRuleValidator)
        {
            _subscriptionDetailRepository = subscriptionDetailRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _subscriptionDetailRuleValidator = subscriptionDetailRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<SubscriptionDetailListDTO>>> GetAllAsync()
        {
            try
            {
                var details = await _subscriptionDetailRepository.GetAllAsync();
                return OperationResult<IEnumerable<SubscriptionDetailListDTO>>.Success(data: _mapper.Map<List<SubscriptionDetailListDTO>>(details));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<SubscriptionDetailDTO>> GetByIdAsync(int subscriptionDetailId)
        {
            try
            {
                var validationResult = await _subscriptionDetailRuleValidator.ValidateGetByIdAsync(subscriptionDetailId);
                if (!validationResult.IsSuccess) return OperationResult<SubscriptionDetailDTO>.MapFrom(validationResult);

                var detail = await _subscriptionDetailRepository.GetByIdAsync(subscriptionDetailId);
                return OperationResult<SubscriptionDetailDTO>.Success(data: _mapper.Map<SubscriptionDetailDTO>(detail));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<int>> AddAsync(AddSubscriptionDetailDTO addModel)
        {
            try
            {
                var validationResult = await _subscriptionDetailRuleValidator.ValidateAddAsync(addModel);
                if (!validationResult.IsSuccess) return OperationResult<int>.MapFrom(validationResult);

                var detail = _mapper.Map<AddSubscriptionDetailCommandModel>(addModel);
                var newSubscriptionDetailId = await _subscriptionDetailRepository.AddAsync(detail);
                return OperationResult<int>.Success(data: newSubscriptionDetailId.Value);
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }

    }
}
