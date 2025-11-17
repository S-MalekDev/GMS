using AutoMapper;
using CoreLayer.DTOs.SubscriptionDTOs;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.ISubscription;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.CommandModel;
using CoreLayer.Interfaces.IMember;
using CoreLayer.Common;
using CoreLayer.Enums.SubscriptionStatus;
using CoreLayer.Interfaces.IBusinessRuleValidators;

namespace ApplicationLayer.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ISubscriptionRuleValidator _subscriptionRulevalidator;


        public SubscriptionService(ISubscriptionRepository subscriptionRepository,
            IMapper mapper, ILoggerManager loggerManager, IMemberRepository memberRepository,
            ISubscriptionRuleValidator subscriptionRulevalidator)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _memberRepository = memberRepository;
            _subscriptionRulevalidator = subscriptionRulevalidator;
        }

        public async Task<OperationResult<IEnumerable<SubscriptionListDTO>>> GetAllAsync()
        {
            try
            {
               var subscriptions = await _subscriptionRepository.GetAllAsync();
                return OperationResult<IEnumerable<SubscriptionListDTO>>.Success(_mapper.Map<List<SubscriptionListDTO>>(subscriptions));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<SubscriptionDTO>> GetByIdAsync(int subscriptionId)
        {
            try
            {
                var validationResult = await _subscriptionRulevalidator.ValidateGetByIdAsync(subscriptionId);

                if (!validationResult.IsSuccess) return OperationResult<SubscriptionDTO>.MapFrom(validationResult);

                var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);

                if (subscription == null) 
                    throw new KeyNotFoundException($"The subscription with Id {subscriptionId} no longer exists.");

                return OperationResult<SubscriptionDTO>.Success(_mapper.Map<SubscriptionDTO>(subscription));

            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<int>> AddAsync(AddSubscriptionDTO subscriptionToAdd)
        {
            try
            {            
                var validationResult = await _subscriptionRulevalidator.ValidateAddAsync(subscriptionToAdd);

                if (!validationResult.IsSuccess)
                    return OperationResult<int>.MapFrom(validationResult);

                var subscription = _mapper.Map<AddSubscriptionCommandModel>(subscriptionToAdd);
                var newSubscriptionId = await _subscriptionRepository.AddAsync(subscription);
                return OperationResult<int>.Success(data: newSubscriptionId);

            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> CancelateAsync(int subscriptionId)
        {
            try
            {
                var validationResult = await _subscriptionRulevalidator.ValidateCancelateAsync(subscriptionId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var isUpdated = await _subscriptionRepository.UpdateStatusAsync(subscriptionId, SubscriptionStatus.Cancelled);
                return OperationResult<bool>.Success(data: isUpdated);
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(CancelateAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> UpdatePendingSubsPeriodAsync(int subscriptionId, UpdatePendingSubsPeriodDTO model)
        {
            try
            {
                var validationResult = await _subscriptionRulevalidator.ValidateUpdatePendingSubsPeriodAsync(subscriptionId, model.StartDate);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var isUpdated = await _subscriptionRepository.UpdatePendingSubsPeriodAsync(subscriptionId, model.StartDate);
                return OperationResult<bool>.Success(data: isUpdated);
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(CancelateAsync)}", ex);
                throw;
            }
        }
    }
}
