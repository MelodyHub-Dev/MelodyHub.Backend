using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.Blueprints.Commands.UpdateBlueprint;

namespace MelodyHub.WebApi.Models;

public class UpdateBlueprintDto : IMapWith<UpdateBlueprintCommand>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int StepNumber { get; set; }
    public string Content { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public int? EstimatedTimeMinutes { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateBlueprintDto, UpdateBlueprintCommand>();
}
