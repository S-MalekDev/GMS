using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.TrainerDTOs
{
    public class TrainerListDTO
    {
        public int TrainerId { get; set; }

        public int EmployeeId { get; set; }

        public string FullName { get; set; } = null!;

        public string Speciality { get; set; } = null!;

        public byte ExperienceYears { get; set; }

        public bool IsActive { get; set; }

    }
}
