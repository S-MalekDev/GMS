using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Attributes
{
    public class FutureOrTodayDateAttribute : ValidationAttribute
    {
        public FutureOrTodayDateAttribute(string errorMassage = "The date cannot be in the past.")
        {
            ErrorMessage = errorMassage;
        }
        public override bool IsValid(object? value)
        {
            if(value is DateOnly date)
                return date >= DateOnly.FromDateTime(DateTime.Today);

            return true;
        }
    }
}
