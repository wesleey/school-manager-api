using Backend.Core.Application.UseCases.School.CreateSchool;
using Backend.Core.Application.UseCases.School.DeleteSchool;
using Backend.Core.Application.UseCases.School.GetAllSchools;
using Backend.Core.Application.UseCases.School.GetSchoolById;
using Backend.Core.Application.UseCases.School.UpdateSchool;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Api.Controllers;

[ApiController]
[Route("school")]
public class SchoolController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSchoolRequest request, CancellationToken cancellationToken)
    {
        var school = await _mediator.Send(request, cancellationToken);

        return Created($"/school/{school.Id}", new
        {
            success = true,
            message = "School created successfully",
            data = school
        });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSchoolRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var school = await _mediator.Send(request, cancellationToken);

        return Ok(new
        {
            success = true,
            message = "School updated successfully",
            data = school
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteSchoolRequest(id), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "School deleted successfully",
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var schools = await _mediator.Send(new GetAllSchoolsRequest(), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "Schools retrieved successfully",
            data = schools
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var school = await _mediator.Send(new GetSchoolByIdRequest(id), cancellationToken);

        return Ok(new
        {
            success = true,
            message = "School retrieved successfully",
            data = school
        });
    }
}
