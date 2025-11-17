using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Extensions
{
    public static class PersonExtensions
    {
        public static string GetFullName(this Person person)
        {
            string middleName = person.MiddleName is null ? "" : person.MiddleName;
            string fullName = person.FirstName + " " + middleName + " " + person.LastName;
            return fullName.Replace("  ", " ");
        }
        public static string GetGenderText(this Person person)
        {
            return person.Gender ? "Male" : "Female";
        }
    }
}
