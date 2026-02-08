using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintDetails;

public class BlueprintDetailsVm : IMapWith<Blueprint>
{
    public Guid Id { get; set; }
    public Guid InstrumentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int StepNumber { get; set; }
    public string Content { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public int? EstimatedTimeMinutes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public void Mapping(Profile profile)
        => profile.CreateMap<Blueprint, BlueprintDetailsVm>();
}
