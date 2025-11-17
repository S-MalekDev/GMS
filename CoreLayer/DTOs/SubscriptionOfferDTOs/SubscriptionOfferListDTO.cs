
using CoreLayer.Enums.SubscriptionOffer;

namespace CoreLayer.DTOs.SubscriptionOfferDTOs
{
    public class SubscriptionOfferListDTO
    {
        public int OfferId { get; set; }

        public int SubscriptionTypeId { get; set; }

        public string Title { get; set; } = null!;

        public decimal DiscountPercentage { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public string Description { get; set; } = null!;

        /// <summary>
        /// Pending = 0, Active = 1, Expired = 2 , Cancelled = 3
        /// </summary>
        public string Status { get; set; } = null!;
    }
}
