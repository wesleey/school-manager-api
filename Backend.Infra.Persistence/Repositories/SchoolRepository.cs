using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class SchoolRepository(AppDbContext context) : BaseRepository<School>(context), ISchoolRepository
{
    public async Task<School?> GetByCpnj(string cnpj, CancellationToken cancellationToken)
        => await _context.Schools.FirstOrDefaultAsync(x => x.Cnpj == cnpj, cancellationToken);

    public async Task<School?> GetByEmail(string email, CancellationToken cancellationToken)
        => await _context.Schools.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
}
