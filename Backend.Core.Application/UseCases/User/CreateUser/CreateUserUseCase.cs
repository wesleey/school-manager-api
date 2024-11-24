using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.User.CreateUser;

public class CreateUserUseCase(IUserRepository repository, IUnitOfWork unitOfWork)
{
    private readonly IUserRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Entities.User> Execute(Entities.User dto, CancellationToken cancellationToken)
    {
        if (await _repository.EmailExists(dto.Email, cancellationToken))
            throw new ConflictException("Could not create user");

        _repository.Create(dto);
        await _unitOfWork.Commit(cancellationToken);

        var user = await _repository.GetByEmail(dto.Email, cancellationToken)
            ?? throw new InternalServerErrorException("Could not create user");

        return user;
    }
}
