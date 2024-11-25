using MediatR;

namespace Backend.Core.Application.UseCases.School.GetAllSchools;

public sealed record GetAllSchoolsRequest : IRequest<List<GetAllSchoolsResponse>>;
