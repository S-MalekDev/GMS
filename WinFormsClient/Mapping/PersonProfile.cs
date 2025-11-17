using AutoMapper;
using WinFormsClient.DTOs.PersonDTOs;

namespace WinFormsClient.Mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonWithImageDTO, PersonListDTO>().ForMember(des => des.Gender, opt => opt.MapFrom(src => src.Gender ? "Male" : "Female"));
            CreateMap<UpdatePersonWithImageDTO, PersonListDTO>().ForMember(des => des.Gender, opt => opt.MapFrom(src => src.Gender ? "Male" : "Female"));
        }
    }
}
