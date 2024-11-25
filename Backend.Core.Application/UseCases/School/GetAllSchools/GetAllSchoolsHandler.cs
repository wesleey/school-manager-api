using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.School.GetAllSchools;

public class GetAllSchoolsHandler(GetAllSchoolsUseCase getAllSchoolsUseCase, IMapper mapper) : IRequestHandler<GetAllSchoolsRequest, List<GetAllSchoolsResponse>>
{
    private readonly GetAllSchoolsUseCase _getAllSchoolsUseCase = getAllSchoolsUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetAllSchoolsResponse>> Handle(GetAllSchoolsRequest request, CancellationToken cancellationToken)
    {
        var schools = await _getAllSchoolsUseCase.Execute(cancellationToken);
        return schools.Select(_mapper.Map<GetAllSchoolsResponse>).ToList();
    }
}
