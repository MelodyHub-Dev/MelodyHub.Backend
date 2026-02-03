using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.Id);

        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
    }
}
