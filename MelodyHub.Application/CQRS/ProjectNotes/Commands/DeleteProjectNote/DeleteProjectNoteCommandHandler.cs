using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.ProjectNotes.Commands.DeleteProjectNote;

public class DeleteProjectNoteCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteProjectNoteCommand>
{
    public async Task Handle(DeleteProjectNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await context.ProjectNotes.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(ProjectNote), request.Id);

        context.ProjectNotes.Remove(note);
        await context.SaveChangesAsync(cancellationToken);
    }
}
