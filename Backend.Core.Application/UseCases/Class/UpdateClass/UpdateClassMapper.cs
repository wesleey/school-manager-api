using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.Class.UpdateClass;

public sealed class UpdateClassMapper : Profile
{
    public UpdateClassMapper()
    {
        CreateMap<UpdateClassRequest, Entities.Class>();
        CreateMap<Entities.Class, UpdateClassResponse>();
    }
}
