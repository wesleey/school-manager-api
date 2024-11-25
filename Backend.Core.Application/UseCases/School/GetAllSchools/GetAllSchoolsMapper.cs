using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.School.GetAllSchools;

public sealed class GetAllSchoolsMapper : Profile
{
    public GetAllSchoolsMapper()
    {
        CreateMap<Entities.School, GetAllSchoolsResponse>();
    }
}
