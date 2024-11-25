using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.Class.GetAllClasses;

public class GetAllClassesHandler(GetAllClassesUseCase getAllClassesUseCase, IMapper mapper) : IRequestHandler<GetAllClassesRequest, List<GetAllClassesResponse>>
{
    private readonly GetAllClassesUseCase _getAllClassesUseCase = getAllClassesUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetAllClassesResponse>> Handle(GetAllClassesRequest request, CancellationToken cancellationToken)
    {
        var classes = await _getAllClassesUseCase.Execute(cancellationToken);
        return classes.Select(_mapper.Map<GetAllClassesResponse>).ToList();
    }
}
