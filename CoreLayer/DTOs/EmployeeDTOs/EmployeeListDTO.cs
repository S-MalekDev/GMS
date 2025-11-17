using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.EmployeeDTOs
{
    public class EmployeeListDTO
    {
        public int EmployeeId { get; set; }

        public int PersonId { get; set; }

        public string FullName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public DateOnly HireDate { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

    }
}
