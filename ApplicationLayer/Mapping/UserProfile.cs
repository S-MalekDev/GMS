using AutoMapper;
using CoreLayer.DTOs.UserDTOs;
using CoreLayer.Entities;
using CoreLayer.Extensions;


namespace ApplicationLayer.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserListDTO>().ForMember(des => des.Gender, opt => opt.MapFrom(src => src.GetGenderText()))
                .ForMember(des => des.FullName, opt => opt.MapFrom(src => src.GetFullName()))
                .ForMember(des => des.Email, opt => opt.MapFrom(src => src.PersonInfo!.Email));

            CreateMap<User, UserDTO>();
            CreateMap<AddUserDTO, User>();
        }
    }
}
