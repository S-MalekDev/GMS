using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.EmployeeDTOs
{
    public class AddEmployeeDTO
    {
        [Required(ErrorMessage = "Person ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Person ID must be a positive number.")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Job ID is required.")]
        [Range(1, short.MaxValue, ErrorMessage = "Job ID must be a positive number.")]
        public short JobId { get; set; }

        [Required(ErrorMessage = "Created By User ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Created By User ID must be a positive number.")]
        public int CreatedByUserId { get; set; }

        [Required(ErrorMessage = "Hire Date is required.")]
        public DateOnly HireDate { get; set; }

        public DateOnly? EndDate { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Salary must be zero or a positive number.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "IsActive status is required.")]
        public bool IsActive { get; set; }
    }
}
