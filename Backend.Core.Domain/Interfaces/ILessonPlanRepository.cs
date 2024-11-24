using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface ILessonPlanRepository : IBaseRepository<LessonPlan>
{
    Task<LessonPlan?> GetBySchoolId(int schoolId, CancellationToken cancellationToken);
    Task<LessonPlan?> GetByClassId(int classId, CancellationToken cancellationToken);
}
