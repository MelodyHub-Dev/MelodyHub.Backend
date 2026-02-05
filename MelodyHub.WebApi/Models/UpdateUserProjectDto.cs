using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.UserProjects.Commands.UpdateUserProject;
using MelodyHub.Domain.Enums;

namespace MelodyHub.WebApi.Models;

public class UpdateUserProjectDto : IMapWith<UpdateUserProjectCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.Planned;
    public byte Progress { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public decimal? ActualCost { get; set; }
    public string? Notes { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateUserProjectDto, UpdateUserProjectCommand>();
}
