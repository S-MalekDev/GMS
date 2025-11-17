using CoreLayer.Common;
using CoreLayer.DTOs.PersonDTOs.PhoneNumber;
using CoreLayer.Entities;


namespace CoreLayer.Interfaces.IPerson.Phone
{
    public interface IPhoneNumberService
    {
        Task<OperationResult<IEnumerable<PhoneNumberListDTO>>> GetAllAsync();
        Task<OperationResult<PhoneNumberDTO>> GetByIdAsync(int phoneNumberId);
        Task<OperationResult<IEnumerable<PhoneNumberDTO>>> GetByPersonIdAsync(int personId);
        Task<OperationResult<int>> AddAsync(AddPhoneNumberDTO phoneNumberToCreate);
        Task<OperationResult<bool>> UpdateAsync(int phoneNumberId, UpdatePhoneNumberDTO phoneNumberToUpdate);
        Task<OperationResult<bool>> DeleteAsync(int phoneNumberId);
        Task<OperationResult<bool>> ExistsByIdAsync(int phoneNumberId);
        Task<OperationResult<bool>> ExistsByPhoneNumberAsync(string phoneNumber);
    }
}
