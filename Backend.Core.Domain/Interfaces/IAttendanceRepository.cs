using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface IAttendanceRepository : IBaseRepository<Attendance>
{
    Task<Attendance?> GetByLessonId(int lessonId, CancellationToken cancellationToken);
    Task<Attendance?> GetByStudentId(int studentId, CancellationToken cancellationToken);
}
