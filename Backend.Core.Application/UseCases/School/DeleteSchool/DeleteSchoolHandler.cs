using MediatR;

namespace Backend.Core.Application.UseCases.School.DeleteSchool;

public class DeleteSchoolHandler(DeleteSchoolUseCase deleteSchoolUseCase) : IRequestHandler<DeleteSchoolRequest>
{
    private readonly DeleteSchoolUseCase _deleteSchoolUseCase = deleteSchoolUseCase;

    public async Task Handle(DeleteSchoolRequest request, CancellationToken cancellationToken)
    {
        await _deleteSchoolUseCase.Execute(request.Id, cancellationToken);
    }
}
