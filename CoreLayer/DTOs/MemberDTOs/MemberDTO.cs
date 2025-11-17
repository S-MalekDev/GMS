using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.MemberDTOs
{
    public class MemberDTO
    {
        public int MemberId { get; set; }

        public int PersonId { get; set; }

        public int? PersonalTrainerId { get; set; }

        public int CreatedByUserId { get; set; }

        public DateOnly EnrollmentDate { get; set; }

        public bool IsActive { get; set; }

    }
}
