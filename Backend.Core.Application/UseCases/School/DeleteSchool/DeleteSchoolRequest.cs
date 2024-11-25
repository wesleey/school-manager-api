using MediatR;

namespace Backend.Core.Application.UseCases.School.DeleteSchool;

public sealed record DeleteSchoolRequest(int Id) : IRequest;
