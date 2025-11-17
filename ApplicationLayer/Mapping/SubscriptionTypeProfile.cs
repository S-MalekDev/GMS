

using AutoMapper;
using CoreLayer.DTOs.SubscriptionTypeDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.SubscriptionType;
using CoreLayer.Extensions;

namespace ApplicationLayer.Mapping
{
    public class SubscriptionTypeProfile : Profile
    {
        public SubscriptionTypeProfile()
        {
            CreateMap<SubscriptionType, SubscriptionTypeDTO>().ForMember(des => des.SubscriptionPariod, opt => opt.MapFrom(src => (SubscriptionPariod)src.SubscriptionPariod));

            CreateMap<SubscriptionType, SubscriptionTypeListDTO>().ForMember(des => des.ProgramType, opt => opt.MapFrom(src => src.ProgramType!.Name))
                .ForMember(des => des.SubscriptionPariod, opt => opt.MapFrom(src => src.GetSubscriptionPariodText()));

            CreateMap<AddSubscriptionTypeDTO, SubscriptionType>().ForMember(des => des.SubscriptionPariod, opt => opt.MapFrom(src => (byte)src.SubscriptionPariod));
            CreateMap<UpdateSubscriptionTypeDTO, SubscriptionType>().ForMember(des => des.SubscriptionPariod, opt => opt.MapFrom(src => (byte)src.SubscriptionPariod)); ;
        }
    }
}
