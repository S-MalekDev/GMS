

namespace CoreLayer.Entities
{
    public class Subscription
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
        /// 0=&gt; Cancelled / 1=&gt; Active / 2=&gt; Pending / 3=&gt; Expired 
        /// </summary>
        public byte Status { get; set; }

        // Navigation Properties.

        public Member Member { get; set; } = null!;
        public User CreatedByUser { get; set; } = null!;
        public ICollection<SubscriptionDetail> subscriptionDetails { get; set; } = new List<SubscriptionDetail>();

    }
}
