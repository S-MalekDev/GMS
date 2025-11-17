

using CoreLayer.Entities;
using CoreLayer.Enums.SubscriptionStatus;

namespace CoreLayer.Extensions
{
    public static class SubscriptionExtensions
    {
        public static string GetStatusText(this Subscription subscription)
        {
            return subscription.Status switch
            {
                (byte)SubscriptionStatus.Active => "Active",
                (byte)SubscriptionStatus.Pending => "Pending",
                (byte)SubscriptionStatus.Cancelled => "Cancelled",
                (byte)SubscriptionStatus.Expired => "Expired",

                _ => "Unknown"
            };
        }
    }
}
