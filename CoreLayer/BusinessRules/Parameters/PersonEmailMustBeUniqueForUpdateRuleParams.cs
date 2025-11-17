
namespace CoreLayer.BusinessRules.Parameters
{
    public class PersonEmailMustBeUniqueForUpdateRuleParams
    {
        public int PersonId { get; set; }
        public string? Email { get; set; } = null!;
    }
}
