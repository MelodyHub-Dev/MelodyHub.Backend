using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.UserProjects.Commands.DeleteUserProject;

public class DeleteUserProjectCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteUserProjectCommand>
{
    public async Task Handle(DeleteUserProjectCommand request, CancellationToken cancellationToken)
    {
        var userProject = await context.UserProjects
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(UserProject), request.Id);

        context.UserProjects.Remove(userProject);

        await context.SaveChangesAsync(cancellationToken);
    }
}
