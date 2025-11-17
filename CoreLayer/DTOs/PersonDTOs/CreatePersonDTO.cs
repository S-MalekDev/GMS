using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.PersonDTOs
{
    public class CreatePersonDTO
    {

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Middle name cannot exceed 50 characters")]
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; } = null;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; } = null;

        [StringLength(100, ErrorMessage = "Image name cannot exceed 255 characters")]
        [Display(Name = "Image File Name")]
        public string? ImageName { get; set; } = null;
    }
}
