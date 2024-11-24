using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.User.GetUserById;

public class GetUserByIdUseCase(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<Entities.User> Execute(int id, CancellationToken cancellationToken)
        => await _repository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("User not found");
}
