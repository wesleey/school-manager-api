using MediatR;

namespace Backend.Core.Application.UseCases.User.CreateUser;

public sealed record CreateUserRequest : IRequest<CreateUserResponse>
{
    public int? Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Role { get; set; }
}
