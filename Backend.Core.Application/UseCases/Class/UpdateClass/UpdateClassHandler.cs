using Entities = Backend.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.Class.UpdateClass;

public class UpdateClassHandler(UpdateClassUseCase updateClassUseCase, IMapper mapper) : IRequestHandler<UpdateClassRequest, UpdateClassResponse>
{
    private readonly UpdateClassUseCase _updateClassUseCase = updateClassUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<UpdateClassResponse> Handle(UpdateClassRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<Entities.Class>(request);
        var entity = await _updateClassUseCase.Execute(request.Id, dto, cancellationToken);
        return _mapper.Map<UpdateClassResponse>(entity);
    }
}
