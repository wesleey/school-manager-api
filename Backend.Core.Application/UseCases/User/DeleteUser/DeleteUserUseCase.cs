using Backend.Core.Application.Exceptions;
using Backend.Core.Domain.Interfaces;

namespace Backend.Core.Application.UseCases.User.DeleteUser;

public class DeleteUserUseCase(IUserRepository repository, IUnitOfWork unitOfWork)
{
    private readonly IUserRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Execute(int id, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("User not found");

        _repository.Delete(user);
        await _unitOfWork.Commit(cancellationToken);
    }
}
