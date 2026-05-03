using MediatR;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.ProjectNotes.Commands.CreateProjectNote;

public class CreateProjectNoteCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateProjectNoteCommand, Guid>
{
    public async Task<Guid> Handle(CreateProjectNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new ProjectNote
        {
            Id = Guid.NewGuid(),
            UserProjectId = request.UserProjectId,
            Content = request.Content,
            CreatedAt = DateTime.Now
        };

        await context.ProjectNotes.AddAsync(note, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return note.Id;
    }
}
