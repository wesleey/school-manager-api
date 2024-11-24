using System.Net;

namespace Backend.Core.Application.Exceptions;

public sealed class BadRequestException(string message)
    : HttpException(message, HttpStatusCode.BadRequest);
