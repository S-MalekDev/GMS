

namespace CoreLayer.Entities
{
    public class SubscriptionDetail
    {
        public int Id { get; set; }

        public int? SubscriptionOfferId { get; set; }

        public int SubscriptionTypeId { get; set; }

        public int SubscriptionId { get; set; }

        public decimal SubscriptionMonthlyPrice { get; set; }

        public decimal SingleSessionPrice { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal AmountDue { get; set; }

        public Subscription Subscription { get; set; } = null!;

        public SubscriptionOffer? SubscriptionOffer { get; set; }

        public SubscriptionType SubscriptionType { get; set; } = null!;
    }
}
