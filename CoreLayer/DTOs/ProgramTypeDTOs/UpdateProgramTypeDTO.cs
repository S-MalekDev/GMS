

using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.ProgramTypeDTOs
{
    public class UpdateProgramTypeDTO
    {
        [Required(ErrorMessage = "Program name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Program name must be between 3 and 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 200 characters.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Monthly subscription price is required.")]
        [Range(0, 100000, ErrorMessage = "Monthly subscription price must be between 0 and 100,000.")]
        [DataType(DataType.Currency)]
        public decimal SubscriptionMonthlyPrice { get; set; }

        [Required(ErrorMessage = "Single session price is required.")]
        [Range(0, 10000, ErrorMessage = "Single session price must be between 0 and 10,000.")]
        [DataType(DataType.Currency)]
        public decimal SingleSissionPrice { get; set; }
    }
}
