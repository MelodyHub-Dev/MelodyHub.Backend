using MediatR;

namespace MelodyHub.Application.CQRS.ProjectNotes.Queries.GetProjectNotes;

public class GetProjectNotesQuery : IRequest<ProjectNotesListVm>
{
    public Guid UserProjectId { get; set; }
}
