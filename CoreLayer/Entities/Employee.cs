using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public int PersonId { get; set; }

        public short JobId { get; set; }

        public int CreatedByUserId { get; set; }

        public DateOnly HireDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        // Navigation Properties:
        public Job? JobInfo { get; set; }

        public Person? PersonInfo { get; set; }

        public User? CreatedBy {  get; set; }
    }
}
