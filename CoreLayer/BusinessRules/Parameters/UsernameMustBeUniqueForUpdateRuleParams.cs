

namespace CoreLayer.BusinessRules.Parameters
{
    public class UsernameMustBeUniqueForUpdateRuleParams
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
