using MelodyHub.Domain.Enums;

namespace MelodyHub.Domain;

public class UserProject
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid InstrumentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.Planned;
    public byte Progress { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public decimal? ActualCost { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public User User { get; set; } = null!;
    public Instrument Instrument { get; set; } = null!;

    public bool IsCompleted => Status == ProjectStatus.Completed;
    public string? Duration => StartDate.HasValue && FinishDate.HasValue
        ? $"{(FinishDate.Value.DayNumber - StartDate.Value.DayNumber)} дней"
        : null;
}
