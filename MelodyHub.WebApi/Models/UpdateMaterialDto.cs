using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.Materials.Commands.UpdateMaterial;
using MelodyHub.Domain.Enums;

namespace MelodyHub.WebApi.Models;

public class UpdateMaterialDto : IMapWith<UpdateMaterialCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public MaterialUnit Unit { get; set; } = MaterialUnit.Piece;
    public decimal AvgPrice { get; set; }
    public string? Category { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateMaterialDto, UpdateMaterialCommand>();
}