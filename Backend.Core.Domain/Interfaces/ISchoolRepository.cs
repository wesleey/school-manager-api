using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface ISchoolRepository : IBaseRepository<School>
{
    Task<School?> GetByCpnj(string cnpj, CancellationToken cancellationToken);
    Task<School?> GetByEmail(string email, CancellationToken cancellationToken);
}
