using System.ComponentModel.DataAnnotations;
using CoreLayer.Enums.SubscriptionType;

namespace CoreLayer.DTOs.SubscriptionTypeDTOs
{
    public class UpdateSubscriptionTypeDTO
    {
        [Required(ErrorMessage = "Program type ID is required.")]
        [Range(1, short.MaxValue, ErrorMessage = "Program type ID must be a positive number.")]
        public short ProgramTypeId { get; set; }

        [Required(ErrorMessage = "Subscription period is required.")]
        public SubscriptionPariod SubscriptionPariod { get; set; }

        [Required(ErrorMessage = "Number of months is required.")]
        [Range(0, 120, ErrorMessage = "Number of months must be between 0 and 120.")]
        public byte NumberOfMonths { get; set; }

        [Required(ErrorMessage = "Number of days is required.")]
        [Range(0, 365, ErrorMessage = "Number of days must be between 0 and 365.")]
        public short NumberOfDays { get; set; }

        [Required(ErrorMessage = "Sessions count is required.")]
        [Range(1, 1000, ErrorMessage = "Sessions count must be between 1 and 1000.")]
        public short SessionsCount { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Current price is required.")]
        [Range(0, 100000, ErrorMessage = "Current price must be between 0 and 100,000.")]
        [DataType(DataType.Currency)]
        public decimal CurrentPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
