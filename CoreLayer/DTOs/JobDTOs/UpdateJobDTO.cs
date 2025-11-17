using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.JobDTOs
{
    public class UpdateJobDTO
    {
        [Required(ErrorMessage = "Job title is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Job title must be between 2 and 100 characters.")]
        public string JobTitle { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
        public string Description { get; set; } = null!;
    }
}
