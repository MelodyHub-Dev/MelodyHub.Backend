using AutoMapper;
using MediatR;
using MelodyHub.Application.CQRS.ProjectNotes.Commands.CreateProjectNote;
using MelodyHub.Application.CQRS.ProjectNotes.Commands.DeleteProjectNote;
using MelodyHub.Application.CQRS.ProjectNotes.Queries.GetProjectNotes;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("api/project-notes")]
public class ProjectNoteController(IMapper mapper) : BaseController
{
    [HttpGet("{projectId:guid}")]
    public async Task<ActionResult<ProjectNotesListVm>> Get(Guid projectId)
    {
        var query = new GetProjectNotesQuery { UserProjectId = projectId };
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProjectNoteDto dto)
    {
        var command = mapper.Map<CreateProjectNoteCommand>(dto);
        var id = await Mediator.Send(command);
        return Ok(id);
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteProjectNoteCommand { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }
}
