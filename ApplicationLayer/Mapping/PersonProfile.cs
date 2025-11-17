using ApplicationLayer.Helpers;
using AutoMapper;
using CoreLayer.DTOs.PersonDTOs;
using CoreLayer.Entities;


namespace ApplicationLayer.Mapping
{
    public class PersonProfile:Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonDTO, PersonDTO>();
            CreateMap<CreatePersonDTO, Person>();
            CreateMap<UpdatePersonDTO, PersonDTO>();
            CreateMap<UpdatePersonDTO, Person>();
            CreateMap<Person, PersonDTO>().ForMember(des => des.PhoneNumbers, opt => opt.MapFrom(src => src.PhoneNumbers))
                                          .ForMember(des => des.ImageUrl, opt => opt.MapFrom<ImageUrlResolver>());

            CreateMap<Person, PersonListDTO>().ForMember(des => des.Gender, opt => opt.MapFrom(src => src.Gender ? "Male" : "Female"));
        }
    }
}
