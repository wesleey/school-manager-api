using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class LessonRepository(AppDbContext context) : BaseRepository<Lesson>(context), ILessonRepository
{
    public async Task<Lesson?> GetBySchoolId(int schoolId, CancellationToken cancellationToken)
        => await _context.Lessons.FirstOrDefaultAsync(x => x.SchoolId == schoolId, cancellationToken);

    public async Task<Lesson?> GetByClassId(int classId, CancellationToken cancellationToken)
        => await _context.Lessons.FirstOrDefaultAsync(x => x.ClassId == classId, cancellationToken);

    public async Task<Lesson?> GetByLessonPlan(int lessonPlanId, CancellationToken cancellationToken)
        => await _context.Lessons.FirstOrDefaultAsync(x => x.LessonPlanId == lessonPlanId, cancellationToken);
}
