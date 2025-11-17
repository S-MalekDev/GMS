

using System.ComponentModel;
using WinFormsClient.DTOs.PersonDTOs.PhoneNumberDTOs;
using WinFormsClient.Events;

namespace WinFormsClient.Interfaces.IPerson
{
    public interface IPhoneNumberViewModel
    {
        BindingList<PhoneNumberListDTO> PhoneNumbers { get; }

        event EventHandler<OperationCompletedEventArgs>? OperationCompleted;
        event EventHandler<OperationFailedEventArgs>? OperationFailed;

        Task LoadAllAsync();
        Task<int?> AddAsync(AddPhoneNumberDTO phoneNumberToAdd);
        Task<bool> AddRangeAsync(ICollection<AddPhoneNumberDTO> phoneNumbersToAdd);
        Task<bool> DeleteAsync(int id);
        Task<PhoneNumberDTO?> GetByIdAsync(int id);
        Task<List<PhoneNumberDTO>> GetByPersonIdAsync(int personId);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByPhoneNumberAsync(string phoneNumber);
        Task<bool> UpdateAsync(int id, UpdatePhoneNumberDTO phoneNumberToUpdate);
    }
}
