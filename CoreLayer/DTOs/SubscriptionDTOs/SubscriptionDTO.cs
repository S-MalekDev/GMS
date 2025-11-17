

using CoreLayer.Enums.SubscriptionStatus;

namespace CoreLayer.DTOs.SubscriptionDTOs
{
    public class SubscriptionDTO
    {
        public int SubscriptionId { get; set; }

        public int MemberId { get; set; }

        public int CreatedByUserId { get; set; }

        public byte AllowedSessionsCount { get; set; }

        public decimal? OriginalPrice { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public decimal? DiscountValue { get; set; }

        public decimal? FinalPaidAmount { get; set; }

        public DateOnly SubscriptionDate { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public byte RemainingSessions { get; set; }

        /// <summary>
        /// Cancelled = 0, Active = 1,Pending = 2, Expired = 3
        /// </summary>
        public SubscriptionStatus Status { get; set; }
    }
}
