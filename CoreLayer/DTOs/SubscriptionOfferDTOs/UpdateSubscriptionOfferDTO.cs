
using CoreLayer.Enums.SubscriptionOffer;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.SubscriptionOfferDTOs
{
    public class UpdateSubscriptionOfferDTO
    {
        [Required(ErrorMessage = "Subscription type ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Subscription type ID must be a positive number.")]
        public int SubscriptionTypeId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 characters.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Discount percentage is required.")]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        public decimal DiscountPercentage { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }


        [DataType(DataType.Date)]
        public DateOnly? EndDate { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 200 characters.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Status is required.")]
        public SubscriptionOfferStatus Status { get; set; }
    }
}
