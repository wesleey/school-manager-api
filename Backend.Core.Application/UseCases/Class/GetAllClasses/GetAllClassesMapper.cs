using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.Class.GetAllClasses;

public sealed class GetAllClassesMapper : Profile
{
    public GetAllClassesMapper()
    {
        CreateMap<Entities.Class, GetAllClassesResponse>();
    }
}
