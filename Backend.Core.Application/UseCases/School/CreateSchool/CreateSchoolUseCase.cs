using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.School.CreateSchool;

public class CreateSchoolUseCase(ISchoolRepository repository, IUnitOfWork unitOfWork)
{
    private readonly ISchoolRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Entities.School> Execute(Entities.School dto, CancellationToken cancellationToken)
    {
        if (await _repository.CnpjExists(dto.Cnpj, cancellationToken))
            throw new ConflictException("Cnpj already exists");

        _repository.Create(dto);
        await _unitOfWork.Commit(cancellationToken);

        var school = await _repository.GetByCpnj(dto.Cnpj, cancellationToken)
            ?? throw new InternalServerErrorException("Could not create school");

        return school;
    }
}
