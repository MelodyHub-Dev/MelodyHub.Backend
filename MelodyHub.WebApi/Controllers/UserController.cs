using AutoMapper;
using MelodyHub.Application.CQRS.Users.Commands.CreateUser;
using MelodyHub.Application.CQRS.Users.Commands.DeleteUser;
using MelodyHub.Application.CQRS.Users.Commands.UpdateUser;
using MelodyHub.Application.CQRS.Users.Commands.UploadAvatar;
using MelodyHub.Application.CQRS.Users.Queries.GetUserDetails;
using MelodyHub.Application.CQRS.Users.Queries.GetUserList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/users")]
public class UserController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<UserListVm>> Get()
    {
        var query = new GetUserListQuery()
        {
            Id = UserId
        };

        var users = await Mediator.Send(query);

        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
    {
        var query = new GetUserDetailsQuery
        {
            Id = id
        };

        var user = await Mediator.Send(query);

        return Ok(user);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create(CreateUserDto dto)
    {
        var command = mapper.Map<CreateUserCommand>(dto);
        
        var userId = await Mediator.Send(command);

        return Ok(userId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update(UpdateUserDto dto)
    {
        var command = mapper.Map<UpdateUserCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{id:guid}/avatar")]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<string>> UploadAvatar(Guid id, IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Файл не выбран");

        var command = new UploadAvatarCommand
        {
            UserId = id,
            FileStream = file.OpenReadStream(),
            FileName = file.FileName,
            ContentType = file.ContentType
        };

        var url = await Mediator.Send(command);

        return Ok(new { avatarUrl = url });
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteUserCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}