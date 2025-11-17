
namespace WinFormsClient.DTOs.PersonDTOs
{
    public class PersonListDTO
    {
        public int PersonID { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public string? Email { get; set; }
    }
}
