using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.Instruments.Commands.CreateInstrument;
using MelodyHub.Domain.Enums;

namespace MelodyHub.WebApi.Models;

public class CreateInstrumentDto : IMapWith<CreateInstrumentCommand>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ShortDescription { get; set; }
    public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Intermediate;
    public int? EstimatedHours { get; set; }
    public string? MainImageUrl { get; set; }
    public int ViewsCount { get; set; }
    public Guid CategoryId { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateInstrumentDto, CreateInstrumentCommand>();
}
