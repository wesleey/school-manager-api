using Entities = Backend.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.User.UpdateUser;

public class UpdateUserHandler(UpdateUserUseCase updateUserUseCase, IMapper mapper) : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly UpdateUserUseCase _updateUserUseCase = updateUserUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<Entities.User>(request);
        var user = await _updateUserUseCase.Execute(request.Id, dto, cancellationToken);
        return _mapper.Map<UpdateUserResponse>(user);
    }
}
