using Backend.Core.Application.Exceptions;
using Backend.Core.Domain.Interfaces;

namespace Backend.Core.Application.UseCases.Class.DeleteClass;

public class DeleteClassUseCase(IClassRepository repository, IUnitOfWork unitOfWork)
{
    private readonly IClassRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Execute(int id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("Class not found");

        _repository.Delete(entity);
        await _unitOfWork.Commit(cancellationToken);
    }
}
