using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.UserDTOs
{
    public class UpdatePasswordDTO
    {
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "PasswordHash must be between 2 and 200 characters.")]
        public string NewPassword { get; set; } = string.Empty;
    }
}
