

using CoreLayer.Enums.SubscriptionStatus;

namespace CoreLayer.DTOs.SubscriptionDTOs
{
    public class SubscriptionListDTO
    {
        public int SubscriptionId { get; set; }

        public string MumberFullName { get; set; } = string.Empty;

        public decimal? PaidAmount { get; set; }

        public DateOnly SubscriptionDate { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public byte RemainingSessions { get; set; }

        /// <summary>
        /// Cancelled = 0, Active = 1,Pending = 2, Expired = 3
        /// </summary>
        public string Status { get; set; } = string.Empty;
    }
}
