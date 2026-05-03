using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.Auth;

public class LoginResult
{
    public string Token { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}
