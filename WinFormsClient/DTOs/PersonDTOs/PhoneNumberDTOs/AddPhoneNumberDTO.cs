using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.DTOs.PersonDTOs.PhoneNumberDTOs
{
    public class AddPhoneNumberDTO
    {
        public int PersonID { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
