

using CoreLayer.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.SubscriptionDTOs
{
    public class UpdatePendingSubsPeriodDTO
    {
        [Required(ErrorMessage = "Start date is required.")]
        [FutureOrTodayDate(errorMassage: "The start date cann't be in the past")]
        [DataType(DataType.Date)]
        public DateOnly StartDate {  get; set; }
    }
}
