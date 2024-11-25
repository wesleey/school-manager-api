using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.School.GetSchoolById;

public class GetSchoolByIdUseCase(ISchoolRepository repository)
{
    private readonly ISchoolRepository _repository = repository;

    public async Task<Entities.School> Execute(int id, CancellationToken cancellationToken)
        => await _repository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("School not found");
}
