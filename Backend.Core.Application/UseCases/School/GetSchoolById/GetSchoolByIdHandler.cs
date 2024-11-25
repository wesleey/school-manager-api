using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.School.GetSchoolById;

public class GetSchoolByIdHandler(GetSchoolByIdUseCase getSchoolByIdUseCase, IMapper mapper) : IRequestHandler<GetSchoolByIdRequest, GetSchoolByIdResponse>
{
    private readonly GetSchoolByIdUseCase _getSchoolByIdUseCase = getSchoolByIdUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<GetSchoolByIdResponse> Handle(GetSchoolByIdRequest request, CancellationToken cancellationToken)
    {
        var school = await _getSchoolByIdUseCase.Execute(request.Id, cancellationToken);
        return _mapper.Map<GetSchoolByIdResponse>(school);
    }
}
