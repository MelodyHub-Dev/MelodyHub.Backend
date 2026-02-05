using MediatR;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.UserProjects.Commands.UpdateUserProject;

public class UpdateUserProjectCommand : IRequest
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
}
