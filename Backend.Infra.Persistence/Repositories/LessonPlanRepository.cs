using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class LessonPlanRepository(AppDbContext context) : BaseRepository<LessonPlan>(context), ILessonPlanRepository
{
    public async Task<LessonPlan?> GetBySchoolId(int schoolId, CancellationToken cancellationToken)
        => await _context.LessonPlans.FirstOrDefaultAsync(x => x.SchoolId == schoolId, cancellationToken);

    public async Task<LessonPlan?> GetByClassId(int classId, CancellationToken cancellationToken)
        => await _context.LessonPlans.FirstOrDefaultAsync(x => x.ClassId == classId, cancellationToken);
}
