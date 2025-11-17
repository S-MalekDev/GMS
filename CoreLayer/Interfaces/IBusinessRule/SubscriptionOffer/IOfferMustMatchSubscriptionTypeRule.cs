using CoreLayer.IBusinessRules.Parameters;
using CoreLayer.Common;


namespace CoreLayer.Interfaces.IBusinessRule.SubscriptionOffer
{
    public interface IOfferMustMatchSubscriptionTypeRule : IBusinessRule<OfferSubscriptionTypeParams>
    {
        new Task<BusinessRuleResult> ValidateAsync(OfferSubscriptionTypeParams offerSubscriptionTypeParams);
    }
}
