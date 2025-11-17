using WinFormsClient.DTOs.PersonDTOs;
using WinFormsClient.Helpers;

namespace WinFormsClient.Interfaces.IPerson
{
    public interface IPersonService
    {
        Task<OperationResult<List<PersonListDTO>>> GetAllPeopleAsync();
        Task<OperationResult<PersonDTO>> GetPersonByIDAsync(int ID);
        Task<OperationResult<bool>> IsPersonExistAsync(int ID);
        Task<OperationResult<int>> AddPersonAsync(CreatePersonWithImageDTO personWithImage);
        Task<OperationResult<bool>> UpdatePersonAsync(int ID, UpdatePersonWithImageDTO personToUpdate);
        Task<OperationResult<bool>> DeletePersonAsync(int personID);
    }
}
