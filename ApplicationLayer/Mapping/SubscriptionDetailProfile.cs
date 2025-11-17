

using AutoMapper;
using CoreLayer.CommandModel;
using CoreLayer.DTOs.SubscriptionDetailDTOs;
using CoreLayer.Entities;

namespace ApplicationLayer.Mapping
{
    public class SubscriptionDetailProfile : Profile
    {
        public SubscriptionDetailProfile()
        {
            CreateMap<SubscriptionDetail, SubscriptionDetailDTO>();
            CreateMap<SubscriptionDetail, SubscriptionDetailListDTO>();
            CreateMap<AddSubscriptionDetailDTO, AddSubscriptionDetailCommandModel>();
        }
    }
}
