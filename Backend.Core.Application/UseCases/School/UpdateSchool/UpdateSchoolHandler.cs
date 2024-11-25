using Entities = Backend.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.School.UpdateSchool;

public class UpdateSchoolHandler(UpdateSchoolUseCase updateSchoolUseCase, IMapper mapper) : IRequestHandler<UpdateSchoolRequest, UpdateSchoolResponse>
{
    private readonly UpdateSchoolUseCase _updateSchoolUseCase = updateSchoolUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<UpdateSchoolResponse> Handle(UpdateSchoolRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<Entities.School>(request);
        var school = await _updateSchoolUseCase.Execute(request.Id, dto, cancellationToken);
        return _mapper.Map<UpdateSchoolResponse>(school);
    }
}
