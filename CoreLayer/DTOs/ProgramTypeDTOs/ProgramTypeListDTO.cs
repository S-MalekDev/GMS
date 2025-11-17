

namespace CoreLayer.DTOs.ProgramTypeDTOs
{
    public class ProgramTypeListDTO
    {
        public short ProgramTypeId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal SubscriptionMonthlyPrice { get; set; }

        public decimal SingleSissionPrice { get; set; }
    }
}
