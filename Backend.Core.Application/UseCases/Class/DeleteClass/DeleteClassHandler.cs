using MediatR;

namespace Backend.Core.Application.UseCases.Class.DeleteClass;

public class DeleteClassHandler(DeleteClassUseCase deleteClassUseCase) : IRequestHandler<DeleteClassRequest>
{
    private readonly DeleteClassUseCase _deleteClassUseCase = deleteClassUseCase;

    public async Task Handle(DeleteClassRequest request, CancellationToken cancellationToken)
    {
        await _deleteClassUseCase.Execute(request.Id, cancellationToken);
    }
}
