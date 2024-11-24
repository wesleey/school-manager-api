using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface IStudentRepository : IBaseRepository<Student>
{
    Task<Student?> GetByEnrollment(string enrollment, CancellationToken cancellationToken);
    Task<Student?> GetBySchoolId(int schoolId, CancellationToken cancellationToken);
    Task<Student?> GetByClassId(int classId, CancellationToken cancellationToken);
}
