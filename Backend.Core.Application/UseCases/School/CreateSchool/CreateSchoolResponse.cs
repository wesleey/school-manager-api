namespace Backend.Core.Application.UseCases.School.CreateSchool;

public sealed record CreateSchoolResponse
{
    public required int Id { get; set; }
    public required string Cnpj { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}
