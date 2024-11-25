using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.School.UpdateSchool;

public sealed class UpdateSchoolMapper : Profile
{
    public UpdateSchoolMapper()
    {
        CreateMap<UpdateSchoolRequest, Entities.School>();
        CreateMap<Entities.School, UpdateSchoolResponse>();
    }
}
