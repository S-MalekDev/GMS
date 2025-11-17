using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.TrainerSpecialityDTO
{
    public class UpdateSpecialityDTO
    {

        [Required(ErrorMessage = "Speciality name is required.")]
        [MaxLength(50, ErrorMessage = "Speciality name cannot exceed 50 characters.")]
        [Display(Name = "Speciality Name")]
        public string SpecialityName { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;
    }
}
