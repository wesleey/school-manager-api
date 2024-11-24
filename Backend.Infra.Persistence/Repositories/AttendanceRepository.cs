using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class AttendanceRepository(AppDbContext context) : BaseRepository<Attendance>(context), IAttendanceRepository
{
    public async Task<Attendance?> GetByLessonId(int lessonId, CancellationToken cancellationToken)
        => await _context.Attendances.FirstOrDefaultAsync(x => x.LessonId == lessonId, cancellationToken);

    public async Task<Attendance?> GetByStudentId(int studentId, CancellationToken cancellationToken)
        => await _context.Attendances.FirstOrDefaultAsync(x => x.StudentId == studentId, cancellationToken);
}
