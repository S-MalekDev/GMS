using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.PersonDTOs.PhoneNumber
{
    public  class PhoneNumberDTO
    {
        public int PhoneNumberID { get; set; }
        public int PersonID { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
