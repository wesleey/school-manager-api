using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class StudentActivityRepository(AppDbContext context) : BaseRepository<StudentActivity>(context), IStudentActivityRepository
{
    public async Task<StudentActivity?> GetByStudentId(int studentId, CancellationToken cancellationToken)
        => await _context.StudentActivities.FirstOrDefaultAsync(x => x.StudentId == studentId, cancellationToken);

    public async Task<StudentActivity?> GetByActivityId(int activityId, CancellationToken cancellationToken)
        => await _context.StudentActivities.FirstOrDefaultAsync(x => x.ActivityId == activityId, cancellationToken);
}
