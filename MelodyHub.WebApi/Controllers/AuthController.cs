using MelodyHub.Application.CQRS.Auth;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/auth")]
public class AuthController : BaseController
{
    /// <summary>POST /api/auth/login</summary>
    [HttpPost("login")]
    public async Task<ActionResult<LoginResult>> Login([FromBody] LoginDto dto)
    {
        var result = await Mediator.Send(new LoginQuery
        {
            Email = dto.Email,
            Password = dto.Password
        });
        return Ok(result);
    }

    /// <summary>POST /api/auth/verify-email — подтвердить код из письма</summary>
    [HttpPost("verify-email")]
    public async Task<ActionResult> VerifyEmail([FromBody] VerifyEmailDto dto)
    {
        await Mediator.Send(new VerifyEmailCommand { Token = dto.Token });
        return NoContent();
    }

    /// <summary>POST /api/auth/resend-verification — повторно отправить код</summary>
    [HttpPost("resend-verification")]
    public async Task<ActionResult> ResendVerification([FromBody] ResendVerificationDto dto)
    {
        await Mediator.Send(new SendVerificationEmailCommand { UserId = dto.UserId });
        return NoContent();
    }
}
