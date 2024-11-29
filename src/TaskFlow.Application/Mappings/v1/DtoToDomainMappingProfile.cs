using AutoMapper;
using TaskFlow.Application.Dtos.v1;
using TaskFlow.Domain.Entities.v1;

namespace TaskFlow.Application.Mappings.v1;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<ProjectDto, Project>().ReverseMap();
        CreateMap<WorkDto, Work>().ReverseMap();
    }
}
