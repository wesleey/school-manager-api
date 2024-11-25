using MediatR;

namespace Backend.Core.Application.UseCases.Class.CreateClass;

public sealed record CreateClassRequest(string Name, string Shift, string AcademicYear, int SchoolId) : IRequest<CreateClassResponse>;
