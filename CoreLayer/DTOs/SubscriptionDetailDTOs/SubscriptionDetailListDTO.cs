

namespace CoreLayer.DTOs.SubscriptionDetailDTOs
{
    public class SubscriptionDetailListDTO
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal AmountDue { get; set; }
    }
}
