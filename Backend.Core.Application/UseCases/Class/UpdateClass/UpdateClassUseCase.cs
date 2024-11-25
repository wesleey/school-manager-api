using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.Class.UpdateClass;

public class UpdateClassUseCase(IClassRepository repository, IUnitOfWork unitOfWork)
{
    private readonly IClassRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Entities.Class> Execute(int id, Entities.Class dto, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("Class not found");

        if (!string.IsNullOrEmpty(dto.Name))
            entity.Name = dto.Name;

        if (!string.IsNullOrEmpty(dto.Shift))
            entity.Shift = dto.Shift;

        if (!string.IsNullOrEmpty(dto.AcademicYear))
            entity.AcademicYear = dto.AcademicYear;

        _repository.Update(entity);
        await _unitOfWork.Commit(cancellationToken);

        return entity;
    }
}
