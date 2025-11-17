using AutoMapper;
using CoreLayer.DTOs.PersonDTOs.PhoneNumber;
using CoreLayer.Entities;


namespace ApplicationLayer.Mapping
{
    public class PhoneNumberProfile:Profile
    {
        public PhoneNumberProfile()
        {
            CreateMap<PhoneNumber, PhoneNumberListDTO>().ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.Number));
            CreateMap<AddPhoneNumberDTO, PhoneNumber>().ForMember(des => des.Number, opt => opt.MapFrom(src => src.PhoneNumber));

            CreateMap<PhoneNumberDTO, PhoneNumber>().ForMember(des => des.Number, opt => opt.MapFrom(src => src.PhoneNumber));
            CreateMap<PhoneNumber, PhoneNumberDTO>().ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.Number));
            CreateMap<UpdatePhoneNumberDTO, PhoneNumber>().ForMember(des => des.Number, opt => opt.MapFrom(src => src.PhoneNumber));
            CreateMap<PhoneNumber, PersonPhoneNumberDTO>().ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.Number));

        }
    }
}
