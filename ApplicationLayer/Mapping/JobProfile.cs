using AutoMapper;
using CoreLayer.DTOs.JobDTOs;
using CoreLayer.DTOs.PersonDTOs;
using CoreLayer.Entities;


namespace ApplicationLayer.Mapping
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobListDTO>();
            CreateMap<Job, JobDTO>();
            CreateMap<AddJobDTO, Job>();
            CreateMap<UpdateJobDTO, Job>();
        }
    }
}
