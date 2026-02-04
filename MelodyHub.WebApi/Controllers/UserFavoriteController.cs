using AutoMapper;
using MelodyHub.Application.CQRS.UserFavorites.Commands.CreateUserFavorite;
using MelodyHub.Application.CQRS.UserFavorites.Commands.DeleteUserFavorite;
using MelodyHub.Application.CQRS.UserFavorites.Queries.GetUserFavoriteList;
using MelodyHub.Application.CQRS.Users.Commands.DeleteUser;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/user-favorites")]
public class UserFavoriteController(IMapper mapper) : BaseController
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserFavoritesListVm>> Get(Guid id)
    {
        var query = new GetUserFavoriteListQuery
        {
            UserId = id
        };

        var userFavorites = await Mediator.Send(query);

        return Ok(userFavorites);
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] CreateUserFavoriteDto dto)
    {
        var command = mapper.Map<CreateUserFavoriteCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> Delete([FromBody] DeleteUserFavoriteDto dto)
    {
        var command = mapper.Map<DeleteUserFavoriteCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }
}
