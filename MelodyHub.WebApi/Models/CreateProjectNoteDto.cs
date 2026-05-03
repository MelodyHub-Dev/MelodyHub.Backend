using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.ProjectNotes.Commands.CreateProjectNote;

namespace MelodyHub.WebApi.Models;

public class CreateProjectNoteDto : IMapWith<CreateProjectNoteCommand>
{
    public Guid UserProjectId { get; set; }
    public string Content { get; set; } = string.Empty;

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateProjectNoteDto, CreateProjectNoteCommand>();
}
