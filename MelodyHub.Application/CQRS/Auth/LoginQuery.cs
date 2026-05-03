using MediatR;

namespace MelodyHub.Application.CQRS.Auth;

public class LoginQuery : IRequest<LoginResult>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
