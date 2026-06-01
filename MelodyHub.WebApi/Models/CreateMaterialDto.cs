using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.Materials.Commands.CreateMaterial;
using MelodyHub.Domain.Enums;

namespace MelodyHub.WebApi.Models;

public class CreateMaterialDto : IMapWith<CreateMaterialCommand>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public MaterialUnit Unit { get; set; } = MaterialUnit.Piece;
    public decimal AvgPrice { get; set; }
    public string? Category { get; set; }
    public string? ImageUrl { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateMaterialDto, CreateMaterialCommand>();
}
