using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.Class.CreateClass;

public class CreateClassUseCase(IClassRepository repository, ISchoolRepository schoolRepository, IUnitOfWork unitOfWork)
{
    private readonly IClassRepository _repository = repository;
    private readonly ISchoolRepository _schoolRepository = schoolRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Entities.Class> Execute(Entities.Class dto, CancellationToken cancellationToken)
    {
        if (await _schoolRepository.GetById(dto.SchoolId, cancellationToken) is null)
            throw new NotFoundException("School not found");

        _repository.Create(dto);
        await _unitOfWork.Commit(cancellationToken);

        var entity = await _repository.GetBySchoolId(dto.SchoolId, cancellationToken)
            ?? throw new InternalServerErrorException("Could not create class");

        return entity;
    }
}
