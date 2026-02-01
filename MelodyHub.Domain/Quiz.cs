namespace MelodyHub.Domain;

public class Quiz
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<QuizQuestion> Questions { get; set; } = [];
    public ICollection<QuizResult> Results { get; set; } = [];

    public int QuestionCount => Questions.Count;
    public int MaxScore => Questions.Sum(q => q.Points);
}
