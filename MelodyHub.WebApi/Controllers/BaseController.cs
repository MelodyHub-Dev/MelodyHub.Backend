using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace MelodyHub.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
    private IMediator _mediator = null!;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
        ?? throw new NullReferenceException("Mediator is null.");

    protected Guid UserId
    {
        get
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier)
                     ?? User.FindFirst(JwtRegisteredClaimNames.Sub)
                     ?? User.FindFirst("sub");

            return claim != null && Guid.TryParse(claim.Value, out var id) ? id : Guid.Empty;
        }
    }
}
