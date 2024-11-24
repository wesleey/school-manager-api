using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.User.UpdateUser;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserRequest, Entities.User>();
        CreateMap<Entities.User, UpdateUserResponse>()
            .ForMember(x => x.Role, options => options.MapFrom(x => x.Role.ToString()));
    }
}
