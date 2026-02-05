using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.UserProjects.Commands.CreateUserProject;
using MelodyHub.Domain.Enums;

namespace MelodyHub.WebApi.Models;

public class CreateUserProjectDto : IMapWith<CreateUserProjectCommand>
{
    public Guid UserId { get; set; }
    public Guid InstrumentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.Planned;
    public byte Progress { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public decimal? ActualCost { get; set; }
    public string? Notes { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateUserProjectDto, CreateUserProjectCommand>();
}
