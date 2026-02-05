using AutoMapper;
using MelodyHub.Application.CQRS.UserProjects.Commands.CreateUserProject;
using MelodyHub.Application.CQRS.UserProjects.Commands.DeleteUserProject;
using MelodyHub.Application.CQRS.UserProjects.Commands.UpdateUserProject;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectDetails;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/user-projects")]
public class UserProjectController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<UserProjectDetailsVm>> Get([FromBody] GetUserProjectDetailsDto dto)
    {
        var query = mapper.Map<GetUserProjectDetailsQuery>(dto);

        var userProject = await Mediator.Send(query);

        return Ok(userProject);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserProjectListVm>> Get(Guid id)
    {
        var query = new GetUserProjectListQuery 
        { 
            UserId = id
        };

        var userProejects = await Mediator.Send(query);

        return Ok(userProejects);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateUserProjectDto dto)
    {
        var command = mapper.Map<CreateUserProjectCommand>(dto);

        var userProjectId = await Mediator.Send(command);

        return Ok(userProjectId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateUserProjectDto dto)
    {
        var command = mapper.Map<UpdateUserProjectCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteUserProjectCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
