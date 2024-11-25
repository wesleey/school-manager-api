using MediatR;

namespace Backend.Core.Application.UseCases.Class.GetClassById;

public sealed record GetClassByIdRequest(int Id) : IRequest<GetClassByIdResponse>;
