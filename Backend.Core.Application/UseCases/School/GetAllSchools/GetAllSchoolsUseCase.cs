using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;

namespace Backend.Core.Application.UseCases.School.GetAllSchools;

public class GetAllSchoolsUseCase(ISchoolRepository repository)
{
    private readonly ISchoolRepository _repository = repository;

    public async Task<List<Entities.School>> Execute(CancellationToken cancellationToken)
        => await _repository.GetAll(cancellationToken);
}
