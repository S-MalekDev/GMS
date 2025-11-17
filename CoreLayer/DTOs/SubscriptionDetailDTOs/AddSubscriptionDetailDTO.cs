using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.SubscriptionDetailDTOs
{
    public class AddSubscriptionDetailDTO
    {
        [Required(ErrorMessage = "Subscription ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Subscription ID must be a positive number.")]
        public int SubscriptionID { get; set; }

        [Required(ErrorMessage = "Subscription type ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Subscription type ID must be a positive number.")]
        public int SubscriptionTypeID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Subscription offer ID must be a positive number.")]
        public int? SubscriptionOfferID { get; set; } = null;
    }
}
