using MediatR;

namespace MelodyHub.Application.CQRS.ProjectNotes.Commands.DeleteProjectNote;

public class DeleteProjectNoteCommand : IRequest
{
    public Guid Id { get; set; }
}
