
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    public class SubscriptionOffer
    {
        [Key]
        public int OfferId { get; set; }

        public int SubscriptionTypeId { get; set; }

        public string Title { get; set; } = null!;

        public decimal DiscountPercentage { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public string Description { get; set; } = null!;

        /// <summary>
        /// 0=&gt; Pending / 1=&gt; Active / 2=&gt; Expired / 3=&gt; Cancelled
        /// </summary>
        public byte Status { get; set; }

        public  SubscriptionType SubscriptionType { get; set; } = null!;
    }
}
