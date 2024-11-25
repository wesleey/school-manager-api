using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.Class.GetClassById;

public class GetClassByIdUseCase(IClassRepository repository)
{
    private readonly IClassRepository _repository = repository;

    public async Task<Entities.Class> Execute(int id, CancellationToken cancellationToken)
        => await _repository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("Class not found");
}
