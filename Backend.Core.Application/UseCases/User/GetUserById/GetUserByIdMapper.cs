using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.User.GetUserById;

public sealed class GetUserByIdMapper : Profile
{
    public GetUserByIdMapper()
    {
        CreateMap<Entities.User, GetUserByIdResponse>();
    }
}
