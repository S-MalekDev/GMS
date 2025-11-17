using WinFormsClient.DTOs.PersonDTOs.PhoneNumberDTOs;
using WinFormsClient.Helpers;

namespace WinFormsClient.Interfaces.IPerson
{
    public interface IPhoneNumberService
    {
        Task<OperationResult<List<PhoneNumberListDTO>>> GetAllAsync();
        Task<OperationResult<int>> AddPhoneNumberAsync(AddPhoneNumberDTO phoneNumberToAdd);
        Task<OperationResult<PhoneNumberDTO>> GetPhoneByIdAsync(int ID);
        Task<OperationResult<List<PhoneNumberDTO>>> GetPhoneByPersonIdAsync(int ID);
        Task<OperationResult<bool>> ExistsByIdAsync(int ID);
        Task<OperationResult<bool>> ExistsByPhoneNumberAsync(string phoneNumber);
        Task<OperationResult<bool>> UpdateAsync(int phoneNumberId, UpdatePhoneNumberDTO phoneNumberToUpdate);
        Task<OperationResult<bool>> DeleteAsync(int Id);
    }
}
