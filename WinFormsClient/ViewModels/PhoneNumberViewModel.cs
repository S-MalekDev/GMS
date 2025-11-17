using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using WinFormsClient.DTOs.PersonDTOs.PhoneNumberDTOs;
using WinFormsClient.Enums.EnLogging;
using WinFormsClient.Enums.Operations;
using WinFormsClient.Events;
using WinFormsClient.Interfaces.ILogging;
using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.ViewModels
{
    public class PhoneNumberViewModel : IPhoneNumberViewModel
    {
        private readonly IPhoneNumberService _phoneService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BindingList<PhoneNumberListDTO> PhoneNumbers { get; } = new();

        public event EventHandler<OperationCompletedEventArgs>? OperationCompleted;
        public event EventHandler<OperationFailedEventArgs>? OperationFailed;

        public PhoneNumberViewModel(IPhoneNumberService phoneService, ILoggerManager logger, IMapper mapper)
        {
            _phoneService = phoneService;
            _logger = logger;
            _mapper = mapper;
        }

        private void NotifyCompleted(enOperationType op, string msg, bool ok, HttpStatusCode code)
            => OperationCompleted?.Invoke(this, new OperationCompletedEventArgs(op, msg, ok, code));

        private void NotifyFailed(enOperationType op, string msg)
            => OperationFailed?.Invoke(this, new OperationFailedEventArgs(op, msg));

        private void Log(string method, Exception ex)
        {
            _ = _logger.LogWithFallbackAsync(enLogEntryType.Error, method, ex);
        }

        public async Task LoadAllAsync()
        {
            try
            {
                var res = await _phoneService.GetAllAsync();
                PhoneNumbers.Clear();

                if (res.IsSuccess && res.Data != null)
                {
                    foreach (var dto in res.Data)
                        PhoneNumbers.Add(dto);

                    var msg = res.StatusCode == HttpStatusCode.OK
                        ? "Phone numbers loaded."
                        : "No phone numbers available.";
                    NotifyCompleted(enOperationType.LoadAll, msg, true, res.StatusCode);
                }
                else
                {
                    NotifyCompleted(enOperationType.LoadAll, $"Failed: {res.Message}", false, res.StatusCode);
                }
            }
            catch (Exception ex)
            {
                PhoneNumbers.Clear();
                Log(nameof(LoadAllAsync), ex);
                NotifyFailed(enOperationType.LoadAll, "Error loading phone numbers.");
            }
        }

        public async Task<int?> AddAsync(AddPhoneNumberDTO phoneNumberToAdd)
        {
            try
            {
                var res = await _phoneService.AddPhoneNumberAsync(phoneNumberToAdd);
                if (res.IsSuccess)
                {
                    NotifyCompleted(enOperationType.Create, $"Added new phone id {res.Data}", true, res.StatusCode);
                    return res.Data;
                }

                NotifyCompleted(enOperationType.Create, $"Failed to add: {res.Message}", false, res.StatusCode);
                return null;
            }
            catch (Exception ex)
            {
                Log(nameof(AddAsync), ex);
                NotifyFailed(enOperationType.Create, "Exception while adding phone number.");
                return null;
            }
        }

        public async Task<bool> AddRangeAsync(ICollection<AddPhoneNumberDTO> phoneNumbersToAdd)
        {
            bool isAllAdded = true;

            foreach (var phoneToAdd in phoneNumbersToAdd)
            {
                var result = await _phoneService.AddPhoneNumberAsync(phoneToAdd);
                if (!result.IsSuccess) 
                    isAllAdded = false;
            }
            return isAllAdded;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var res = await _phoneService.DeleteAsync(id);

                if (res.IsSuccess)
                {
                    var found = PhoneNumbers.FirstOrDefault(p => p.PhoneNumberID == id);
                    if (found != null) PhoneNumbers.Remove(found);

                    NotifyCompleted(enOperationType.Delete, $"Deleted phone id {id}.", true, res.StatusCode);
                    return true;
                }

                NotifyCompleted(enOperationType.Delete, $"Failed to delete: {res.Message}", false, res.StatusCode);
                return false;
            }
            catch (Exception ex)
            {
                Log(nameof(DeleteAsync), ex);
                NotifyFailed(enOperationType.Delete, "Exception while deleting phone number.");
                return false;
            }
        }

        public async Task<PhoneNumberDTO?> GetByIdAsync(int id)
        {
            try
            {
                var res = await _phoneService.GetPhoneByIdAsync(id);

                if (res.IsSuccess && res.Data != null)
                {
                    NotifyCompleted(enOperationType.LoadSingle, $"Phone number with id {id} loaded.", true, res.StatusCode);
                    return res.Data;
                }

                NotifyCompleted(enOperationType.LoadSingle, $"Failed to load phone number {id}: {res.Message}", false, res.StatusCode);
                return null;
            }
            catch (Exception ex)
            {
                Log(nameof(GetByIdAsync), ex);
                NotifyFailed(enOperationType.LoadSingle, "Error loading phone number.");
                return null;
            }
        }

        public async Task<List<PhoneNumberDTO>> GetByPersonIdAsync(int personId)
        {
            try
            {
                var res = await _phoneService.GetPhoneByPersonIdAsync(personId);

                if (res.IsSuccess && res.Data != null)
                {
                    NotifyCompleted(enOperationType.LoadByRelatedId, $"Phones of person {personId} loaded.", true, res.StatusCode);
                    return res.Data;
                }

                NotifyCompleted(enOperationType.LoadByRelatedId, $"Failed to load phones for person {personId}: {res.Message}", false, res.StatusCode);
                return new List<PhoneNumberDTO>();
            }
            catch (Exception ex)
            {
                Log(nameof(GetByPersonIdAsync), ex);
                NotifyFailed(enOperationType.LoadByRelatedId, "Error loading person's phone numbers.");
                return new List<PhoneNumberDTO>();
            }
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            try
            {
                var res = await _phoneService.ExistsByIdAsync(id);
                NotifyCompleted(enOperationType.CheckExistence, res.Data ? "Exists." : "Not found.", res.Data, res.StatusCode);
                return res.Data;
            }
            catch (Exception ex)
            {
                Log(nameof(ExistsByIdAsync), ex);
                NotifyFailed(enOperationType.CheckExistence, "Error checking existence by ID.");
                return false;
            }
        }

        public async Task<bool> ExistsByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                var res = await _phoneService.ExistsByPhoneNumberAsync(phoneNumber);
                NotifyCompleted(enOperationType.CheckExistence, res.Data ? "Phone exists." : "Not found.", res.Data, res.StatusCode);
                return res.Data;
            }
            catch (Exception ex)
            {
                Log(nameof(ExistsByPhoneNumberAsync), ex);
                NotifyFailed(enOperationType.CheckExistence, "Error checking existence by phone number.");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, UpdatePhoneNumberDTO dto)
        {
            try
            {
                var res = await _phoneService.UpdateAsync(id, dto);
                if (res.IsSuccess)
                {
                    NotifyCompleted(enOperationType.Update, $"Phone number {id} updated.", true, res.StatusCode);
                    return true;
                }

                NotifyCompleted(enOperationType.Update, $"Failed to update phone number {id}: {res.Message}", false, res.StatusCode);
                return false;
            }
            catch (Exception ex)
            {
                Log(nameof(UpdateAsync), ex);
                NotifyFailed(enOperationType.Update, "Error updating phone number.");
                return false;
            }
        }


    }
}
