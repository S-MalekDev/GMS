using AutoMapper;
using CoreLayer.DTOs.TrainerSpecialityDTO;
using CoreLayer.Entities;


namespace ApplicationLayer.Mapping
{
    public class SpecialityProfile : Profile
    {
        public SpecialityProfile()
        {
            CreateMap<Speciality, SpecialityListDTO>();
            CreateMap<Speciality, SpecialityDTO>();
            CreateMap<AddSpecialityDTO, Speciality>(); 
            CreateMap<UpdateSpecialityDTO, Speciality>();
        }
    }
}
