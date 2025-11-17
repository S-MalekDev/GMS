
namespace CoreLayer.Entities
{
    public class SubscriptionType
    {
        public int SubscriptionTypeID { get; set; }

        public short ProgramTypeId { get; set; }

        public byte SubscriptionPariod { get; set; }

        public byte NumberOfMonths { get; set; }

        public short NumberOfDays { get; set; }

        public short SessionsCount { get; set; }

        public string Description { get; set; } = null!;

        public decimal CurrentPrice { get; set; }

        public bool IsActive { get; set; }

        public  ProgramType ProgramType { get; set; } = null!;
    }
}
