
using CoreLayer.Enums.SubscriptionType;

namespace CoreLayer.DTOs.SubscriptionTypeDTOs
{
    public class SubscriptionTypeDTO
    {
        public int SubscriptionTypeId { get; set; }

        public short ProgramTypeId { get; set; }

        public SubscriptionPariod SubscriptionPariod { get; set; }

        public byte NumberOfMonths { get; set; }

        public short NumberOfDays { get; set; }

        public short SessionsCount { get; set; }

        public string Description { get; set; } = null!;

        public decimal CurrentPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
