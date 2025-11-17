using CoreLayer.Common;
using CoreLayer.DTOs.PersonDTOs;

namespace CoreLayer.Interfaces.IPerson
{
    public interface IPersonService
    {
        Task<OperationResult<IEnumerable<PersonListDTO>>> GetPeopleAsync();
        Task<OperationResult<PersonDTO>> GetByIdAsync(int personID);
        Task<OperationResult<int>> AddAsync(CreatePersonDTO addPersonDTO);
        Task<OperationResult<bool>> UpdateAsync(int personID,UpdatePersonDTO updatePersonDTO);
        Task<OperationResult<bool>> DeletePersonAsync(int personID);
        Task<OperationResult<bool>> ExistsAsync(int personID);
        public Task<OperationResult<string?>> GetImageNameByIdAsync(int personID);
    }
}
