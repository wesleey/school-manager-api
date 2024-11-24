using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface IAnnouncementRepository : IBaseRepository<Announcement>
{
    Task<Announcement?> GetByClassId(int classId, CancellationToken cancellationToken);
    Task<Announcement?> GetByUserId(int userId, CancellationToken cancellationToken);
}
