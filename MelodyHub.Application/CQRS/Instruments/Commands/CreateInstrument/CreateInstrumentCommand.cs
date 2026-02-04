using MediatR;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.Instruments.Commands.CreateInstrument;

public class CreateInstrumentCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ShortDescription { get; set; }
    public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Intermediate;
    public int? EstimatedHours { get; set; }
    public string? MainImageUrl { get; set; }
    public int ViewsCount { get; set; }
    public Guid CategoryId { get; set; }
}
