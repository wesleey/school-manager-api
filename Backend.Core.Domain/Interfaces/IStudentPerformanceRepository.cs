using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface IStudentPerformanceRepository : IBaseRepository<StudentPerformance>
{
    Task<StudentPerformance?> GetByStudentId(int studentId, CancellationToken cancellationToken);
}
