using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.User.GetUserById;

public class GetUserByIdHandler(GetUserByIdUseCase getUserByIdUseCase, IMapper mapper) : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly GetUserByIdUseCase _getUserByIdUseCase = getUserByIdUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _getUserByIdUseCase.Execute(request.Id, cancellationToken);
        return _mapper.Map<GetUserByIdResponse>(user);
    }
}
