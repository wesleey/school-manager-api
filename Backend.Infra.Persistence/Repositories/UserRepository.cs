using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
        => await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

    public async Task<bool> EmailExists(string email, CancellationToken cancellationToken)
        => await _context.Users.AnyAsync(x => x.Email == email, cancellationToken);
}
