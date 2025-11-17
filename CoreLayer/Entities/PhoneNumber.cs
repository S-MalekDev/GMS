

using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    public class PhoneNumber
    {
        public int PhoneNumberID { get; set; }
        public int PersonID { get; set; }

        [Column("PhoneNumber")]
        public string Number {  get; set; } = string.Empty;
    }
}
