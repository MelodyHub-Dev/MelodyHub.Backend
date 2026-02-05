namespace MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialDetails;

public class MaterialVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal AvgPrice { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string? Category { get; set; }
}
