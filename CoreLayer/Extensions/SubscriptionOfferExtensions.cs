using CoreLayer.Entities;
using CoreLayer.Enums.SubscriptionOffer;


namespace CoreLayer.Extensions
{
    public static class SubscriptionOfferExtensions
    {
        public static void UpdateFrom(this SubscriptionOffer subscriptionOffer, SubscriptionOffer subscriptionOfferToUpdateFrom)
        {
            
            subscriptionOffer.OfferId = subscriptionOfferToUpdateFrom.OfferId;
            subscriptionOffer.SubscriptionTypeId = subscriptionOfferToUpdateFrom.SubscriptionTypeId;
            subscriptionOffer.Title = subscriptionOfferToUpdateFrom.Title;
            subscriptionOffer.DiscountPercentage = subscriptionOfferToUpdateFrom.DiscountPercentage;
            subscriptionOffer.StartDate = subscriptionOfferToUpdateFrom.StartDate;
            subscriptionOffer.EndDate = subscriptionOfferToUpdateFrom.EndDate;
            subscriptionOffer.Description = subscriptionOfferToUpdateFrom.Description;
            subscriptionOffer.Status = subscriptionOfferToUpdateFrom.Status;

            if(subscriptionOfferToUpdateFrom.SubscriptionType is not null )
                subscriptionOffer.SubscriptionType.UpdateFrom(subscriptionOfferToUpdateFrom.SubscriptionType);
        }

        public static string GetStatusText(this  SubscriptionOffer subscriptionOffer)
        {
            var offerStatusEnum = (SubscriptionOfferStatus)subscriptionOffer.Status;

            return offerStatusEnum switch
            {
                SubscriptionOfferStatus.Expired => "Expired",
                SubscriptionOfferStatus.Cancelled => "Cancelled",
                SubscriptionOfferStatus.Pending => "Pending",
                SubscriptionOfferStatus.Active => "Active",
                _ => "Unknown"
            };
        }
    }
}
