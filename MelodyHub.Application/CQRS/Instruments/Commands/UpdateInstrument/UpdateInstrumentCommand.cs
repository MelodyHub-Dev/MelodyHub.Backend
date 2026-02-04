using MediatR;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.Instruments.Commands.UpdateInstrument;

public class UpdateInstrumentCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ShortDescription { get; set; }
    public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Intermediate;
    public int? EstimatedHours { get; set; }
    public string? MainImageUrl { get; set; }
    public int ViewsCount { get; set; }
    public Guid CategoryId { get; set; }
}
