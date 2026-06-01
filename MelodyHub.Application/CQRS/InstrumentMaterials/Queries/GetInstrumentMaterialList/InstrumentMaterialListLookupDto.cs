namespace MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialList;

public class InstrumentMaterialListLookupDto
{
    public Guid InstrumentId { get; set; }
    public string InstrumentName { get; set; } = string.Empty;
    public Guid MaterialId { get; set; }
    public string MaterialName { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string? Notes { get; set; }
    public decimal MaterialUnitPrice { get; set; }
    public string MaterialUnit { get; set; } = string.Empty;
    public string? MaterialImageUrl { get; set; }
    public decimal TotalCost => Quantity * MaterialUnitPrice;
}
