using MediatR;

namespace MelodyHub.Application.CQRS.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
}
