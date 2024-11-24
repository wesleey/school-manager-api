using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class StudentPerformanceRepository(AppDbContext context) : BaseRepository<StudentPerformance>(context), IStudentPerformanceRepository
{
    public async Task<StudentPerformance?> GetByStudentId(int studentId, CancellationToken cancellationToken)
        => await _context.StudentPerformances.FirstOrDefaultAsync(x => x.StudentId == studentId, cancellationToken);
}
