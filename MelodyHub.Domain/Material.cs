using MelodyHub.Domain.Enums;

namespace MelodyHub.Domain;

public class Material
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public MaterialUnit Unit { get; set; } = MaterialUnit.Piece;
    public decimal AvgPrice { get; set; }
    public string? Category { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<InstrumentMaterial> InstrumentMaterials { get; set; } = [];
}
