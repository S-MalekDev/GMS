using CoreLayer.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.UserDTOs
{
    public class AddUserDTO
    {
        [Required(ErrorMessage = "The person id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The person id must be greater than 0.")]
        public int PersonID { get; set; }

        [ValidUserIdAttribute]
        public int? CreatedByUserID { get; set; }

        [Required(ErrorMessage = "The username is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 20 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "The password is required.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 20 characters.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "The permissions are required.")]
        public int Parmissions { get; set; }

        public bool IsActive { get; set; }
    }
}
