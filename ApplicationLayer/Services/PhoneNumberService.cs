using AutoMapper;
using CoreLayer.Common;
using CoreLayer.DTOs.PersonDTOs.PhoneNumber;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.IPerson.Phone;
using System.Collections.Generic;

namespace ApplicationLayer.Services
{
    public class PhoneNumberService :IPhoneNumberService
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IPhoneNumberRuleValidator _phoneNumberRuleValidator;

        public PhoneNumberService(IPhoneNumberRepository repository , IMapper mapper, ILoggerManager loggerManager
            , IPhoneNumberRuleValidator phoneNumberRuleValidator)
        {
            _phoneNumberRepository = repository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _phoneNumberRuleValidator = phoneNumberRuleValidator;
        }

        public async Task<OperationResult<int>> AddAsync(AddPhoneNumberDTO phoneNumberToCreate)
        {
            try
            {
                var validationResult = await _phoneNumberRuleValidator.ValidateAddAsync(phoneNumberToCreate);
                if (!validationResult.IsSuccess) return OperationResult<int>.MapFrom(validationResult);

                var phoneNumber = _mapper.Map<PhoneNumber>(phoneNumberToCreate);

                return OperationResult<int>.Success(data: await _phoneNumberRepository.AddAsync(phoneNumber));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);

                throw;
            }
        }

        public async Task<OperationResult<IEnumerable<PhoneNumberListDTO>>> GetAllAsync()
        {
            try
            {
                var allPhoneNumbers = await _phoneNumberRepository.GetAllAsync();

                return OperationResult<IEnumerable<PhoneNumberListDTO>>.Success(_mapper.Map<List<PhoneNumberListDTO>>(allPhoneNumbers));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);

                throw;
            }
        }

        public async Task<OperationResult<PhoneNumberDTO>> GetByIdAsync(int phoneNumberId)
        {
            try
            {
                var validationResult = await _phoneNumberRuleValidator.ValidateGetByIdAsync(phoneNumberId);
                if (!validationResult.IsSuccess) return OperationResult<PhoneNumberDTO>.MapFrom(validationResult); 

                var phoneNumber = await _phoneNumberRepository.GetByIdAsync(phoneNumberId);

                return OperationResult<PhoneNumberDTO>.Success(data: _mapper.Map<PhoneNumberDTO>(phoneNumber));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);

                throw;
            }
        }

        public async Task<OperationResult<IEnumerable<PhoneNumberDTO>>> GetByPersonIdAsync(int personId)
        {
            try
            {
                var validationResult = await _phoneNumberRuleValidator.ValidateGetByPersonIdAsync(personId);
                if (!validationResult.IsSuccess) return OperationResult<IEnumerable<PhoneNumberDTO>>.MapFrom(validationResult);

                var phoneNumber = await _phoneNumberRepository.GetByPersonIdAsync(personId);

                return OperationResult<IEnumerable<PhoneNumberDTO>>.Success(data: _mapper.Map<List<PhoneNumberDTO>>(phoneNumber));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByPersonIdAsync)}", ex);

                throw;
            }
        }

        public async Task<OperationResult<bool>> ExistsByIdAsync(int phoneNumberId)
        {
            try
            {

                return OperationResult<bool>.Success(data: await _phoneNumberRepository.ExistsByIdAsync(phoneNumberId));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(ExistsByIdAsync)}", ex);

                throw;
            }
        }

        public async Task<OperationResult<bool>> ExistsByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                return OperationResult<bool>.Success(data: await _phoneNumberRepository.ExistsByPhoneNumberAsync(phoneNumber));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(ExistsByPhoneNumberAsync)}", ex);

                throw;
            }
        }

        public async Task<OperationResult<bool>> UpdateAsync(int phoneNumberId, UpdatePhoneNumberDTO phoneNumberToUpdate)
        {
            try
            {
                var validationResult = await _phoneNumberRuleValidator.ValidateUpdateAsync(phoneNumberId, phoneNumberToUpdate);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var numberToUpdate = _mapper.Map<PhoneNumber>(phoneNumberToUpdate);
                numberToUpdate.PhoneNumberID = phoneNumberId;
                return OperationResult<bool>.Success(data: await _phoneNumberRepository.UpdateAsync(numberToUpdate));

            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);

                throw;
            }
        }

        public async Task<OperationResult<bool>> DeleteAsync(int phoneNumberId)
        {
            try
            {
                var validationResult = await _phoneNumberRuleValidator.ValidateDeleteAsync(phoneNumberId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _phoneNumberRepository.DeleteAsync(phoneNumberId));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);

                throw;
            }
        }
    }
}
