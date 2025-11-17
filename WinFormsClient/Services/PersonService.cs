

using WinFormsClient.DTOs.PersonDTOs;
using WinFormsClient.Interfaces.IPerson;
using WinFormsClient.Enums.EnLogging;
using WinFormsClient.Interfaces.ILogging;
using WinFormsClient.Helpers;


namespace WinFormsClient.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _httpClient;
        private readonly ILoggerManager _loggerManager;

        public PersonService(HttpClient httpClient, ILoggerManager loggerManager)
        {          
            _httpClient = httpClient;
            _loggerManager = loggerManager;
        }

        private MultipartFormDataContent BuildMultipartFormDataFromPersonDTO(IPersonWithImageDTO personWithImage)
        {
            var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(personWithImage.FirstName), nameof(personWithImage.FirstName));
            formData.Add(new StringContent(personWithImage.LastName), nameof(personWithImage.LastName));
            formData.Add(new StringContent(personWithImage.DateOfBirth.ToString("yyyy-MM-dd")), nameof(personWithImage.DateOfBirth));
            formData.Add(new StringContent(personWithImage.Gender.ToString()), nameof(personWithImage.Gender));

            if (!string.IsNullOrWhiteSpace(personWithImage.MiddleName))
                formData.Add(new StringContent(personWithImage.MiddleName), nameof(personWithImage.MiddleName));

            if (!string.IsNullOrWhiteSpace(personWithImage.Email))
                formData.Add(new StringContent(personWithImage.Email), nameof(personWithImage.Email));

            if (!string.IsNullOrEmpty(personWithImage.ImageFilePath) && File.Exists(personWithImage.ImageFilePath))
            {
                var imageContent = new StreamContent(File.OpenRead(personWithImage.ImageFilePath));
                imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(Utils.GetImageMimeType(personWithImage.ImageFilePath)); // حسب نوع الصورة

                formData.Add(imageContent, "Image", Path.GetFileName(personWithImage.ImageFilePath));
            }
            
            return formData; 
        }

        public async Task<OperationResult<List<PersonListDTO>>>GetAllPeopleAsync()
        {
            var response = await _httpClient.GetAsync("./");

            // Parse the response and return the wrapped result
            var result = await OperationResult<List<PersonListDTO>>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, 
                    $"{nameof(GetAllPeopleAsync)}: {result.StatusCode} - {result.Message}");

            return result;

        }

        public async Task<OperationResult<PersonDTO>> GetPersonByIDAsync(int Id)
        {
            var response = await _httpClient.GetAsync($"{Id}");

            var result = await OperationResult<PersonDTO>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, 
                    $"{nameof(GetPersonByIDAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<bool>> IsPersonExistAsync(int Id)
        {
            var response = await _httpClient.GetAsync($"{Id}exists");

            var result = await OperationResult<bool>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, 
                    $"{nameof(IsPersonExistAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<int>> AddPersonAsync(CreatePersonWithImageDTO personWithImage)
        {
            var formData = BuildMultipartFormDataFromPersonDTO(personWithImage);

            var response = await _httpClient.PostAsync("", formData);

            var result = await OperationResult<int>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(AddPersonAsync)}: {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<bool>> UpdatePersonAsync(int Id,UpdatePersonWithImageDTO personToUpdate)
        {
            var formData = BuildMultipartFormDataFromPersonDTO(personToUpdate);

            var response = await _httpClient.PutAsync($"{Id}", formData);

            var result = await OperationResult<bool>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, 
                    $"{nameof(UpdatePersonAsync)}:Failed to update Person with ID {Id} - {result.StatusCode} - {result.Message}");

            return result;
        }

        public async Task<OperationResult<bool>> DeletePersonAsync(int Id)
        {
            var response = await _httpClient.DeleteAsync($"{Id}");

            var result = await OperationResult<bool>.FromHttpResponseAsync(response, _loggerManager);

            if (!result.IsSuccess)
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Warning, $"{nameof(DeletePersonAsync)}:Failed to delete Person with ID {Id} -" +
                    $" {result.StatusCode} - {result.Message}");

            return result;
        }
    }
}
   
