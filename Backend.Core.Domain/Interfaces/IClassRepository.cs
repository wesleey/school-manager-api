using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface IClassRepository : IBaseRepository<Class>
{
    Task<Class?> GetBySchoolId(int schoolId, CancellationToken cancellationToken);
}
