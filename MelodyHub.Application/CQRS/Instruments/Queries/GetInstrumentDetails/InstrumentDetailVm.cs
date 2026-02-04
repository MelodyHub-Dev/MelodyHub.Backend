using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentDetails;

public class InstrumentDetailVm : IMapWith<Instrument>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ShortDescription { get; set; }
    public Guid CategoryId { get; set; }
    public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Intermediate;
    public int? EstimatedHours { get; set; }
    public string? MainImageUrl { get; set; }
    public int ViewsCount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<Instrument, InstrumentDetailVm>();
}
