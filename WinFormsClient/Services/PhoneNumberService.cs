using System.Net.Http.Json;
using WinFormsClient.DTOs.PersonDTOs.PhoneNumberDTOs;
using WinFormsClient.Enums.EnLogging;
using WinFormsClient.Helpers;
using WinFormsClient.Interfaces.ILogging;
using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly HttpClient _httpClient;
        private readonly ILoggerManager _loggerManager;

        public PhoneNumberService(HttpClient httpClient, ILoggerManager loggerManager)
        {
            _httpClient = httpClient;
            _loggerManager = loggerManager;
        }

        public async Task<OperationResult<List<PhoneNumberListDTO>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("");
            var result = await OperationResult<List<PhoneNumberListDTO>>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(GetAllAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<int>> AddPhoneNumberAsync(AddPhoneNumberDTO phoneNumberToAdd)
        {
            var response = await _httpClient.PostAsJsonAsync("", phoneNumberToAdd);

            var result = await OperationResult<int>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(AddPhoneNumberAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<PhoneNumberDTO>> GetPhoneByIdAsync(int Id)
        {
            var response = await _httpClient.GetAsync($"{Id}");
            var result = await OperationResult<PhoneNumberDTO>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(GetPhoneByIdAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<List<PhoneNumberDTO>>> GetPhoneByPersonIdAsync(int personId)
        {
            var response = await _httpClient.GetAsync($"by-person/{personId}");
            var result = await OperationResult<List<PhoneNumberDTO>>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(GetPhoneByPersonIdAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<bool>> ExistsByIdAsync(int Id)
        {
            var response = await _httpClient.GetAsync($"{Id}/exists");
            var result = await OperationResult<bool>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(ExistsByIdAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<bool>> ExistsByPhoneNumberAsync(string phoneNumber)
        {
            var response  = await _httpClient.GetAsync($"is-phone-exists?phoneNumber={Uri.EscapeDataString(phoneNumber)}");

            var result = await OperationResult<bool>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(ExistsByPhoneNumberAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<bool>> UpdateAsync(int Id, UpdatePhoneNumberDTO phoneNumberToUpdate)
        {
            var response = await _httpClient.PutAsJsonAsync($"{Id}", phoneNumberToUpdate);

            var result = await OperationResult<bool>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(UpdateAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<bool>> DeleteAsync(int Id)
        {
            var response = await _httpClient.DeleteAsync($"{Id}");
            var result = await OperationResult<bool>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(DeleteAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }
    }
}
