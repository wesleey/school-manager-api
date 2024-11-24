using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.User.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, Entities.User>();
        CreateMap<Entities.User, CreateUserResponse>()
            .ForMember(x => x.Role, options => options.MapFrom(x => x.Role.ToString()));
    }
}
