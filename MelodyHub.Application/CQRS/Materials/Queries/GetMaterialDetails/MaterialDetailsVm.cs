using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.Materials.Queries.GetMaterialDetails;

public class MaterialDetailsVm : IMapWith<Material>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public MaterialUnit Unit { get; set; } = MaterialUnit.Piece;
    public decimal AvgPrice { get; set; }
    public string? Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public void Mapping(Profile profile)
        => profile.CreateMap<Material, MaterialDetailsVm>();
}
