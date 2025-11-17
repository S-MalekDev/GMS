using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        public int EmployeeId { get; set; }

        public short SpecialityId { get; set; }

        public int CreatedByUserId { get; set; }

        public byte ExperienceYears { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }


        // Navigation Properties:

        public Employee EmployeeInfo { get; set; } = null!;
        public User CreatedBy { get; set; } = null!;
        public Speciality SpecialityInfo { get; set; } = null!;
        public ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
