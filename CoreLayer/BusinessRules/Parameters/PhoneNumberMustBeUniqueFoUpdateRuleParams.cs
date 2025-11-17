

namespace CoreLayer.BusinessRules.Parameters
{
    public class PhoneNumberMustBeUniqueFoUpdateRuleParams
    {
       public int PhoneNumberId { get; set; }
        public string PhoneNumber {  get; set; } = string.Empty;
    }
}
