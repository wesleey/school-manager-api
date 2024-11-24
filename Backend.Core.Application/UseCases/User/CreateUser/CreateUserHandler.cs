using Entities = Backend.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.User.CreateUser;

public class CreateUserHandler(CreateUserUseCase createUserUseCase, IMapper mapper) : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly CreateUserUseCase _createUserUseCase = createUserUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<Entities.User>(request);
        var user = await _createUserUseCase.Execute(dto, cancellationToken);
        return _mapper.Map<CreateUserResponse>(user);
    }
}
