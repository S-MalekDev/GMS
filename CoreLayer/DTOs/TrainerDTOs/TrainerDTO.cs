using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.TrainerDTOs
{
    public class TrainerDTO
    {
        public int TrainerId { get; set; }

        public int EmployeeId { get; set; }

        public short SpecialityId { get; set; }

        public int CreatedByUserId { get; set; }

        public byte ExperienceYears { get; set; }

        public bool IsActive { get; set; }
    }
}
