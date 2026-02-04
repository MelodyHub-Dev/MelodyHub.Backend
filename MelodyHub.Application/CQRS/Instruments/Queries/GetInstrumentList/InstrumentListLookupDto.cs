using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentList;

public class InstrumentListLookupDto : IMapWith<Instrument>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ShortDescription { get; set; }
    public Guid CategoryId { get; set; }
    public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Intermediate;
    public int? EstimatedHours { get; set; }
    public int ViewsCount { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<Instrument, InstrumentListLookupDto>();
}
