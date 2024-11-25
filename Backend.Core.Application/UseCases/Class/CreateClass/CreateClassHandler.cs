using Entities = Backend.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.Class.CreateClass;

public class CreateClassHandler(CreateClassUseCase createClassUseCase, IMapper mapper) : IRequestHandler<CreateClassRequest, CreateClassResponse>
{
    private readonly CreateClassUseCase _createClassUseCase = createClassUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateClassResponse> Handle(CreateClassRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<Entities.Class>(request);
        var entity = await _createClassUseCase.Execute(dto, cancellationToken);
        return _mapper.Map<CreateClassResponse>(entity);
    }
}
