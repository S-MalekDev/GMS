using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.MemberDTOs
{
    public class AddMemberDTO
    {
        [Required(ErrorMessage = "Person ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Person ID must be greater than 0.")]
        public int PersonId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Personal Trainer ID must be greater than 0.")]
        public int? PersonalTrainerId { get; set; }

        [Required(ErrorMessage = "Created By User ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Created By User ID must be greater than 0.")]
        public int CreatedByUserId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
