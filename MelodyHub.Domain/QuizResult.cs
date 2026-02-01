namespace MelodyHub.Domain;

public class QuizResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid QuizId { get; set; }
    public int Score { get; set; }
    public int MaxScore { get; set; }
    public DateTime CompletedAt { get; set; } = DateTime.Now;

    public User User { get; set; } = null!;
    public Quiz Quiz { get; set; } = null!;

    public double Percentage => MaxScore > 0 ? (double)Score / MaxScore * 100 : 0;
    public bool Passed => Percentage >= 70; 

    public string Grade => Percentage switch
    {
        >= 90 => "Отлично",
        >= 75 => "Хорошо",
        >= 60 => "Удовлетворительно",
        _ => "Неудовлетворительно"
    };
}
