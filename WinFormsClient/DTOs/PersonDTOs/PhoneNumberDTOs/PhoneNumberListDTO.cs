using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.DTOs.PersonDTOs.PhoneNumberDTOs
{
    public class PhoneNumberListDTO
    {
        public int PersonID { get; set; }
        public int PhoneNumberID { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
