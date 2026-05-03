using MediatR;

namespace MelodyHub.Application.CQRS.Auth;

public class VerifyEmailCommand : IRequest
{
    public string Token { get; set; } = string.Empty;
}
