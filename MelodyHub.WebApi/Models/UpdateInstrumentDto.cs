using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.Instruments.Commands.UpdateInstrument;
using MelodyHub.Domain.Enums;

namespace MelodyHub.WebApi.Models;

public class UpdateInstrumentDto : IMapWith<UpdateInstrumentCommand>
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

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateInstrumentDto, UpdateInstrumentCommand>();
}