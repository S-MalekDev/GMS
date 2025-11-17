
using CoreLayer.Enums.SubscriptionType;

namespace CoreLayer.DTOs.SubscriptionTypeDTOs
{
    public class SubscriptionTypeListDTO
    {
        public int SubscriptionTypeId { get; set; }

        public string ProgramType { get; set; } = null!;

        public string SubscriptionPariod { get; set; } = null!;

        public short SessionsCount { get; set; }

        public string Description { get; set; } = null!;

        public decimal CurrentPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
