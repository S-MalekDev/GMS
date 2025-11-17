
namespace CoreLayer.Entities
{
    public class Person
    {
        public  int PersonID { get; set; }
        public  string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public  string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string? Email { get; set; }
        public string? ImageName { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    }
}
