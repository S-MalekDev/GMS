using CoreLayer.Entities;
using CoreLayer.Enums.SubscriptionType;
using System;

namespace CoreLayer.Extensions
{
    public static class SubscriptionTypeExtensions
    {
        public static void UpdateFrom(this SubscriptionType subscriptionType, SubscriptionType subscriptionTypeToUpdateFrom)
        {
            subscriptionType.SubscriptionTypeID = subscriptionTypeToUpdateFrom.SubscriptionTypeID;
            subscriptionType.ProgramTypeId = subscriptionTypeToUpdateFrom.ProgramTypeId;
            subscriptionType.SubscriptionPariod = subscriptionTypeToUpdateFrom.SubscriptionPariod;
            subscriptionType.NumberOfMonths = subscriptionTypeToUpdateFrom.NumberOfMonths;
            subscriptionType.NumberOfDays = subscriptionTypeToUpdateFrom.NumberOfDays;
            subscriptionType.SessionsCount = subscriptionTypeToUpdateFrom.SessionsCount;
            subscriptionType.Description = subscriptionTypeToUpdateFrom.Description;
            subscriptionType.CurrentPrice = subscriptionTypeToUpdateFrom.CurrentPrice;
            subscriptionType.IsActive = subscriptionTypeToUpdateFrom.IsActive;

            if(subscriptionType.ProgramType != null)
                subscriptionType.ProgramType.UpdateFrom(subscriptionTypeToUpdateFrom.ProgramType);
        }

        public static string GetSubscriptionPariodText(this SubscriptionType subscriptionType)
        {
            var subscriptionTypeEnum = (SubscriptionPariod)subscriptionType.SubscriptionPariod;

            return subscriptionTypeEnum switch
            {
                SubscriptionPariod.Weekly => "Weekly",
                SubscriptionPariod.HalfMonth => "Half Month",
                SubscriptionPariod.Monthly => "Monthly",
                SubscriptionPariod.Quarterly => "Quarterly",
                SubscriptionPariod.SemiAnnual => "SemiAnnual",
                SubscriptionPariod.Annual => "Annual",
                _ => "Unknown"
            };
        }

        public static DateOnly CalculateEndDate(this SubscriptionType subscriptionType, DateOnly startDate)
        {
            if(subscriptionType.NumberOfMonths != 0)
                return startDate.AddMonths(subscriptionType.NumberOfMonths);
            else return startDate.AddDays(subscriptionType.NumberOfDays);
        }
    }
}
