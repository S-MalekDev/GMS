using AutoMapper;
using CoreLayer.DTOs.EmployeeDTOs;
using CoreLayer.DTOs.JobDTOs;
using CoreLayer.DTOs.PersonDTOs;
using CoreLayer.Entities;
using CoreLayer.Extensions;


namespace ApplicationLayer.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeListDTO>().ForMember(e => e.FullName, opt => opt.MapFrom(e => e.PersonInfo!.GetFullName()))
                .ForMember(e => e.Position, opt => opt.MapFrom(e => e.JobInfo!.JobTitle));
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<AddEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();
        }
    }
}
