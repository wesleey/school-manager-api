namespace Backend.Core.Application.UseCases.Class.UpdateClass;

public sealed record UpdateClassResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Shift { get; set; }
    public required string AcademicYear { get; set; }
    public required int SchoolId { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}
