
using System.ComponentModel.DataAnnotations;


namespace CoreLayer.Attributes
{
    public class ValidUserIdAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null)
                return ValidationResult.Success;

            if(value is int id && id > 0)
                return ValidationResult.Success;

            return new ValidationResult("The user id must be greater than 0.");
        }
    }
}
