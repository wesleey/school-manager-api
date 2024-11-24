using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface IStudentActivityRepository : IBaseRepository<StudentActivity>
{
    Task<StudentActivity?> GetByStudentId(int studentId, CancellationToken cancellationToken);
    Task<StudentActivity?> GetByActivityId(int activityId, CancellationToken cancellationToken);
}
