using ApplicationLayer.BusinessRuleValidators;
using AutoMapper;
using CoreLayer.Common;
using CoreLayer.DTOs.EmployeeDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.IEmployee;
using CoreLayer.Interfaces.ILogging;
using System.Collections.Generic;


namespace ApplicationLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IEmployeeRuleValidator _employeeRuleValidator;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ILoggerManager loggerManager,
            IEmployeeRuleValidator employeeRuleValidator)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _employeeRuleValidator = employeeRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<EmployeeListDTO>>> GetAllAsync()
        {
            try
            {
                var employees = await _employeeRepository.GetAllAsync();
                return OperationResult<IEnumerable<EmployeeListDTO>>.Success(data: _mapper.Map<List<EmployeeListDTO>>(employees));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<EmployeeDTO>> GetByIdAsync(int employeeId)
        {
            try
            {
                var validationResult = await _employeeRuleValidator.ValidateGetByIdAsync(employeeId);
                if (!validationResult.IsSuccess) return OperationResult<EmployeeDTO>.MapFrom(validationResult);

                var employee = await _employeeRepository.GetByIdAsync(employeeId);
                return OperationResult<EmployeeDTO>.Success(data: _mapper.Map<EmployeeDTO>(employee));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<int>> AddAsync(AddEmployeeDTO employeeToAdd)
        {
            try
            {
                var validationResult = await _employeeRuleValidator.ValidateAddAsync(employeeToAdd);
                if (!validationResult.IsSuccess) return OperationResult<int>.MapFrom(validationResult);

                var employee = _mapper.Map<Employee>(employeeToAdd);
                return OperationResult<int>.Success(data: await _employeeRepository.AddAsync(employee));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<bool>> UpdateAsync(int employeeId, UpdateEmployeeDTO employeeToUpdate)
        {

            try
            {
                var validationResult = await _employeeRuleValidator.ValidateUpdateAsync(employeeId, employeeToUpdate);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var updatedEmpoloyeeToSave = _mapper.Map<Employee>(employeeToUpdate);
                updatedEmpoloyeeToSave.EmployeeId = employeeId;

                return OperationResult<bool>.Success(data: await _employeeRepository.UpdateAsync(updatedEmpoloyeeToSave));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<bool>> DeleteAsync(int employeeId)
        {
            try
            {
                var validationResult = await _employeeRuleValidator.ValidateDeleteAsync(employeeId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _employeeRepository.DeleteAsync(employeeId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<bool>> RestoreAsync(int personId)
        {
            try
            {
                var validationResult = await _employeeRuleValidator.ValidateRestoreAsync(personId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _employeeRepository.RestoreAsync(personId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(RestoreAsync)}", ex);
                throw;
            }
        }


        public async Task<OperationResult<bool>> ExistsAsync(int employeeId)
        {
            try
            {

                return OperationResult<bool>.Success(data: await _employeeRepository.ExistsAsync(employeeId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(ExistsAsync)}", ex);
                throw;
            }
        }
    }
}
