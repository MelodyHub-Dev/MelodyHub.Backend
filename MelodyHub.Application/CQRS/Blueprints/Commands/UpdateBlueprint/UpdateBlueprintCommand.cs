using MediatR;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.UpdateBlueprint;

public class UpdateBlueprintCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int StepNumber { get; set; }
    public string Content { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public int? EstimatedTimeMinutes { get; set; }
}
