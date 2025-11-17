using System.ComponentModel.DataAnnotations;

namespace APILayer.DTOs.Person
{
    public class UpdatePersonWithImageDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be 50 characters or fewer.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "First name must contain only letters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Middle name must be 50 characters or fewer.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Middle name must contain only letters.")]
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be 50 characters or fewer.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last name must contain only letters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, ErrorMessage = "Email must be 100 characters or fewer.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        // Image is optional but can be validated in controller
        [Display(Name = "Profile Image")]
        public IFormFile? Image { get; set; }
    }
}
