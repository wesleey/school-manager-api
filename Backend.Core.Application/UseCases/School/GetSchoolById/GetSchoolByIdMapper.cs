using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.School.GetSchoolById;

public class GetSchoolByIdMapper : Profile
{
    public GetSchoolByIdMapper()
    {
        CreateMap<Entities.School, GetSchoolByIdResponse>();
    }
}
