

using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.MemberDTOs
{
    public class UpdateMemberDTO
    {

        [Range(1, int.MaxValue, ErrorMessage = "Personal Trainer ID must be greater than 0.")]
        public int? PersonalTrainerId { get; set; }

        public bool IsActive { get; set; }

    }
}
