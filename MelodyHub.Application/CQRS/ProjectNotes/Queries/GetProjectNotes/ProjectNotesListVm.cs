using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.ProjectNotes.Queries.GetProjectNotes;

public class ProjectNotesListVm
{
    public List<ProjectNoteDto> Notes { get; set; } = [];
}

public class ProjectNoteDto : IMapWith<ProjectNote>
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<ProjectNote, ProjectNoteDto>();
}
