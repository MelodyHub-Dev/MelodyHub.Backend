namespace MelodyHub.Domain;

public class Blueprint
{
    public Guid Id { get; set; }
    public Guid InstrumentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int StepNumber { get; set; }
    public string Content { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public int? EstimatedTimeMinutes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Instrument Instrument { get; set; } = null!;
}
