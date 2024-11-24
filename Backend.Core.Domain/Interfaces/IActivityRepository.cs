using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface IActivityRepository : IBaseRepository<Activity>
{
    Task<Activity?> GetByClassId(int classId, CancellationToken cancellationToken);
    Task<Activity?> GetByUserId(int userId, CancellationToken cancellationToken);
}
