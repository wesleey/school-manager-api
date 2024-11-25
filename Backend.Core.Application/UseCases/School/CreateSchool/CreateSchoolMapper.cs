using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.School.CreateSchool;

public sealed class CreateSchoolMapper : Profile
{
    public CreateSchoolMapper()
    {
        CreateMap<CreateSchoolRequest, Entities.School>();
        CreateMap<Entities.School, CreateSchoolResponse>();
    }
}
