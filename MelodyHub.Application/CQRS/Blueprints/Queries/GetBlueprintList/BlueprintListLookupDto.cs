using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintList;

public class BlueprintListLookupDto : IMapWith<Blueprint>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int StepNumber { get; set; }
    public string? ImageUrl { get; set; }
    public string? DrawingUrl { get; set; }
    public int? EstimatedTimeMinutes { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<Blueprint, BlueprintListLookupDto>();
}
