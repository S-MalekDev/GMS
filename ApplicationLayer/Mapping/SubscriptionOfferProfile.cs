

using AutoMapper;
using CoreLayer.DTOs.SubscriptionOfferDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.SubscriptionOffer;
using CoreLayer.Extensions;

namespace ApplicationLayer.Mapping
{
    public class SubscriptionOfferProfile : Profile
    {
        public SubscriptionOfferProfile()
        {
            CreateMap<SubscriptionOffer, SubscriptionOfferDTO>().ForMember(des => des.Status, opt => opt.MapFrom(src => (SubscriptionOfferStatus)src.Status));
            CreateMap<SubscriptionOffer, SubscriptionOfferListDTO>().ForMember(des => des.Status, opt => opt.MapFrom(src => src.GetStatusText()));
            CreateMap<AddSubscriptionOfferDTO, SubscriptionOffer>().ForMember(des => des.Status, opt => opt.MapFrom(src => (byte)src.Status));
            CreateMap<UpdateSubscriptionOfferDTO, SubscriptionOffer>().ForMember(des => des.Status, opt => opt.MapFrom(src => (byte)src.Status));
        }
    }
}
