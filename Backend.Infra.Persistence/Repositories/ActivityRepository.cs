using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class ActivityRepository(AppDbContext context) : BaseRepository<Activity>(context), IActivityRepository
{
    public async Task<Activity?> GetByClassId(int classId, CancellationToken cancellationToken)
        => await _context.Activities.FirstOrDefaultAsync(x => x.ClassId == classId, cancellationToken);

    public async Task<Activity?> GetByUserId(int userId, CancellationToken cancellationToken)
        => await _context.Activities.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
}
