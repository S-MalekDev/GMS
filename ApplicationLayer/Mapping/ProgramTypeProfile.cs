

using AutoMapper;
using CoreLayer.DTOs.ProgramTypeDTOs;
using CoreLayer.Entities;

namespace ApplicationLayer.Mapping
{
    public class ProgramTypeProfile : Profile
    {
        public ProgramTypeProfile()
        {
            CreateMap<ProgramType, ProgramTypeDTO>();
            CreateMap<ProgramType, ProgramTypeListDTO>();
            CreateMap<AddProgramTypeDTO, ProgramType>();
            CreateMap<UpdateProgramTypeDTO, ProgramType>();
        }
    }
}
