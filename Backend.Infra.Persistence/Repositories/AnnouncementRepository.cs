using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class AnnouncementRepository(AppDbContext context) : BaseRepository<Announcement>(context), IAnnouncementRepository
{
    public async Task<Announcement?> GetByClassId(int classId, CancellationToken cancellationToken)
        => await _context.Announcements.FirstOrDefaultAsync(x => x.ClassId == classId, cancellationToken);

    public async Task<Announcement?> GetByUserId(int userId, CancellationToken cancellationToken)
        => await _context.Announcements.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
}
