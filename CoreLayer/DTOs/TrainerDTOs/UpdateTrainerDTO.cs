using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.TrainerDTOs
{
    public class UpdateTrainerDTO
    {

        [Display(Name = "Speciality ID")]
        [Required(ErrorMessage = "{0} is required.")]
        public short SpecialityId { get; set; }


        [Display(Name = "Experience (in years)")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(0, 50, ErrorMessage = "{0} must be between {1} and {2}.")]
        public byte ExperienceYears { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
