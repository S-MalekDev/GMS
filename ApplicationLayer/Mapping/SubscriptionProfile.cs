
using AutoMapper;
using CoreLayer.CommandModel;
using CoreLayer.DTOs.SubscriptionDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.SubscriptionStatus;
using CoreLayer.Extensions;


namespace ApplicationLayer.Mapping
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionDTO>().ForMember(des => des.Status, opt => opt.MapFrom(src => (SubscriptionStatus)src.Status));

            CreateMap<Subscription, SubscriptionListDTO>().ForMember(des => des.Status, opt => opt.MapFrom(src => src.GetStatusText()))
                .ForMember(des => des.PaidAmount, opt => opt.MapFrom(src => src.FinalPaidAmount))
                .ForMember(des => des.MumberFullName, opt => opt.MapFrom(src => src.Member.Person.GetFullName()));

            CreateMap<AddSubscriptionDTO, AddSubscriptionCommandModel>();
        }
    }
}
