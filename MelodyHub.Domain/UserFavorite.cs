namespace MelodyHub.Domain;

public class UserFavorite
{
    public Guid UserId { get; set; }
    public Guid InstrumentId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public User User { get; set; } = null!;
    public Instrument Instrument { get; set; } = null!;
}
