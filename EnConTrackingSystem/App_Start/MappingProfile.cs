using AutoMapper;
using EnConTrackingSystem.Dtos;
using EnConTrackingSystem.Models;

namespace EnConTrackingSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            CreateMap<Program, ProgramDto>().PreserveReferences();
            CreateMap<Project, ProjectDto>().PreserveReferences();
            CreateMap<Client, ClientDto>().PreserveReferences();
            CreateMap<Consultant, ConsultantDto>().PreserveReferences();

            //Dto to Domain
            CreateMap<ProjectDto, Project>().ForMember(c => c.Id, opt => opt.Ignore()).PreserveReferences();
            CreateMap<ProgramDto, Program>().ForMember(m => m.Id, opt => opt.Ignore()).PreserveReferences();
        }
    }
}