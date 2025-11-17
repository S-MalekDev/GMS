
using System.ComponentModel.DataAnnotations;


namespace CoreLayer.DTOs.PersonDTOs.PhoneNumber
{
    public class UpdatePhoneNumberDTO
    {
        [StringLength(maximumLength:20, MinimumLength = 10, ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
