using AutoMapper;
using CoreLayer.DTOs.TrainerDTOs;
using CoreLayer.Entities;
using CoreLayer.Extensions;

namespace ApplicationLayer.Mapping
{
    public class TrainerProfile : Profile
    {
        public TrainerProfile()
        {
            CreateMap<Trainer, TrainerListDTO>().ForMember(t => t.FullName, opt => opt.MapFrom(t => t.EmployeeInfo.PersonInfo!.GetFullName()))
                .ForMember(t => t.Speciality, opt => opt.MapFrom(t => t.SpecialityInfo.SpecialityName));
            
            CreateMap<Trainer, TrainerDTO>();
            CreateMap<AddTrainerDTO, Trainer>();
            CreateMap<UpdateTrainerDTO, Trainer>();
        }
    }
}
