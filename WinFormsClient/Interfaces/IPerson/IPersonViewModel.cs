using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.DTOs.PersonDTOs;
using WinFormsClient.Events;

namespace WinFormsClient.Interfaces.IPerson
{
    public interface IPersonViewModel
    {
        BindingList<PersonListDTO>? People { get; }

        event EventHandler<OperationCompletedEventArgs>? OperationCompleted;
        event EventHandler<OperationFailedEventArgs>? OperationFailed;

        Task LoadPeopleAsync();
        Task<PersonDTO?> GetPersonByIDAsync(int ID);
        Task<bool> IsPersonExistAsync(int ID);
        Task<int?> AddPersonAsync(CreatePersonWithImageDTO newPerson);
        Task<bool> UpdatePersonAsync(int personID, UpdatePersonWithImageDTO personToUpdate);
        Task<bool> DeletePersonAsync(int personID);
    }
}
