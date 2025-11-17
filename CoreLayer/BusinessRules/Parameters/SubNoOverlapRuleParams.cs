
namespace CoreLayer.IBusinessRules.Parameters
{
    public class SubNoOverlapRuleParams
    {
        public int memberId {  get; set; }
        public DateOnly StartDate { get; set; }
        public int SubscriptionTypeId { get; set; }
    }
}
