using MediatR;

namespace Backend.Core.Application.UseCases.School.UpdateSchool;

public sealed class UpdateSchoolRequest : IRequest<UpdateSchoolResponse>
{
    public int Id { get; set; }
    public string? Cnpj { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
