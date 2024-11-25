using MediatR;

namespace Backend.Core.Application.UseCases.Class.DeleteClass;

public sealed record DeleteClassRequest(int Id) : IRequest;
