using MediatR;

namespace Backend.Core.Application.UseCases.School.CreateSchool;

public sealed record CreateSchoolRequest(string Cnpj, string Name, string Address, string Email, string Phone) : IRequest<CreateSchoolResponse>;
