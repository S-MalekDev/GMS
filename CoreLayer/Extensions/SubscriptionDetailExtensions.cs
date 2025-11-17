using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Extensions
{
    public static class SubscriptionDetailExtensions
    {
        public static void UpdateFrom(this SubscriptionDetail subscriptionDetail, SubscriptionDetail subscriptionDetailToUpdateFrom)
        {
            subscriptionDetail.Id = subscriptionDetailToUpdateFrom.Id;
            subscriptionDetail.SubscriptionOfferId = subscriptionDetailToUpdateFrom.SubscriptionOfferId;
            subscriptionDetail.SubscriptionTypeId = subscriptionDetailToUpdateFrom.SubscriptionTypeId;
            subscriptionDetail.SubscriptionId = subscriptionDetailToUpdateFrom.SubscriptionId;
            subscriptionDetail.SubscriptionMonthlyPrice = subscriptionDetailToUpdateFrom.SubscriptionMonthlyPrice;
            subscriptionDetail.SingleSessionPrice = subscriptionDetailToUpdateFrom.SingleSessionPrice;
            subscriptionDetail.OriginalPrice = subscriptionDetailToUpdateFrom.OriginalPrice;
            subscriptionDetail.DiscountPercentage = subscriptionDetailToUpdateFrom.DiscountPercentage;
            subscriptionDetail.DiscountValue = subscriptionDetailToUpdateFrom.DiscountValue;
            subscriptionDetail.AmountDue = subscriptionDetailToUpdateFrom.AmountDue;
    }
    }
}
