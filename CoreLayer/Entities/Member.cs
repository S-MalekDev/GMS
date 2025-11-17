using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class Member
    {
        public int MemberId { get; set; }

        public int PersonId { get; set; }

        public int? PersonalTrainerId { get; set; }

        public int CreatedByUserId { get; set; }

        public DateOnly EnrollmentDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        // Navigation Properties;
        public Person Person { get; set; } = null!;
        public User CreatedBy { get; set; } = null!;
        public Trainer PersonalTrainer { get; set; } = null!;
    }
}
