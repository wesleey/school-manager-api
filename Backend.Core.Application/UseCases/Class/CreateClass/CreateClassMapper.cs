using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.Class.CreateClass;

public sealed class CreateClassMapper : Profile
{
    public CreateClassMapper()
    {
        CreateMap<CreateClassRequest, Entities.Class>();
        CreateMap<Entities.Class, CreateClassResponse>();
    }
}
