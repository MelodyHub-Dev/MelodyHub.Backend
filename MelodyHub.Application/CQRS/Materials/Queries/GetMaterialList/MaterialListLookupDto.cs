using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.Materials.Queries.GetMaterialList;

public class MaterialListLookupDto : IMapWith<Material>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public MaterialUnit Unit { get; set; } = MaterialUnit.Piece;
    public decimal AvgPrice { get; set; }
    public string? Category { get; set; }
    public string? ImageUrl { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<Material, MaterialListLookupDto>();
}
