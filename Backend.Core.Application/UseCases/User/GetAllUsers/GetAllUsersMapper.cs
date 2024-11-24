using Entities = Backend.Core.Domain.Entities;
using AutoMapper;

namespace Backend.Core.Application.UseCases.User.GetAllUsers;

public sealed class GetAllUsersMapper : Profile
{
    public GetAllUsersMapper()
    {
        CreateMap<Entities.User, GetAllUsersResponse>()
            .ForMember(x => x.Role, options => options.MapFrom(x => x.Role.ToString()));
    }
}
