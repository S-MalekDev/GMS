using ApplicationLayer.BusinessRuleValidators;
using AutoMapper;
using AutoMapper.Execution;
using CoreLayer.Common;
using CoreLayer.DTOs.MemberDTOs;
using CoreLayer.DTOs.ProgramTypeDTOs;
using CoreLayer.DTOs.SubscriptionOfferDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.ISubscriptionOffer;
using System.Collections.Generic;

namespace ApplicationLayer.Services
{
    public class SubscriptionOfferService : ISubscriptionOfferService
    {
        private readonly ISubscriptionOfferRepository _subscriptionOfferRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ISubscriptionOfferRuleValidator _subscriptionOfferRuleValidator;

        public SubscriptionOfferService(ISubscriptionOfferRepository subscriptionOfferRepository, IMapper mapper, ILoggerManager loggerManager,
           ISubscriptionOfferRuleValidator subscriptionOfferRuleValidator)
        {
            _subscriptionOfferRepository = subscriptionOfferRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _subscriptionOfferRuleValidator = subscriptionOfferRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<SubscriptionOfferListDTO>>> GetAllAsync()
        {
            try
            {
                var offers = await _subscriptionOfferRepository.GetAllAsync();
                return OperationResult<IEnumerable<SubscriptionOfferListDTO>>.Success(data: _mapper.Map<List<SubscriptionOfferListDTO>>(offers));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<SubscriptionOfferDTO>> GetByIdAsync(int subscriptionOfferId)
        {
            try
            {
                var validationResult = await _subscriptionOfferRuleValidator.ValidateGetByIdAsync(subscriptionOfferId);
                if (!validationResult.IsSuccess) return OperationResult<SubscriptionOfferDTO>.MapFrom(validationResult);

                var offer = await _subscriptionOfferRepository.GetByIdAsync(subscriptionOfferId);
                return OperationResult<SubscriptionOfferDTO>.Success(data: _mapper.Map<SubscriptionOfferDTO>(offer));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<int>> AddAsync(AddSubscriptionOfferDTO addModel)
        {
            try
            {
                var validationResult = await _subscriptionOfferRuleValidator.ValidateAddAsync(addModel);
                if (!validationResult.IsSuccess) return OperationResult<int>.MapFrom(validationResult);

                var offer = _mapper.Map<SubscriptionOffer>(addModel);
                return OperationResult<int>.Success(data: await _subscriptionOfferRepository.AddAsync(offer));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> UpdateAsync(int subscriptionOfferId, UpdateSubscriptionOfferDTO updateModel)
        {
            try
            {
                var validationResult = await _subscriptionOfferRuleValidator.ValidateUpdateAsync(subscriptionOfferId, updateModel);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var updatedOffer = _mapper.Map<SubscriptionOffer>(updateModel);
                updatedOffer.OfferId = subscriptionOfferId;

                return OperationResult<bool>.Success(data: await _subscriptionOfferRepository.UpdateAsync(updatedOffer));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> DeleteAsync(int subscriptionOfferId)
        {
            try
            {
                var validationResult = await _subscriptionOfferRuleValidator.ValidateDeleteAsync(subscriptionOfferId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _subscriptionOfferRepository.DeleteAsync(subscriptionOfferId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);
                throw;
            }
        }
    }
}
