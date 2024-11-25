using Backend.Core.Application.UseCases.Class.CreateClass;
using Backend.Core.Application.UseCases.Class.DeleteClass;
using Backend.Core.Application.UseCases.Class.GetAllClasses;
using Backend.Core.Application.UseCases.Class.GetClassById;
using Backend.Core.Application.UseCases.Class.UpdateClass;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Api.Controllers;

[ApiController]
[Route("class")]
public class ClassController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClassRequest request, CancellationToken cancellationToken)
    {
        var entity = await _mediator.Send(request, cancellationToken);

        return Created($"/class/{entity.Id}", new
        {
            success = true,
            message = "Class created successfully",
            data = entity
        });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateClassRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var entity = await _mediator.Send(request, cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Class updated successfully",
            data = entity
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteClassRequest(id), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Class deleted successfully",
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var classes = await _mediator.Send(new GetAllClassesRequest(), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Classes retrieved successfully",
            data = classes
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await _mediator.Send(new GetClassByIdRequest(id), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Class retrieved successfully",
            data = entity
        });
    }
}
