using AutoMapper;
using System.ComponentModel;
using System.Net;
using WinFormsClient.DTOs.PersonDTOs;
using WinFormsClient.Enums.Operations;
using WinFormsClient.Events;
using WinFormsClient.Interfaces.ILogging;
using WinFormsClient.Services;
using WinFormsClient.Enums.EnLogging;
using WinFormsClient.Helpers;
using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.ViewModels
{
    public class PersonViewModel : IPersonViewModel
    {
        private readonly IPersonService _personService;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public BindingList<PersonListDTO>? People { get; private set; }
        

        public event EventHandler<OperationCompletedEventArgs>? OperationCompleted;
        public event EventHandler<OperationFailedEventArgs>? OperationFailed;


        public PersonViewModel(IPersonService personService,ILoggerManager loggerManager,IMapper mapper)
        {
            _personService = personService;
            _loggerManager = loggerManager;
            _mapper = mapper;

            People = new BindingList<PersonListDTO>();
        }

        private void NotifyOperationCompleted(enOperationType operationType, string message, bool isSuccess, HttpStatusCode statusCode)
        {
            OperationCompleted?.Invoke(this, new OperationCompletedEventArgs(operationType, message, isSuccess,statusCode));
        }

        private void NotifyOperationFailed(enOperationType operationType, string message)
        {
            OperationFailed?.Invoke(this, new OperationFailedEventArgs(operationType, message));
        }

        private T? HandleResult<T>(OperationResult<T> result, enOperationType opType, string successMsg, string failMsg)
        {
            if (result.IsSuccess && result.Data != null)
            {
                NotifyOperationCompleted(opType, successMsg, true, result.StatusCode);
                return result.Data;
            }

            NotifyOperationCompleted(opType, $"{failMsg}: {result.Message}", false, result.StatusCode);
            return default;
        }

        private void LogException(string methodName, Exception ex)
        {
            // Fire-and-forget logging
            _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, methodName, ex);
        }

        public async Task LoadPeopleAsync()
        {

            try
            {

                var result = await _personService.GetAllPeopleAsync();

                People!.Clear();

                string methodMessage = string.Empty;

                if (result.IsSuccess)
                {


                    foreach (var person in result.Data ?? new List<PersonListDTO>())
                        People!.Add(person);

                    methodMessage = result.StatusCode switch
                    {
                        HttpStatusCode.OK => "The person list has been loaded successfully.",
                        HttpStatusCode.NoContent => "There is no data to display at the moment.",
                        _ => result.Message
                    };

                }
                else
                    methodMessage = result.Message;


                    NotifyOperationCompleted(enOperationType.LoadAll, methodMessage, result.IsSuccess, result.StatusCode);

            }
            catch(Exception ex) 
            {
                People!.Clear();

                LogException(nameof(LoadPeopleAsync), ex);

                NotifyOperationFailed(enOperationType.LoadAll, "Failed to load the person list. Please try again later.");
            }
        }

        public async Task<PersonDTO?> GetPersonByIDAsync(int ID)
        {
            try
            {
                var result = await _personService.GetPersonByIDAsync(ID);

                if (result.IsSuccess && result.Data != null)
                {
                    NotifyOperationCompleted(enOperationType.LoadSingle,$"Person with ID {ID} has been loaded successfully.",true,result.StatusCode);

                    return result.Data;
                }
                else
                {
                    NotifyOperationCompleted(enOperationType.LoadSingle, $"Failed to load person with ID {ID}: {result.Message}", false, result.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogException(nameof(GetPersonByIDAsync), ex);

                NotifyOperationFailed(enOperationType.LoadSingle, $"Exception occurred while loading person with ID {ID}.");

                return null;
            }
        }

        public async Task<bool> IsPersonExistAsync(int ID)
        {
            try
            {
                var result = await _personService.GetPersonByIDAsync(ID);

                if (result.IsSuccess && result.Data != null)
                {
                    NotifyOperationCompleted(enOperationType.CheckExistence, $"Person with ID {ID} exists.", true, result.StatusCode);
                    return true;
                }
                else
                {
                    NotifyOperationCompleted(enOperationType.CheckExistence, $"Person with ID {ID} does not exist or failed to fetch.", false, result.StatusCode);
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogException(nameof(IsPersonExistAsync), ex);

                NotifyOperationFailed(enOperationType.CheckExistence, $"Exception occurred while checking existence for person ID {ID}.");

                return false;
            }
        }

        public async Task<int?> AddPersonAsync(CreatePersonWithImageDTO newPerson)
        {
            try
            {
                var result = await _personService.AddPersonAsync(newPerson);

                if (result.IsSuccess )
                {
                    var newPersonListDto = _mapper.Map<PersonListDTO>(newPerson);
                    newPersonListDto.PersonID = result.Data;

                    People?.Add(newPersonListDto); 

                    NotifyOperationCompleted(enOperationType.Create, $"The person has been added successfully, and his id = {result.Data}"
                        ,true,result.StatusCode);

                    return result.Data;  
                }
                else
                {
                    NotifyOperationCompleted(enOperationType.Create,$"Failed to add person : {result.Message}",false,result.StatusCode);

                    return null;
                }
            }
            catch (Exception ex)
            { 
                LogException(nameof(AddPersonAsync), ex);

                NotifyOperationFailed(enOperationType.Create,$"Exception occurred while adding a person.");

                return null;
            }
        }

        public async Task<bool> UpdatePersonAsync(int personID, UpdatePersonWithImageDTO personToUpdate)
        {

            try
            {
                var result = await _personService.UpdatePersonAsync(personID, personToUpdate);

                if (result.IsSuccess)
                {

                    var personInList = People?.FirstOrDefault(p => p.PersonID == personID);
                    if (personInList != null)
                    {
                        int index = People!.IndexOf(personInList);
                        _mapper.Map(personToUpdate, personInList);  
                        People.ResetItem(index);

                    }

                    NotifyOperationCompleted(enOperationType.Update, $"Person with id [{personID}] has been updated successfully.", true, result.StatusCode);
                    return result.Data;
                }
                else
                {
                    NotifyOperationCompleted(
                        enOperationType.Update,
                        $"Failed to update person with id [{personID}]: {result.Message}",
                        false,
                        result.StatusCode);

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogException(nameof(UpdatePersonAsync), ex);

                NotifyOperationFailed(enOperationType.Update,$"Exception occurred while updating person with id [{personID}].");

                return false;
            }
        }

        public async Task<bool> DeletePersonAsync(int personID)
        {
            try
            {
                var result = await _personService.DeletePersonAsync(personID);

                if (result.IsSuccess)
                {
                    if (result.Data is true)
                    {
                        // نحاول حذف الشخص من القائمة
                        var personInList = People?.FirstOrDefault(p => p.PersonID == personID);
                        if (personInList != null)
                            People!.Remove(personInList);                       
                    }

                    NotifyOperationCompleted(enOperationType.Delete,$"Person with ID {personID} has been deleted successfully.",true,result.StatusCode);

                    return result.Data;
                }
                else
                {
                    NotifyOperationCompleted(enOperationType.Delete, $"Failed to delete person with ID {personID}: {result.Message}",false,result.StatusCode);

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogException(nameof(DeletePersonAsync), ex);

                NotifyOperationFailed(enOperationType.Delete,$"Exception occurred while deleting person with ID {personID}.");

                return false;
            }
        }

    }
}
