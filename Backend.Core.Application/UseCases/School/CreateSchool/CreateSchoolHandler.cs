using Entities = Backend.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.School.CreateSchool;

public class CreateSchoolHandler(CreateSchoolUseCase createSchoolUseCase, IMapper mapper) : IRequestHandler<CreateSchoolRequest, CreateSchoolResponse>
{
    private readonly CreateSchoolUseCase _createSchoolUseCase = createSchoolUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateSchoolResponse> Handle(CreateSchoolRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<Entities.School>(request);
        var school = await _createSchoolUseCase.Execute(dto, cancellationToken);
        return _mapper.Map<CreateSchoolResponse>(school);
    }
}
