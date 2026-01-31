namespace MelodyHub.Domain;

public class InstrumentCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    public ICollection<Instrument> Instruments { get; set; } = [];
}
