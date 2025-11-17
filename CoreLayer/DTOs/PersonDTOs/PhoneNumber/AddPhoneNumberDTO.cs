
using System.ComponentModel.DataAnnotations;


namespace CoreLayer.DTOs.PersonDTOs.PhoneNumber
{
    public class AddPhoneNumberDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "PersonID must be a positive number.")]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 20 characters.")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
