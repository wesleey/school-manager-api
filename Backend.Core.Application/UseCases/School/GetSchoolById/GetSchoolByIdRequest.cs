using MediatR;

namespace Backend.Core.Application.UseCases.School.GetSchoolById;

public sealed record GetSchoolByIdRequest(int Id) : IRequest<GetSchoolByIdResponse>;
