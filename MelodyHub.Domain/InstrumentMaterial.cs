namespace MelodyHub.Domain;

public class InstrumentMaterial
{
    public Guid InstrumentId { get; set; }
    public Guid MaterialId { get; set; }
    public decimal Quantity { get; set; } = 1.00m;
    public string? Notes { get; set; }

    public Instrument Instrument { get; set; } = null!;
    public Material Material { get; set; } = null!;
}
