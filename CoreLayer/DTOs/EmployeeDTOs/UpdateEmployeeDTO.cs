using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.EmployeeDTOs
{
    public class UpdateEmployeeDTO
    {

        [Required(ErrorMessage = "Job ID is required.")]
        [Range(1, short.MaxValue, ErrorMessage = "Job ID must be a positive number.")]
        public short JobId { get; set; }


        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Salary must be zero or a positive number.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "IsActive status is required.")]
        public bool IsActive { get; set; }
    }
}
