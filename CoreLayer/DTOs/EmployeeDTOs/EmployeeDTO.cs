using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.EmployeeDTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        public int PersonId { get; set; }

        public short JobId { get; set; }

        public int CreatedByUserId { get; set; }

        public DateOnly HireDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }
    }
}
