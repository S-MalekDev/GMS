

using CoreLayer.Common;

namespace CoreLayer.Interfaces.IBusinessRule.SubscriptionOffer
{
    public interface ISubscriptionOfferMustExistRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int subscriptionOfferId);
    }
}
