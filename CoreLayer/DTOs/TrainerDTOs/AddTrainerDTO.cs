using System.ComponentModel.DataAnnotations;

public class AddTrainerDTO
{

    [Display(Name = "Employee ID")]
    [Required(ErrorMessage = "{0} is required.")]
    public int EmployeeId { get; set; }

    [Display(Name = "Speciality ID")]
    [Required(ErrorMessage = "{0} is required.")]
    public short SpecialityId { get; set; }

    [Display(Name = "Created By User ID")]
    [Required(ErrorMessage = "{0} is required.")]
    public int CreatedByUserId { get; set; }

    [Display(Name = "Experience (in years)")]
    [Required(ErrorMessage = "{0} is required.")]
    [Range(0, 50, ErrorMessage = "{0} must be between {1} and {2}.")]
    public byte ExperienceYears { get; set; }

    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
}
