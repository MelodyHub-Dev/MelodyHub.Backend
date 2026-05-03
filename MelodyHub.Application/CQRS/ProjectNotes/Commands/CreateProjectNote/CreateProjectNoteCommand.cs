using MediatR;

namespace MelodyHub.Application.CQRS.ProjectNotes.Commands.CreateProjectNote;

public class CreateProjectNoteCommand : IRequest<Guid>
{
    public Guid UserProjectId { get; set; }
    public string Content { get; set; } = string.Empty;
}
