using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.School.UpdateSchool;

public class UpdateSchoolUseCase(ISchoolRepository repository, IUnitOfWork unitOfWork)
{
    private readonly ISchoolRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Entities.School> Execute(int id, Entities.School dto, CancellationToken cancellationToken)
    {
        var school = await _repository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("School not found");

        if (!string.IsNullOrEmpty(dto.Name))
            school.Name = dto.Name;

        if (!string.IsNullOrEmpty(dto.Cnpj))
        {
            if (await _repository.CnpjExists(dto.Cnpj, cancellationToken))
                throw new ConflictException("Cnpj already exists");

            school.Cnpj = dto.Cnpj;
        }

        if (!string.IsNullOrEmpty(dto.Address))
            school.Address = dto.Address;

        if (!string.IsNullOrEmpty(dto.Email))
            school.Email = dto.Email;

        if (!string.IsNullOrEmpty(dto.Phone))
            school.Phone = dto.Phone;

        _repository.Update(school);
        await _unitOfWork.Commit(cancellationToken);

        return school;
    }
}
