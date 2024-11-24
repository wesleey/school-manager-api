using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.User.UpdateUser;

public class UpdateUserUseCase(IUserRepository repository, IUnitOfWork unitOfWork)
{
    private readonly IUserRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Entities.User> Execute(int id, Entities.User dto, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("User not found");

        if (!string.IsNullOrEmpty(dto.Name))
            user.Name = dto.Name;

        if (!string.IsNullOrEmpty(dto.Email))
        {
            if (await _repository.EmailExists(dto.Email, cancellationToken))
                throw new ConflictException("Email address already exists");

            user.Email = dto.Email;
        }

        if (!string.IsNullOrEmpty(dto.Password))
            user.Password = dto.Password;

        _repository.Update(user);
        await _unitOfWork.Commit(cancellationToken);

        return user;
    }
}
