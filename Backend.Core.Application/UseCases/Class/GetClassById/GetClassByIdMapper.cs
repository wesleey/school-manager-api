using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.Class.GetClassById;

public sealed class GetClassByIdMapper : Profile
{
    public GetClassByIdMapper()
    {
        CreateMap<Entities.Class, GetClassByIdResponse>();
    }
}
