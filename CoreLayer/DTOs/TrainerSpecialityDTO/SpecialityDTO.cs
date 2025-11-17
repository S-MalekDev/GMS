using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.TrainerSpecialityDTO
{
    public class SpecialityDTO
    {
        public short SpecialityId { get; set; }

        public string SpecialityName { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
