

using WinFormsClient.DTOs.PersonDTOs.PhoneNumberDTOs;

namespace WinFormsClient.DTOs.PersonDTOs
{
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<PersonPhoneNumberDTO> PhoneNumbers { get; set; } = new List<PersonPhoneNumberDTO>();
    }
}
