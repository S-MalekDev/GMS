using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.Interfaces.IPerson
{
    public interface IPersonWithImageDTO
    {
        public string FirstName { get; set; } 
        public string? MiddleName { get; set; }
        public string LastName { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string? Email { get; set; }
        public string? ImageFilePath { get; set; }
    }
}
