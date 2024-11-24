using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class ClassRepository(AppDbContext context) : BaseRepository<Class>(context), IClassRepository
{
    public async Task<Class?> GetBySchoolId(int schoolId, CancellationToken cancellationToken)
        => await _context.Classes.FirstOrDefaultAsync(x => x.SchoolId == schoolId, cancellationToken);
}
