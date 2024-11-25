using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.Class.GetClassById;

public class GetClassByIdHandler(GetClassByIdUseCase getClassByIdUseCase, IMapper mapper) : IRequestHandler<GetClassByIdRequest, GetClassByIdResponse>
{
    private readonly GetClassByIdUseCase _getClassByIdUseCase = getClassByIdUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<GetClassByIdResponse> Handle(GetClassByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await _getClassByIdUseCase.Execute(request.Id, cancellationToken);
        return _mapper.Map<GetClassByIdResponse>(entity);
    }
}
