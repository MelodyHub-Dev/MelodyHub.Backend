using AutoMapper;
using MelodyHub.Application.CQRS.UserProjects.Commands.CreateUserProject;
using MelodyHub.Application.CQRS.UserProjects.Commands.DeleteUserProject;
using MelodyHub.Application.CQRS.UserProjects.Commands.UpdateUserProject;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetAllUserProjects;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectById;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectDetails;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/user-projects")]
public class UserProjectController(IMapper mapper) : BaseController
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserProjectDetailsVm>> GetById(Guid id)
    {
        var query = new GetUserProjectDetailsQuery
        {
            UserProjectId = id,
            UserId = UserId
        };

        var userProject = await Mediator.Send(query);

        return Ok(userProject);
    }

    [HttpGet("public/{id:guid}")]
    public async Task<ActionResult<UserProjectDetailsVm>> GetPublicById(Guid id)
    {
        var query = new GetUserProjectByIdQuery
        {
            Id = id
        };

        var userProject = await Mediator.Send(query);

        return Ok(userProject);
    }

    [HttpGet("user/{id:guid}")]
    public async Task<ActionResult<UserProjectListVm>> GetByUserId(Guid id, [FromQuery] Guid? instrumentId)
    {
        var query = new GetUserProjectListQuery 
        { 
            UserId = id,
            InstrumentId = instrumentId
        };

        var userProejects = await Mediator.Send(query);

        return Ok(userProejects);
    }

    [HttpGet("all")]
    public async Task<ActionResult<UserProjectListVm>> GetAll()
    {
        var query = new GetAllUserProjectsQuery();

        var userProjects = await Mediator.Send(query);

        return Ok(userProjects);
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
