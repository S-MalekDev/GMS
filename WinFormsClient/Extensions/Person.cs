using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.DTOs.PersonDTOs;

namespace WinFormsClient.Extensions
{
    static public class Person
    {
        public static string GetFullName(this PersonDTO personDTO)
        {
            string middleName = personDTO.MiddleName is null ? "" : personDTO.MiddleName;
            string fullName = personDTO.FirstName + " " + middleName + " " + personDTO.LastName;
            return fullName.Replace("  ", " ");
        }
        public static string GetGenderText(this PersonDTO personDTO)
        {
            return personDTO.Gender ? "Male" : "Female";
        }
        public static string GetNoPhoneOrOnePhoneIfExists(this PersonDTO personDTO)
        {
            return personDTO.PhoneNumbers.Count > 0 ? 
                personDTO.PhoneNumbers.First().PhoneNumber : "No phone number.";
        }
    }
}
