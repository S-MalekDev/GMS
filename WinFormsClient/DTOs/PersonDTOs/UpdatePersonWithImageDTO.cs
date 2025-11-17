

using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.DTOs.PersonDTOs
{
    public class UpdatePersonWithImageDTO: IPersonWithImageDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string? Email { get; set; }
        public string? ImageFilePath { get; set; }
    }
}
