using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.MemberDTOs
{
    public class MemberListDTO
    {
        public int MemberId { get; set; }

        public string FullName { get; set; } = null!;

        public string PersonalTrainerFullName { get; set; } = null!;

        public DateOnly EnrollmentDate { get; set; }

        public bool IsActive { get; set; }

    }
}
