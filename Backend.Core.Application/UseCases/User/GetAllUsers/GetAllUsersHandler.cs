using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.User.GetAllUsers;

public class GetAllUsersHandler(GetAllUsersUseCase getAllUsersUseCase, IMapper mapper) : IRequestHandler<GetAllUsersRequest, List<GetAllUsersResponse>>
{
    private readonly GetAllUsersUseCase _getAllUsersUseCase = getAllUsersUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetAllUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _getAllUsersUseCase.Execute(cancellationToken);
        return users.Select(_mapper.Map<GetAllUsersResponse>).ToList();
    }
}
