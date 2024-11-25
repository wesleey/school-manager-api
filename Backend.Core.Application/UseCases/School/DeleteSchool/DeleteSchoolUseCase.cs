using Backend.Core.Application.Exceptions;
using Backend.Core.Domain.Interfaces;

namespace Backend.Core.Application.UseCases.School.DeleteSchool;

public class DeleteSchoolUseCase(ISchoolRepository repository, IUnitOfWork unitOfWork)
{
    private readonly ISchoolRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Execute(int id, CancellationToken cancellationToken)
    {
        var school = await _repository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("School not found");

        _repository.Delete(school);
        await _unitOfWork.Commit(cancellationToken);
    }
}
