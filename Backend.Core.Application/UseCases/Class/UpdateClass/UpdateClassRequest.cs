using MediatR;

namespace Backend.Core.Application.UseCases.Class.UpdateClass;

public sealed class UpdateClassRequest : IRequest<UpdateClassResponse>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Shift { get; set; }
    public string? AcademicYear { get; set; }
}
