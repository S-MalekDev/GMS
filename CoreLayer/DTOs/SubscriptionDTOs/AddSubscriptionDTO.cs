using CoreLayer.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.SubscriptionDTOs
{
    public class AddSubscriptionDTO
    {
        [Required(ErrorMessage = "Member ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Member ID must be a positive number.")]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Subscription type ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Subscription type ID must be a positive number.")]
        public int SubscriptionTypeID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Subscription offer ID must be a positive number.")]
        public int? SubscriptionOfferID { get; set; } = null;

        [Required(ErrorMessage = "Created by user ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Created by user ID must be a positive number.")]
        public int CreatedByUserID { get; set; }
        
        [Required(ErrorMessage = "Start date is required.")]
        [FutureOrTodayDate(errorMassage: "The start date cann't be in the past")]
        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }
    }
}
