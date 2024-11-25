using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;

namespace Backend.Core.Application.UseCases.Class.GetAllClasses;

public class GetAllClassesUseCase(IClassRepository repository)
{
    private readonly IClassRepository _repository = repository;

    public async Task<List<Entities.Class>> Execute(CancellationToken cancellationToken)
        => await _repository.GetAll(cancellationToken);
}
