using MediatR;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.User;
}