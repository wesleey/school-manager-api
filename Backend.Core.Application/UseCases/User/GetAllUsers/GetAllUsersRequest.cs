using MediatR;

namespace Backend.Core.Application.UseCases.User.GetAllUsers;

public sealed record GetAllUsersRequest : IRequest<List<GetAllUsersResponse>>;
