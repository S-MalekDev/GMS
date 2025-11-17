

namespace CoreLayer.DTOs.SubscriptionDetailDTOs
{
    public class SubscriptionDetailDTO
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
    }
}
