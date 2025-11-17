using AutoMapper;
using CoreLayer.DTOs.MemberDTOs;
using CoreLayer.Entities;
using CoreLayer.Extensions;


namespace ApplicationLayer.Mapping
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member,MemberListDTO>().ForMember(m => m.FullName, opt => opt.MapFrom(m => m.Person.GetFullName()))
                .ForMember(m => m.PersonalTrainerFullName, opt => opt.MapFrom(m => m.PersonalTrainer.EmployeeInfo.PersonInfo!.GetFullName()));


            CreateMap<Member, MemberDTO>();
            CreateMap<AddMemberDTO,Member>().ForMember(dest => dest.EnrollmentDate,opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.Today))); ; 
            CreateMap<UpdateMemberDTO, Member>();

        }
    }
}
