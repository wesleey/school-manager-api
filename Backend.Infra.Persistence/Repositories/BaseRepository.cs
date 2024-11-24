using Backend.Core.Domain.Common;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context = context;

    public void Create(T entity)
        => _context.Set<T>().Add(entity);

    public void Update(T entity)
        => _context.Set<T>().Update(entity);

    public void Delete(T entity)
        => _context.Set<T>().Remove(entity);

    public async Task<T?> GetById(int id, CancellationToken cancellationToken)
        => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        => await _context.Set<T>().ToListAsync(cancellationToken);
}
