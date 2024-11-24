using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface ILessonRepository : IBaseRepository<Lesson>
{
    Task<Lesson?> GetBySchoolId(int schoolId, CancellationToken cancellationToken);
    Task<Lesson?> GetByClassId(int classId, CancellationToken cancellationToken);
    Task<Lesson?> GetByLessonPlan(int lessonPlanId, CancellationToken cancellationToken);
}
