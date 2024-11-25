using MediatR;

namespace Backend.Core.Application.UseCases.Class.GetAllClasses;

public sealed record GetAllClassesRequest : IRequest<List<GetAllClassesResponse>>;
