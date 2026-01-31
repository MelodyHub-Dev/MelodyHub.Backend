namespace MelodyHub.Domain;

public class UserFavorite
{
    public int UserId { get; set; }
    public int InstrumentId { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = null!;
    public Instrument Instrument { get; set; } = null!;
}
