using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class StudentRepository(AppDbContext context) : BaseRepository<Student>(context), IStudentRepository
{
    public async Task<Student?> GetByEnrollment(string enrollment, CancellationToken cancellationToken)
        => await _context.Students.FirstOrDefaultAsync(x => x.Enrollment == enrollment, cancellationToken);

    public async Task<Student?> GetBySchoolId(int schoolId, CancellationToken cancellationToken)
        => await _context.Students.FirstOrDefaultAsync(x => x.SchoolId == schoolId, cancellationToken);

    public async Task<Student?> GetByClassId(int classId, CancellationToken cancellationToken)
        => await _context.Students.FirstOrDefaultAsync(x => x.ClassId == classId, cancellationToken);
}
