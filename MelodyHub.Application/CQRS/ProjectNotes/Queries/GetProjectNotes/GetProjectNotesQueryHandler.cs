using AutoMapper;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.ProjectNotes.Queries.GetProjectNotes;

public class GetProjectNotesQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetProjectNotesQuery, ProjectNotesListVm>
{
    public async Task<ProjectNotesListVm> Handle(GetProjectNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await context.ProjectNotes
            .Where(n => n.UserProjectId == request.UserProjectId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync(cancellationToken);

        var dtos = mapper.Map<List<ProjectNoteDto>>(notes);

        return new ProjectNotesListVm { Notes = dtos };
    }
}
