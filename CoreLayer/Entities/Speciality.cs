using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class Speciality
    {
        public short SpecialityId { get; set; }

        public string SpecialityName { get; set; } = null!;

        public string Description { get; set; } = null!;

        // Navigation Properties:
        public virtual ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
