using AutoMapper;
using NLayer_TodoApp.Dtos.WorkDtos;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.Business.Mappings.AutoMapper;

public class WorkProfile : Profile
{
    public WorkProfile()
    {
        CreateMap<Work, WorkListDto>().ReverseMap();
        CreateMap<Work, WorkCreateDto>().ReverseMap();
        CreateMap<Work, WorkUpdateDto>().ReverseMap();
        CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
    }
}