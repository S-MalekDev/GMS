using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.JobDTOs
{
    public class JobListDTO
    {
        public short JobId { get; set; }

        public string JobTitle { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
